using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;


namespace Microsoft.LiveMeeting.RecordingExporter
{
    class Config
    {
        public static string ConfCenterName { get; set; }
        public static string PostingURL { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static bool IsValidPostingUrl { get; set; }

        public static void LoadSettings()
        {
            Username = Properties.Settings.Default.Username;
            ConfCenterName = Properties.Settings.Default.ConfCenter;
            if (!string.IsNullOrWhiteSpace(ConfCenterName))
                UpdatePostingURL();
            else
                IsValidPostingUrl = false;
        }

        public static bool IsConfigValid()
        {
            return Config.IsValidPostingUrl && 
                !String.IsNullOrWhiteSpace(Config.Username) && 
                !string.IsNullOrWhiteSpace(Password);
        }

        public static void UpdatePostingURL()
        {
            IsValidPostingUrl = false;
            PostingURL = string.Empty;
            XmlDocument xmldoc = new XmlDocument();

            string getPostingUrl = String.Format("https://www.livemeeting.com/cc/{0}/xml/4.0/GetPostingURLRequest", ConfCenterName);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getPostingUrl);
            request.Method = "GET";

            // Get the response from the conference center
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                try
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        if (response.ContentType == "application/xml")
                        {
                            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                            xmldoc.Load(responseStream);

                            // Retrieve the url attribute of <GetPostingURLReply>
                            XmlNode attrUrl = xmldoc.SelectSingleNode("/PlaceWareConfCenter/GetPostingURLReply/@url");
                            if (attrUrl != null)
                            {
                                IsValidPostingUrl = true;
                                PostingURL = attrUrl.Value;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception: {0}\nTrace: {1}", e.Message, e.StackTrace);
                }
            }
        }
    }
}
