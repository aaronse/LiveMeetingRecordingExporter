using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsoft.LiveMeeting.RecordingExporter
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            textBoxConfCenter.Text = Config.ConfCenterName;
            textBoxUsername.Text = Config.Username;
            textBoxPassword.Text = Config.Password;
            if (!string.IsNullOrWhiteSpace(Config.PostingURL))
            {
                valueURL.Text = Config.PostingURL;
            }
            else
            {
                valueURL.Text = "Enter a conference center name, and check that it is valid to continue";
            }
            ValidateInput();
        }

        public string Username { get { return textBoxUsername.Text; } }

        public string ConfCenter { get { return textBoxConfCenter.Text; } }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Config.Username = textBoxUsername.Text;
            Config.Password = textBoxPassword.Text;
            Properties.Settings.Default.Username = Config.Username;
            Properties.Settings.Default.ConfCenter = Config.ConfCenterName;
            Properties.Settings.Default.PostingURL = Config.PostingURL;
            Properties.Settings.Default.Save();
            DialogResult = DialogResult.OK;
        }

        private void buttonCheckURL_Click(object sender, EventArgs e)
        {
            Config.ConfCenterName = textBoxConfCenter.Text;
            Config.UpdatePostingURL();
            if (Config.IsValidPostingUrl)
            {
                valueURL.Text = Config.PostingURL;
                buttonCheckURL.Enabled = false;
            }
            else
            {
                valueURL.Text = "Not a valid conference center name";
                buttonSave.Enabled = false;
            }
            ValidateInput();
        }

        private void textBoxConfCenter_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            buttonCheckURL.Enabled = true;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }
        
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void ValidateInput()
        {
            bool isValid =
                Config.IsValidPostingUrl &&
                !string.IsNullOrWhiteSpace(textBoxUsername.Text) &&
                !string.IsNullOrWhiteSpace(textBoxPassword.Text);

            buttonSave.Enabled = isValid;
        }
    }
}
