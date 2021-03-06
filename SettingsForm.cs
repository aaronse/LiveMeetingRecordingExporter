﻿using System;
using System.Diagnostics;
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

            textRecViewerName.Text = Config.RecViewerName;
            textRecViewerCompany.Text = Config.RecViewerCompany;
            textRecViewerEmail.Text = Config.RecViewerEmail;

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
            Config.RecViewerName = textRecViewerName.Text;
            Config.RecViewerCompany = textRecViewerCompany.Text;
            Config.RecViewerEmail = textRecViewerEmail.Text;

            Properties.Settings.Default.Username = Config.Username;
            Properties.Settings.Default.ConfCenter = Config.ConfCenterName;
            Properties.Settings.Default.PostingURL = Config.PostingURL;
            Properties.Settings.Default.RecViewerName = Config.RecViewerName;
            Properties.Settings.Default.RecViewerCompany = Config.RecViewerCompany;
            Properties.Settings.Default.RecViewerEmail = Config.RecViewerEmail;
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

        private void linkPrivacy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://go.microsoft.com/fwlink/?LinkId=521839");
            Process.Start(sInfo);
        }
    }
}
