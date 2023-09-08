namespace Blade_and_Sorcery_Update_Skipper
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.GameLocationLabel = new System.Windows.Forms.Label();
            this.GameLocationTextBox = new System.Windows.Forms.TextBox();
            this.GameLocationBrowseButton = new System.Windows.Forms.Button();
            this.IntroInfoLabel = new System.Windows.Forms.Label();
            this.IntroWarningLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.DownloadWarningLabel = new System.Windows.Forms.Label();
            this.DownloadLinkLabel = new System.Windows.Forms.LinkLabel();
            this.DividerLabel1 = new System.Windows.Forms.Label();
            this.LatestManifestIDLabel = new System.Windows.Forms.Label();
            this.LatestManifestIDTextBox = new System.Windows.Forms.TextBox();
            this.LatestManifestIDOpenSteamDBButton = new System.Windows.Forms.Button();
            this.ApplyWarningLabel = new System.Windows.Forms.Label();
            this.ApplyChangesButton = new System.Windows.Forms.Button();
            this.BackupLocationLabel = new System.Windows.Forms.Label();
            this.BackupLocationTextBox = new System.Windows.Forms.TextBox();
            this.BackupLocationBrowseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameLocationLabel
            // 
            this.GameLocationLabel.AutoSize = true;
            this.GameLocationLabel.Location = new System.Drawing.Point(12, 171);
            this.GameLocationLabel.Name = "GameLocationLabel";
            this.GameLocationLabel.Size = new System.Drawing.Size(199, 15);
            this.GameLocationLabel.TabIndex = 0;
            this.GameLocationLabel.Text = "Blade and Sorcery installation folder:";
            // 
            // GameLocationTextBox
            // 
            this.GameLocationTextBox.Location = new System.Drawing.Point(12, 189);
            this.GameLocationTextBox.Name = "GameLocationTextBox";
            this.GameLocationTextBox.PlaceholderText = "Click \"Browse...\" to select installation location...";
            this.GameLocationTextBox.Size = new System.Drawing.Size(391, 23);
            this.GameLocationTextBox.TabIndex = 1;
            // 
            // GameLocationBrowseButton
            // 
            this.GameLocationBrowseButton.Location = new System.Drawing.Point(409, 189);
            this.GameLocationBrowseButton.Name = "GameLocationBrowseButton";
            this.GameLocationBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.GameLocationBrowseButton.TabIndex = 2;
            this.GameLocationBrowseButton.Text = "Browse...";
            this.GameLocationBrowseButton.UseVisualStyleBackColor = true;
            // 
            // IntroInfoLabel
            // 
            this.IntroInfoLabel.AutoSize = true;
            this.IntroInfoLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IntroInfoLabel.Location = new System.Drawing.Point(12, 49);
            this.IntroInfoLabel.Name = "IntroInfoLabel";
            this.IntroInfoLabel.Size = new System.Drawing.Size(463, 60);
            this.IntroInfoLabel.TabIndex = 3;
            this.IntroInfoLabel.Text = resources.GetString("IntroInfoLabel.Text");
            // 
            // IntroWarningLabel
            // 
            this.IntroWarningLabel.AutoSize = true;
            this.IntroWarningLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IntroWarningLabel.Location = new System.Drawing.Point(12, 9);
            this.IntroWarningLabel.Name = "IntroWarningLabel";
            this.IntroWarningLabel.Size = new System.Drawing.Size(437, 30);
            this.IntroWarningLabel.TabIndex = 4;
            this.IntroWarningLabel.Text = "Note: This tool is only compatible with Steam-based installations of Blade and \r\n" +
    "Sorcery. Run this tool at your own risk.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(330, 171);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 15);
            this.linkLabel1.TabIndex = 5;
            // 
            // DownloadWarningLabel
            // 
            this.DownloadWarningLabel.AutoSize = true;
            this.DownloadWarningLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DownloadWarningLabel.Location = new System.Drawing.Point(12, 118);
            this.DownloadWarningLabel.Name = "DownloadWarningLabel";
            this.DownloadWarningLabel.Size = new System.Drawing.Size(358, 15);
            this.DownloadWarningLabel.TabIndex = 6;
            this.DownloadWarningLabel.Text = "Make sure you downloaded this tool from its official repository:";
            // 
            // DownloadLinkLabel
            // 
            this.DownloadLinkLabel.AutoSize = true;
            this.DownloadLinkLabel.Location = new System.Drawing.Point(12, 133);
            this.DownloadLinkLabel.Name = "DownloadLinkLabel";
            this.DownloadLinkLabel.Size = new System.Drawing.Size(326, 15);
            this.DownloadLinkLabel.TabIndex = 7;
            this.DownloadLinkLabel.TabStop = true;
            this.DownloadLinkLabel.Text = "https://github.com/sulliops/BladeAndSorceryUpdateSkipper";
            // 
            // DividerLabel1
            // 
            this.DividerLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DividerLabel1.Location = new System.Drawing.Point(12, 160);
            this.DividerLabel1.Name = "DividerLabel1";
            this.DividerLabel1.Size = new System.Drawing.Size(472, 2);
            this.DividerLabel1.TabIndex = 8;
            // 
            // LatestManifestIDLabel
            // 
            this.LatestManifestIDLabel.AutoSize = true;
            this.LatestManifestIDLabel.Location = new System.Drawing.Point(12, 224);
            this.LatestManifestIDLabel.Name = "LatestManifestIDLabel";
            this.LatestManifestIDLabel.Size = new System.Drawing.Size(201, 15);
            this.LatestManifestIDLabel.TabIndex = 9;
            this.LatestManifestIDLabel.Text = "Latest Blade and Sorcery manifest ID:";
            // 
            // LatestManifestIDTextBox
            // 
            this.LatestManifestIDTextBox.Location = new System.Drawing.Point(12, 242);
            this.LatestManifestIDTextBox.Name = "LatestManifestIDTextBox";
            this.LatestManifestIDTextBox.PlaceholderText = "Click \"Open SteamDB...\" and copy/paste the latest manifest ID...";
            this.LatestManifestIDTextBox.Size = new System.Drawing.Size(358, 23);
            this.LatestManifestIDTextBox.TabIndex = 10;
            // 
            // LatestManifestIDOpenSteamDBButton
            // 
            this.LatestManifestIDOpenSteamDBButton.Location = new System.Drawing.Point(376, 242);
            this.LatestManifestIDOpenSteamDBButton.Name = "LatestManifestIDOpenSteamDBButton";
            this.LatestManifestIDOpenSteamDBButton.Size = new System.Drawing.Size(108, 23);
            this.LatestManifestIDOpenSteamDBButton.TabIndex = 11;
            this.LatestManifestIDOpenSteamDBButton.Text = "Open SteamDB";
            this.LatestManifestIDOpenSteamDBButton.UseVisualStyleBackColor = true;
            // 
            // ApplyWarningLabel
            // 
            this.ApplyWarningLabel.AutoSize = true;
            this.ApplyWarningLabel.Location = new System.Drawing.Point(12, 342);
            this.ApplyWarningLabel.Name = "ApplyWarningLabel";
            this.ApplyWarningLabel.Size = new System.Drawing.Size(458, 45);
            this.ApplyWarningLabel.TabIndex = 12;
            this.ApplyWarningLabel.Text = "Click the \"Apply Changes\" button below to apply changes to Blade and Sorcery\'s ap" +
    "p \r\nmanifest. If Steam is currently running, it will be exited via the Steam con" +
    "sole before \r\nchanges are applied.";
            // 
            // ApplyChangesButton
            // 
            this.ApplyChangesButton.Location = new System.Drawing.Point(12, 390);
            this.ApplyChangesButton.Name = "ApplyChangesButton";
            this.ApplyChangesButton.Size = new System.Drawing.Size(472, 23);
            this.ApplyChangesButton.TabIndex = 13;
            this.ApplyChangesButton.Text = "Apply Changes";
            this.ApplyChangesButton.UseVisualStyleBackColor = true;
            // 
            // BackupLocationLabel
            // 
            this.BackupLocationLabel.AutoSize = true;
            this.BackupLocationLabel.Location = new System.Drawing.Point(12, 277);
            this.BackupLocationLabel.Name = "BackupLocationLabel";
            this.BackupLocationLabel.Size = new System.Drawing.Size(377, 15);
            this.BackupLocationLabel.TabIndex = 14;
            this.BackupLocationLabel.Text = "Existing appmanifest backup location (where a backup will be placed):";
            // 
            // BackupLocationTextBox
            // 
            this.BackupLocationTextBox.Location = new System.Drawing.Point(12, 295);
            this.BackupLocationTextBox.Name = "BackupLocationTextBox";
            this.BackupLocationTextBox.PlaceholderText = "Click \"Browse...\" to select backup location...";
            this.BackupLocationTextBox.Size = new System.Drawing.Size(391, 23);
            this.BackupLocationTextBox.TabIndex = 15;
            // 
            // BackupLocationBrowseButton
            // 
            this.BackupLocationBrowseButton.Location = new System.Drawing.Point(409, 295);
            this.BackupLocationBrowseButton.Name = "BackupLocationBrowseButton";
            this.BackupLocationBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BackupLocationBrowseButton.TabIndex = 16;
            this.BackupLocationBrowseButton.Text = "Browse...";
            this.BackupLocationBrowseButton.UseVisualStyleBackColor = true;
            this.BackupLocationBrowseButton.Click += new System.EventHandler(this.BackupLocationBrowseButton_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 2);
            this.label1.TabIndex = 17;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 425);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackupLocationBrowseButton);
            this.Controls.Add(this.BackupLocationTextBox);
            this.Controls.Add(this.BackupLocationLabel);
            this.Controls.Add(this.ApplyChangesButton);
            this.Controls.Add(this.ApplyWarningLabel);
            this.Controls.Add(this.LatestManifestIDOpenSteamDBButton);
            this.Controls.Add(this.LatestManifestIDTextBox);
            this.Controls.Add(this.LatestManifestIDLabel);
            this.Controls.Add(this.DividerLabel1);
            this.Controls.Add(this.DownloadLinkLabel);
            this.Controls.Add(this.DownloadWarningLabel);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.IntroWarningLabel);
            this.Controls.Add(this.IntroInfoLabel);
            this.Controls.Add(this.GameLocationBrowseButton);
            this.Controls.Add(this.GameLocationTextBox);
            this.Controls.Add(this.GameLocationLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(512, 464);
            this.MinimumSize = new System.Drawing.Size(512, 464);
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.Text = "Blade and Sorcery Update Skipper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label GameLocationLabel;
        private TextBox GameLocationTextBox;
        private Button GameLocationBrowseButton;
        private Label IntroInfoLabel;
        private Label IntroWarningLabel;
        private LinkLabel linkLabel1;
        private Label DownloadWarningLabel;
        private LinkLabel DownloadLinkLabel;
        private Label DividerLabel1;
        private Label LatestManifestIDLabel;
        private TextBox LatestManifestIDTextBox;
        private Button LatestManifestIDOpenSteamDBButton;
        private Label ApplyWarningLabel;
        private Button ApplyChangesButton;
        private Label BackupLocationLabel;
        private TextBox BackupLocationTextBox;
        private Button BackupLocationBrowseButton;
        private Label label1;
    }
}