namespace Media_Player
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lyricsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lyricsPanel = new System.Windows.Forms.Panel();
            this.webBrowserLyrics = new System.Windows.Forms.WebBrowser();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.mediaPlayPanel = new System.Windows.Forms.Panel();
            this.playListTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.playlistListBox = new System.Windows.Forms.ListBox();
            this.playListLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.lyricsTableLayoutPanel.SuspendLayout();
            this.lyricsPanel.SuspendLayout();
            this.mediaPlayPanel.SuspendLayout();
            this.playListTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(0, 0);
            this.MediaPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(715, 559);
            this.MediaPlayer.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.playlistToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(974, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.openPlaylistToolStripMenuItem});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newPlaylistToolStripMenuItem.Text = "New";
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open";
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.mainTableLayoutPanel.Controls.Add(this.lyricsTableLayoutPanel, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.mediaPlayPanel, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 24);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(974, 565);
            this.mainTableLayoutPanel.TabIndex = 3;
            // 
            // lyricsTableLayoutPanel
            // 
            this.lyricsTableLayoutPanel.ColumnCount = 1;
            this.lyricsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lyricsTableLayoutPanel.Controls.Add(this.lyricsPanel, 0, 0);
            this.lyricsTableLayoutPanel.Controls.Add(this.linkLabel, 0, 1);
            this.lyricsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyricsTableLayoutPanel.Location = new System.Drawing.Point(721, 3);
            this.lyricsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.lyricsTableLayoutPanel.Name = "lyricsTableLayoutPanel";
            this.lyricsTableLayoutPanel.RowCount = 2;
            this.lyricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lyricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.lyricsTableLayoutPanel.Size = new System.Drawing.Size(250, 559);
            this.lyricsTableLayoutPanel.TabIndex = 1;
            // 
            // lyricsPanel
            // 
            this.lyricsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lyricsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lyricsPanel.Controls.Add(this.webBrowserLyrics);
            this.lyricsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyricsPanel.Location = new System.Drawing.Point(0, 0);
            this.lyricsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.lyricsPanel.Name = "lyricsPanel";
            this.lyricsPanel.Size = new System.Drawing.Size(250, 515);
            this.lyricsPanel.TabIndex = 1;
            // 
            // webBrowserLyrics
            // 
            this.webBrowserLyrics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserLyrics.Location = new System.Drawing.Point(0, 0);
            this.webBrowserLyrics.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowserLyrics.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLyrics.Name = "webBrowserLyrics";
            this.webBrowserLyrics.ScriptErrorsSuppressed = true;
            this.webBrowserLyrics.Size = new System.Drawing.Size(248, 513);
            this.webBrowserLyrics.TabIndex = 0;
            this.webBrowserLyrics.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserLyrics_DocumentCompleted);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.linkLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel.Location = new System.Drawing.Point(0, 515);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(250, 44);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "www.lyrics.com";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // mediaPlayPanel
            // 
            this.mediaPlayPanel.Controls.Add(this.playListTableLayoutPanel);
            this.mediaPlayPanel.Controls.Add(this.MediaPlayer);
            this.mediaPlayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayPanel.Location = new System.Drawing.Point(3, 3);
            this.mediaPlayPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mediaPlayPanel.Name = "mediaPlayPanel";
            this.mediaPlayPanel.Size = new System.Drawing.Size(715, 559);
            this.mediaPlayPanel.TabIndex = 3;
            // 
            // playListTableLayoutPanel
            // 
            this.playListTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playListTableLayoutPanel.BackColor = System.Drawing.SystemColors.Menu;
            this.playListTableLayoutPanel.ColumnCount = 1;
            this.playListTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.playListTableLayoutPanel.Controls.Add(this.playListLabel, 0, 0);
            this.playListTableLayoutPanel.Controls.Add(this.playlistListBox, 0, 1);
            this.playListTableLayoutPanel.Location = new System.Drawing.Point(551, -2);
            this.playListTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.playListTableLayoutPanel.Name = "playListTableLayoutPanel";
            this.playListTableLayoutPanel.RowCount = 2;
            this.playListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.061895F));
            this.playListTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.9381F));
            this.playListTableLayoutPanel.Size = new System.Drawing.Size(168, 516);
            this.playListTableLayoutPanel.TabIndex = 3;
            // 
            // playlistListBox
            // 
            this.playlistListBox.BackColor = System.Drawing.SystemColors.Menu;
            this.playlistListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlistListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistListBox.FormattingEnabled = true;
            this.playlistListBox.IntegralHeight = false;
            this.playlistListBox.Location = new System.Drawing.Point(0, 20);
            this.playlistListBox.Margin = new System.Windows.Forms.Padding(0);
            this.playlistListBox.Name = "playlistListBox";
            this.playlistListBox.Size = new System.Drawing.Size(168, 496);
            this.playlistListBox.TabIndex = 1;
            // 
            // playListLabel
            // 
            this.playListLabel.AutoSize = true;
            this.playListLabel.BackColor = System.Drawing.SystemColors.Menu;
            this.playListLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playListLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.playListLabel.Location = new System.Drawing.Point(0, 3);
            this.playListLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.playListLabel.Name = "playListLabel";
            this.playListLabel.Size = new System.Drawing.Size(168, 17);
            this.playListLabel.TabIndex = 2;
            this.playListLabel.Text = "Drag Music below";
            this.playListLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(974, 589);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MP3 Player";
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.lyricsTableLayoutPanel.ResumeLayout(false);
            this.lyricsTableLayoutPanel.PerformLayout();
            this.lyricsPanel.ResumeLayout(false);
            this.mediaPlayPanel.ResumeLayout(false);
            this.playListTableLayoutPanel.ResumeLayout(false);
            this.playListTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel lyricsTableLayoutPanel;
        private System.Windows.Forms.Panel lyricsPanel;
        private System.Windows.Forms.WebBrowser webBrowserLyrics;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.ListBox playlistListBox;
        private System.Windows.Forms.Panel mediaPlayPanel;
        private System.Windows.Forms.TableLayoutPanel playListTableLayoutPanel;
        private System.Windows.Forms.Label playListLabel;
    }
}

