namespace WindowsFormsApplication2
{
    partial class MusicPlayer
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
            this.ClearLibButton = new System.Windows.Forms.Button();
            this.ScanRoot = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.LibraryGrid = new System.Windows.Forms.DataGridView();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.SelectTrackButton = new System.Windows.Forms.Button();
            this.TrackListBox = new System.Windows.Forms.ListBox();
            this.NextListBox = new System.Windows.Forms.ListBox();
            this.AlbumListBox = new System.Windows.Forms.ListBox();
            this.ArtistListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearLibButton
            // 
            this.ClearLibButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLibButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ClearLibButton.Location = new System.Drawing.Point(612, 12);
            this.ClearLibButton.Name = "ClearLibButton";
            this.ClearLibButton.Size = new System.Drawing.Size(75, 23);
            this.ClearLibButton.TabIndex = 6;
            this.ClearLibButton.Text = "Clear Library";
            this.ClearLibButton.UseVisualStyleBackColor = true;
            this.ClearLibButton.Click += new System.EventHandler(this.ClearLibButton_Click);
            // 
            // ScanRoot
            // 
            this.ScanRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanRoot.Location = new System.Drawing.Point(693, 12);
            this.ScanRoot.Name = "ScanRoot";
            this.ScanRoot.Size = new System.Drawing.Size(75, 23);
            this.ScanRoot.TabIndex = 4;
            this.ScanRoot.Text = "Scan Root";
            this.ScanRoot.UseVisualStyleBackColor = true;
            this.ScanRoot.Click += new System.EventHandler(this.ScanRoot_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(150, 100);
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Size = new System.Drawing.Size(150, 100);
            this.splitContainer3.TabIndex = 0;
            // 
            // LibraryGrid
            // 
            this.LibraryGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.LibraryGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LibraryGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.LibraryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LibraryGrid.Location = new System.Drawing.Point(12, 41);
            this.LibraryGrid.Name = "LibraryGrid";
            this.LibraryGrid.Size = new System.Drawing.Size(760, 446);
            this.LibraryGrid.TabIndex = 7;
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.AutoSize = true;
            this.CurrentLabel.Location = new System.Drawing.Point(107, 13);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(32, 13);
            this.CurrentLabel.TabIndex = 9;
            this.CurrentLabel.Text = "hway";
            // 
            // SelectTrackButton
            // 
            this.SelectTrackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectTrackButton.Location = new System.Drawing.Point(531, 12);
            this.SelectTrackButton.Name = "SelectTrackButton";
            this.SelectTrackButton.Size = new System.Drawing.Size(75, 23);
            this.SelectTrackButton.TabIndex = 10;
            this.SelectTrackButton.Text = "Select";
            this.SelectTrackButton.UseVisualStyleBackColor = true;
            this.SelectTrackButton.Click += new System.EventHandler(this.SelectTrackButton_Click);
            // 
            // TrackListBox
            // 
            this.TrackListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TrackListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackListBox.FormattingEnabled = true;
            this.TrackListBox.Location = new System.Drawing.Point(394, 493);
            this.TrackListBox.Name = "TrackListBox";
            this.TrackListBox.Size = new System.Drawing.Size(184, 30);
            this.TrackListBox.TabIndex = 4;
            // 
            // NextListBox
            // 
            this.NextListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextListBox.FormattingEnabled = true;
            this.NextListBox.Location = new System.Drawing.Point(584, 493);
            this.NextListBox.Name = "NextListBox";
            this.NextListBox.Size = new System.Drawing.Size(184, 30);
            this.NextListBox.TabIndex = 5;
            // 
            // AlbumListBox
            // 
            this.AlbumListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AlbumListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumListBox.FormattingEnabled = true;
            this.AlbumListBox.Location = new System.Drawing.Point(203, 493);
            this.AlbumListBox.Name = "AlbumListBox";
            this.AlbumListBox.Size = new System.Drawing.Size(184, 30);
            this.AlbumListBox.TabIndex = 3;
            this.AlbumListBox.SelectedIndexChanged += new System.EventHandler(this.AlbumListBox_SelectedIndexChanged);
            // 
            // ArtistListBox
            // 
            this.ArtistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ArtistListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistListBox.FormattingEnabled = true;
            this.ArtistListBox.Location = new System.Drawing.Point(12, 493);
            this.ArtistListBox.Name = "ArtistListBox";
            this.ArtistListBox.Size = new System.Drawing.Size(184, 30);
            this.ArtistListBox.TabIndex = 2;
            this.ArtistListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistListBox_SelectedIndexChanged);
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.NextListBox);
            this.Controls.Add(this.ArtistListBox);
            this.Controls.Add(this.TrackListBox);
            this.Controls.Add(this.SelectTrackButton);
            this.Controls.Add(this.AlbumListBox);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.ClearLibButton);
            this.Controls.Add(this.ScanRoot);
            this.Controls.Add(this.LibraryGrid);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MusicPlayer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ScanRoot;
        private System.Windows.Forms.Button ClearLibButton;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView LibraryGrid;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Button SelectTrackButton;
        private System.Windows.Forms.ListBox TrackListBox;
        private System.Windows.Forms.ListBox NextListBox;
        private System.Windows.Forms.ListBox AlbumListBox;
        private System.Windows.Forms.ListBox ArtistListBox;
    }
}

