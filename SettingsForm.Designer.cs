namespace Microsoft.LiveMeeting.RecordingExporter
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelConfCenter = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxConfCenter = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonCheckURL = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.valueURL = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.linkPrivacy = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelViewerEmail = new System.Windows.Forms.Label();
            this.textRecViewerEmail = new System.Windows.Forms.TextBox();
            this.textRecViewerCompany = new System.Windows.Forms.TextBox();
            this.textRecViewerName = new System.Windows.Forms.TextBox();
            this.labelViewerCompany = new System.Windows.Forms.Label();
            this.labelViewerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(710, 695);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(150, 44);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(548, 695);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(150, 44);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelConfCenter
            // 
            this.labelConfCenter.AutoSize = true;
            this.labelConfCenter.Location = new System.Drawing.Point(46, 182);
            this.labelConfCenter.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelConfCenter.Name = "labelConfCenter";
            this.labelConfCenter.Size = new System.Drawing.Size(322, 25);
            this.labelConfCenter.TabIndex = 2;
            this.labelConfCenter.Text = "Live Meeting Conference Center";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(46, 17);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(116, 25);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "User name";
            // 
            // textBoxConfCenter
            // 
            this.textBoxConfCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfCenter.Location = new System.Drawing.Point(52, 213);
            this.textBoxConfCenter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxConfCenter.Name = "textBoxConfCenter";
            this.textBoxConfCenter.Size = new System.Drawing.Size(670, 31);
            this.textBoxConfCenter.TabIndex = 2;
            this.textBoxConfCenter.TextChanged += new System.EventHandler(this.textBoxConfCenter_TextChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUsername.Location = new System.Drawing.Point(52, 48);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(670, 31);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // buttonCheckURL
            // 
            this.buttonCheckURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckURL.Location = new System.Drawing.Point(734, 211);
            this.buttonCheckURL.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonCheckURL.Name = "buttonCheckURL";
            this.buttonCheckURL.Size = new System.Drawing.Size(126, 38);
            this.buttonCheckURL.TabIndex = 3;
            this.buttonCheckURL.Text = "Check";
            this.buttonCheckURL.UseVisualStyleBackColor = true;
            this.buttonCheckURL.Click += new System.EventHandler(this.buttonCheckURL_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(46, 254);
            this.labelURL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(140, 25);
            this.labelURL.TabIndex = 7;
            this.labelURL.Text = "Request URL";
            // 
            // valueURL
            // 
            this.valueURL.AutoSize = true;
            this.valueURL.Location = new System.Drawing.Point(46, 282);
            this.valueURL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.valueURL.Name = "valueURL";
            this.valueURL.Size = new System.Drawing.Size(36, 25);
            this.valueURL.TabIndex = 8;
            this.valueURL.Text = "url";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(52, 130);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(670, 31);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(46, 100);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(106, 25);
            this.labelPassword.TabIndex = 10;
            this.labelPassword.Text = "Password";
            // 
            // linkPrivacy
            // 
            this.linkPrivacy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkPrivacy.AutoSize = true;
            this.linkPrivacy.Location = new System.Drawing.Point(47, 705);
            this.linkPrivacy.Name = "linkPrivacy";
            this.linkPrivacy.Size = new System.Drawing.Size(187, 25);
            this.linkPrivacy.TabIndex = 12;
            this.linkPrivacy.TabStop = true;
            this.linkPrivacy.Text = "Privacy && Cookies";
            this.linkPrivacy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPrivacy_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 367);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(479, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "OPTIONAL: For Registration required events";
            // 
            // labelViewerEmail
            // 
            this.labelViewerEmail.AutoSize = true;
            this.labelViewerEmail.Location = new System.Drawing.Point(46, 495);
            this.labelViewerEmail.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelViewerEmail.Name = "labelViewerEmail";
            this.labelViewerEmail.Size = new System.Drawing.Size(240, 25);
            this.labelViewerEmail.TabIndex = 24;
            this.labelViewerEmail.Text = "Recording Viewer Email";
            // 
            // textRecViewerEmail
            // 
            this.textRecViewerEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textRecViewerEmail.Location = new System.Drawing.Point(52, 525);
            this.textRecViewerEmail.Margin = new System.Windows.Forms.Padding(6);
            this.textRecViewerEmail.Name = "textRecViewerEmail";
            this.textRecViewerEmail.Size = new System.Drawing.Size(678, 31);
            this.textRecViewerEmail.TabIndex = 20;
            // 
            // textRecViewerCompany
            // 
            this.textRecViewerCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textRecViewerCompany.Location = new System.Drawing.Point(52, 439);
            this.textRecViewerCompany.Margin = new System.Windows.Forms.Padding(6);
            this.textRecViewerCompany.Name = "textRecViewerCompany";
            this.textRecViewerCompany.Size = new System.Drawing.Size(678, 31);
            this.textRecViewerCompany.TabIndex = 19;
            // 
            // textRecViewerName
            // 
            this.textRecViewerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textRecViewerName.Location = new System.Drawing.Point(52, 612);
            this.textRecViewerName.Margin = new System.Windows.Forms.Padding(6);
            this.textRecViewerName.Name = "textRecViewerName";
            this.textRecViewerName.Size = new System.Drawing.Size(678, 31);
            this.textRecViewerName.TabIndex = 21;
            // 
            // labelViewerCompany
            // 
            this.labelViewerCompany.AutoSize = true;
            this.labelViewerCompany.Location = new System.Drawing.Point(46, 408);
            this.labelViewerCompany.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelViewerCompany.Name = "labelViewerCompany";
            this.labelViewerCompany.Size = new System.Drawing.Size(278, 25);
            this.labelViewerCompany.TabIndex = 23;
            this.labelViewerCompany.Text = "Recording Viewer Company";
            // 
            // labelViewerName
            // 
            this.labelViewerName.AutoSize = true;
            this.labelViewerName.Location = new System.Drawing.Point(46, 581);
            this.labelViewerName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelViewerName.Name = "labelViewerName";
            this.labelViewerName.Size = new System.Drawing.Size(243, 25);
            this.labelViewerName.TabIndex = 22;
            this.labelViewerName.Text = "Recording Viewer Name";
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(884, 785);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelViewerEmail);
            this.Controls.Add(this.textRecViewerEmail);
            this.Controls.Add(this.textRecViewerCompany);
            this.Controls.Add(this.textRecViewerName);
            this.Controls.Add(this.labelViewerCompany);
            this.Controls.Add(this.labelViewerName);
            this.Controls.Add(this.linkPrivacy);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.valueURL);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.buttonCheckURL);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxConfCenter);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelConfCenter);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelConfCenter;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxConfCenter;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonCheckURL;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Label valueURL;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.LinkLabel linkPrivacy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelViewerEmail;
        private System.Windows.Forms.TextBox textRecViewerEmail;
        private System.Windows.Forms.TextBox textRecViewerCompany;
        private System.Windows.Forms.TextBox textRecViewerName;
        private System.Windows.Forms.Label labelViewerCompany;
        private System.Windows.Forms.Label labelViewerName;
    }
}