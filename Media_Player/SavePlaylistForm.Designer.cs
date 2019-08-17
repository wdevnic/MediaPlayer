namespace Media_Player
{
    partial class SavePlaylistForm
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
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveInLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.saveAsLabel = new System.Windows.Forms.Label();
            this.libraryLabel = new System.Windows.Forms.Label();
            this.wplLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveButton.Location = new System.Drawing.Point(154, 150);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(253, 150);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveInLabel
            // 
            this.saveInLabel.AutoSize = true;
            this.saveInLabel.Location = new System.Drawing.Point(79, 39);
            this.saveInLabel.Name = "saveInLabel";
            this.saveInLabel.Size = new System.Drawing.Size(46, 13);
            this.saveInLabel.TabIndex = 2;
            this.saveInLabel.Text = "Save in:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(69, 71);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "File Name:";
            // 
            // saveAsLabel
            // 
            this.saveAsLabel.AutoSize = true;
            this.saveAsLabel.Location = new System.Drawing.Point(53, 103);
            this.saveAsLabel.Name = "saveAsLabel";
            this.saveAsLabel.Size = new System.Drawing.Size(73, 13);
            this.saveAsLabel.TabIndex = 4;
            this.saveAsLabel.Text = "Save As type:";
            // 
            // libraryLabel
            // 
            this.libraryLabel.AutoSize = true;
            this.libraryLabel.Location = new System.Drawing.Point(135, 39);
            this.libraryLabel.Name = "libraryLabel";
            this.libraryLabel.Size = new System.Drawing.Size(73, 13);
            this.libraryLabel.TabIndex = 5;
            this.libraryLabel.Text = "Playlist Library";
            // 
            // wplLabel
            // 
            this.wplLabel.AutoSize = true;
            this.wplLabel.Location = new System.Drawing.Point(135, 103);
            this.wplLabel.Name = "wplLabel";
            this.wplLabel.Size = new System.Drawing.Size(68, 13);
            this.wplLabel.TabIndex = 6;
            this.wplLabel.Text = "Playlist(*.wpl)";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(138, 71);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(135, 20);
            this.fileNameTextBox.TabIndex = 7;
            // 
            // SavePlaylistForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(356, 194);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.wplLabel);
            this.Controls.Add(this.libraryLabel);
            this.Controls.Add(this.saveAsLabel);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.saveInLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePlaylistForm";
            this.Text = "Save Playlist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label saveInLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label saveAsLabel;
        private System.Windows.Forms.Label libraryLabel;
        private System.Windows.Forms.Label wplLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
    }
}