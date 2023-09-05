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
            GameLocationLabel = new Label();
            GameLocationTextBox = new TextBox();
            GameLocationBrowseButton = new Button();
            IntroInfoLabel = new Label();
            IntroWarningLabel = new Label();
            linkLabel1 = new LinkLabel();
            DownloadWarningLabel = new Label();
            DownloadLinkLabel = new LinkLabel();
            DividerLabel1 = new Label();
            LatestManifestIDLabel = new Label();
            LatestManifestIDTextBox = new TextBox();
            LatestManifestIDOpenSteamDBButton = new Button();
            ApplyWarningLabel = new Label();
            ApplyChangesButton = new Button();
            SuspendLayout();
            // 
            // GameLocationLabel
            // 
            GameLocationLabel.AutoSize = true;
            GameLocationLabel.Location = new Point(12, 171);
            GameLocationLabel.Name = "GameLocationLabel";
            GameLocationLabel.Size = new Size(199, 15);
            GameLocationLabel.TabIndex = 0;
            GameLocationLabel.Text = "Blade and Sorcery installation folder:";
            // 
            // GameLocationTextBox
            // 
            GameLocationTextBox.Location = new Point(12, 189);
            GameLocationTextBox.Name = "GameLocationTextBox";
            GameLocationTextBox.PlaceholderText = "Click \"Browse...\" to select installation location...";
            GameLocationTextBox.Size = new Size(391, 23);
            GameLocationTextBox.TabIndex = 1;
            // 
            // GameLocationBrowseButton
            // 
            GameLocationBrowseButton.Location = new Point(409, 189);
            GameLocationBrowseButton.Name = "GameLocationBrowseButton";
            GameLocationBrowseButton.Size = new Size(75, 23);
            GameLocationBrowseButton.TabIndex = 2;
            GameLocationBrowseButton.Text = "Browse...";
            GameLocationBrowseButton.UseVisualStyleBackColor = true;
            GameLocationBrowseButton.Click += GameLocationBrowseButton_Click;
            // 
            // IntroInfoLabel
            // 
            IntroInfoLabel.AutoSize = true;
            IntroInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            IntroInfoLabel.Location = new Point(12, 49);
            IntroInfoLabel.Name = "IntroInfoLabel";
            IntroInfoLabel.Size = new Size(463, 60);
            IntroInfoLabel.TabIndex = 3;
            IntroInfoLabel.Text = resources.GetString("IntroInfoLabel.Text");
            // 
            // IntroWarningLabel
            // 
            IntroWarningLabel.AutoSize = true;
            IntroWarningLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            IntroWarningLabel.Location = new Point(12, 9);
            IntroWarningLabel.Name = "IntroWarningLabel";
            IntroWarningLabel.Size = new Size(437, 30);
            IntroWarningLabel.TabIndex = 4;
            IntroWarningLabel.Text = "Note: This tool is only compatible with Steam-based installations of Blade and \r\nSorcery. Run this tool at your own risk.";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(330, 171);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 15);
            linkLabel1.TabIndex = 5;
            // 
            // DownloadWarningLabel
            // 
            DownloadWarningLabel.AutoSize = true;
            DownloadWarningLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DownloadWarningLabel.Location = new Point(12, 118);
            DownloadWarningLabel.Name = "DownloadWarningLabel";
            DownloadWarningLabel.Size = new Size(358, 15);
            DownloadWarningLabel.TabIndex = 6;
            DownloadWarningLabel.Text = "Make sure you downloaded this tool from its official repository:";
            // 
            // DownloadLinkLabel
            // 
            DownloadLinkLabel.AutoSize = true;
            DownloadLinkLabel.Location = new Point(12, 133);
            DownloadLinkLabel.Name = "DownloadLinkLabel";
            DownloadLinkLabel.Size = new Size(326, 15);
            DownloadLinkLabel.TabIndex = 7;
            DownloadLinkLabel.TabStop = true;
            DownloadLinkLabel.Text = "https://github.com/sulliops/BladeAndSorceryUpdateSkipper";
            DownloadLinkLabel.LinkClicked += DownloadLinkLabel_LinkClicked;
            // 
            // DividerLabel1
            // 
            DividerLabel1.BorderStyle = BorderStyle.Fixed3D;
            DividerLabel1.Location = new Point(12, 160);
            DividerLabel1.Name = "DividerLabel1";
            DividerLabel1.Size = new Size(472, 2);
            DividerLabel1.TabIndex = 8;
            // 
            // LatestManifestIDLabel
            // 
            LatestManifestIDLabel.AutoSize = true;
            LatestManifestIDLabel.Location = new Point(12, 224);
            LatestManifestIDLabel.Name = "LatestManifestIDLabel";
            LatestManifestIDLabel.Size = new Size(201, 15);
            LatestManifestIDLabel.TabIndex = 9;
            LatestManifestIDLabel.Text = "Latest Blade and Sorcery manifest ID:";
            // 
            // LatestManifestIDTextBox
            // 
            LatestManifestIDTextBox.Location = new Point(12, 242);
            LatestManifestIDTextBox.Name = "LatestManifestIDTextBox";
            LatestManifestIDTextBox.PlaceholderText = "Click \"Open SteamDB...\" and copy/paste the latest manifest ID...";
            LatestManifestIDTextBox.Size = new Size(358, 23);
            LatestManifestIDTextBox.TabIndex = 10;
            // 
            // LatestManifestIDOpenSteamDBButton
            // 
            LatestManifestIDOpenSteamDBButton.Location = new Point(376, 242);
            LatestManifestIDOpenSteamDBButton.Name = "LatestManifestIDOpenSteamDBButton";
            LatestManifestIDOpenSteamDBButton.Size = new Size(108, 23);
            LatestManifestIDOpenSteamDBButton.TabIndex = 11;
            LatestManifestIDOpenSteamDBButton.Text = "Open SteamDB";
            LatestManifestIDOpenSteamDBButton.UseVisualStyleBackColor = true;
            LatestManifestIDOpenSteamDBButton.Click += LatestManifestIDOpenSteamDBButton_Click;
            // 
            // ApplyWarningLabel
            // 
            ApplyWarningLabel.AutoSize = true;
            ApplyWarningLabel.Location = new Point(12, 277);
            ApplyWarningLabel.Name = "ApplyWarningLabel";
            ApplyWarningLabel.Size = new Size(458, 45);
            ApplyWarningLabel.TabIndex = 12;
            ApplyWarningLabel.Text = "Click the \"Apply Changes\" button below to apply changes to Blade and Sorcery's app \r\nmanifest. If Steam is currently running, it will be exited via the Steam console before \r\nchanges are applied.";
            // 
            // ApplyChangesButton
            // 
            ApplyChangesButton.Location = new Point(12, 325);
            ApplyChangesButton.Name = "ApplyChangesButton";
            ApplyChangesButton.Size = new Size(472, 23);
            ApplyChangesButton.TabIndex = 13;
            ApplyChangesButton.Text = "Apply Changes";
            ApplyChangesButton.UseVisualStyleBackColor = true;
            ApplyChangesButton.Click += ApplyChangesButton_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 361);
            Controls.Add(ApplyChangesButton);
            Controls.Add(ApplyWarningLabel);
            Controls.Add(LatestManifestIDOpenSteamDBButton);
            Controls.Add(LatestManifestIDTextBox);
            Controls.Add(LatestManifestIDLabel);
            Controls.Add(DividerLabel1);
            Controls.Add(DownloadLinkLabel);
            Controls.Add(DownloadWarningLabel);
            Controls.Add(linkLabel1);
            Controls.Add(IntroWarningLabel);
            Controls.Add(IntroInfoLabel);
            Controls.Add(GameLocationBrowseButton);
            Controls.Add(GameLocationTextBox);
            Controls.Add(GameLocationLabel);
            MaximizeBox = false;
            MaximumSize = new Size(512, 400);
            MinimumSize = new Size(512, 400);
            Name = "MainWindow";
            ShowIcon = false;
            Text = "Blade and Sorcery Update Skipper";
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
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
    }
}