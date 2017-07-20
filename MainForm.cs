using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace Microsoft.LiveMeeting.RecordingExporter
{
    public partial class MainForm : Form
    {
        public SortableBindingList<Recording> _recordings;
        string _outputPath;
        public List<string> _report;
        public Timer _initTimer;
        private ListSortDirection _sortDir = ListSortDirection.Ascending;
        private int _sortColumn = 0;

        public MainForm()
        {
            InitializeComponent();
            
            _recordings = new SortableBindingList<Recording>();
            _report = new List<string>();
            
            _initTimer = new Timer();
            _initTimer.Interval = 150;
            _initTimer.Tick += OnInitTimerTick;
            _initTimer.Start();
        }

        private void OnInitTimerTick(object sender, EventArgs e)
        {
            _initTimer.Stop();

            Invoke((Action)delegate () {
                Initialize();
            });
        }

        void Initialize()
        {
            Config.LoadSettings();

            if (!Config.IsConfigValid())
            {
                GetSettings();
            }

            if (!Config.IsConfigValid())
            {
                MessageBox.Show("Expected valid conference center name, username and password.  Exiting...", "Settings error", MessageBoxButtons.OK);
                Application.Exit();
            }

            if (Config.IsConfigValid())
                RefreshRecordingList();
        }

        void GetSettings()
        {
            SettingsForm settings = new SettingsForm();
            DialogResult result = settings.ShowDialog();
        }

        void RefreshRecordingList()
        {
            XDocument requestDoc = new XDocument(
                new XElement("PlaceWareConfCenter", new XAttribute("authUser", Properties.Settings.Default.Username), new XAttribute("authPassword", Config.Password),
                    new XElement("ListRecordingsRequest", new XAttribute("listDeleted", false),
                        new XElement("TimeIntervalQuery", new XAttribute("fieldName", "startTime"),
                            new XElement("TimeInterval", new XAttribute("startTime", "2015-01-01T00:00:00Z"), new XAttribute("endTime", "2016-10-26T00:00:00Z"))),
                        new XElement("FieldList",
                            new XElement("Name", "title"),
                            new XElement("Name", "createTime"),
                            new XElement("Name", "duration"),
                            new XElement("Name", "owner"),
                            new XElement("Name", "name"),
                            new XElement("Name", "registration"),
                            new XElement("Name", "size"),
                            new XElement("Name", "startTime"),
                            new XElement("Name", "timeZone"),
                            new XElement("Name", "reid")))));

            XmlDocument doc = new XmlDocument();
            doc.Load(requestDoc.CreateReader());

            XmlDocument resp = XmlApiClient.PostMessageRequest(doc);

            XmlNodeList list = resp.SelectNodes("//Recording");
            _recordings.Clear();
            foreach (XmlNode node in list)
            {
                Recording recording = new Recording(node);
                _recordings.Add(recording);
            }

            Debug.WriteLine(_recordings.Count.ToString());
            dataGridView1.DataSource = _recordings;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private string GetRecordingURL(string recID)
        {
            XDocument requestDoc = new XDocument(
            new XElement("PlaceWareConfCenter", new XAttribute("authUser", Properties.Settings.Default.Username), new XAttribute("authPassword", Config.Password),
                new XElement("GetURLRequest",
                    new XElement("StringQuery", new XAttribute("fieldName", "reid"), new XAttribute("operator", "="), new XAttribute("value", recID)),
                    new XElement("OptionList",
                        new XElement("StringOption", new XAttribute("name", "recViewerCompany"), new XAttribute("value", Config.RecViewerCompany)),
                        new XElement("StringOption", new XAttribute("name", "recViewerName"), new XAttribute("value", Config.RecViewerName)),
                        new XElement("StringOption", new XAttribute("name", "recViewerEmail"), new XAttribute("value", Config.RecViewerEmail)),
                        new XElement("EnumerationOption", new XAttribute("name", "resourceType"), new XAttribute("value", "WindowsMediaMovieRecordingDownload"),
                            new XElement("String", "ESS"),
                            new XElement("String", "PWP"),
                            new XElement("String", "HighFidelityPresentation"),
                            new XElement("String", "HighFidelityPresentationDownload"),
                            new XElement("String", "WindowsMediaMovieRecording"),
                            new XElement("String", "WindowsMediaMovieRecordingDownload"),
                            new XElement("String", "BasicRecording"))))));

            XmlDocument doc = new XmlDocument();
            doc.Load(requestDoc.CreateReader());

            XmlDocument response = XmlApiClient.PostMessageRequest(doc);
            XmlNode node = response.SelectSingleNode("//GetURLReply");
            if (node == null)
            {
                Debug.WriteLine("GetURLReply missing, response=" + response.OuterXml);
                return null;
            }

            string url = node.Attributes["url"].Value;
            return url;
        }

        private async void OnDownloadButtonClick(object sender, EventArgs e)
        {
            buttonDownload.Enabled = false;
            if (dataGridView1.SelectedRows.Count <= 0)
                return;

            FolderBrowserDialog picker = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.FolderPath))
                picker.SelectedPath = Properties.Settings.Default.FolderPath;
            DialogResult r = picker.ShowDialog();
            if (r != DialogResult.OK)
            {
                return;
            }
            _outputPath = picker.SelectedPath;
            Properties.Settings.Default.FolderPath = _outputPath;
            Properties.Settings.Default.Save();

            progressBarOverall.Value = 0;
            progressBarOverall.Visible = true;
            progressBarSingle.Visible = true;
            dataGridView1.Enabled = false;
            progressBarOverall.Maximum = dataGridView1.SelectedRows.Count - 1;
            IProgress<int> progress = new Progress<int>(value => {
                if (value == -1)
                {
                    progressBarOverall.Value = 0;
                    progressBarOverall.Visible = false;
                    progressBarSingle.Visible = false;
                    dataGridView1.Enabled = true;
                    buttonDownload.Enabled = true;
                    labelCurrentFile.Text = "Done!";
                }
                else
                {
                    progressBarOverall.Value = value;
                }
            });
            IProgress<string> updateFilename = new Progress<string>(value => { labelCurrentFile.Text = value; });
            await Task.Run(() =>
            {
                int progIndex = 0;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string url = GetRecordingURL(row.Cells[0].Value.ToString());
                    if (string.IsNullOrWhiteSpace(url))
                    {
                        progIndex = progIndex + 1;
                        _report.Add("FAILURE: (no valid download URL)" + row.Cells[0]);
                        continue;
                    }

                    string name = DateTime.Parse(row.Cells["StartTime"].Value.ToString()).ToString("yy-MM-dd") + "_" + row.Cells["Title"].Value.ToString() + " (" + row.Cells["RecordingID"].Value.ToString() + ")";
                    name = name.Replace(":", "");
                    name = name.Replace("\\", "");
                    name = name.Replace("//", "");
                    name = name.Replace(".", "");
                    string path = _outputPath + "\\" + name + ".wmv";

                    updateFilename.Report(name);
                    progress.Report(progIndex);
                    progIndex = progIndex + 1;
                    try
                    {
                        DownloadResource(url, path);
                        _report.Add("SUCCESS: " + row.Cells[0]);
                    }
                    catch (Exception ex)
                    {
                        _report.Add("FAILURE: (" + ex.Message + ") " + row.Cells[0]);
                    }
                }
                progress.Report(-1);
            });
        }

        public Stream GetResourceStream(string url)
        {
            // Get resource using HTTP GET with the url of a resource;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            Stream responseStream = null;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.ContentType == "application/octet-stream")
            {
                responseStream = response.GetResponseStream();
            }

            return responseStream;
        }

        public void DownloadResource(string url, string filePath)
        {
            using (Stream res = GetResourceStream(url))
            {
                if (res == null)
                    return;

                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    int length = 1024 * 1024;
                    Byte[] buffer = new Byte[length];
                    int bytesRead = res.Read(buffer, 0, length);
                    while (bytesRead > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        bytesRead = res.Read(buffer, 0, length);
                    }
                    fileStream.Close();
                }
                res.Close();
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshRecordingList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                labelSelected.Text = "Download " + dataGridView1.SelectedRows.Count.ToString() + " recordings.  This process may take a long time to complete.";
            else
                labelSelected.Text = "Select one or more recordings from the list to download.";
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_sortColumn == e.ColumnIndex)
                _sortDir = (_sortDir == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            _sortColumn = e.ColumnIndex;

            dataGridView1.Sort(dataGridView1.Columns[_sortColumn], _sortDir);
        }
    }
}
