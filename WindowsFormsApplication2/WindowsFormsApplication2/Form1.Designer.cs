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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClearLibButton = new System.Windows.Forms.Button();
            this.ScanRoot = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ArtistListBox = new System.Windows.Forms.ListBox();
            this.AlbumListBox = new System.Windows.Forms.ListBox();
            this.TrackListBox = new System.Windows.Forms.ListBox();
            this.NextListBox = new System.Windows.Forms.ListBox();
            this.LibraryGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ClearLibButton);
            this.panel1.Controls.Add(this.ScanRoot);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 472);
            this.panel1.TabIndex = 1;
            // 
            // ClearLibButton
            // 
            this.ClearLibButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLibButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ClearLibButton.Location = new System.Drawing.Point(830, 32);
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
            this.ScanRoot.Location = new System.Drawing.Point(830, 3);
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
            // ArtistListBox
            // 
            this.ArtistListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ArtistListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistListBox.FormattingEnabled = true;
            this.ArtistListBox.Location = new System.Drawing.Point(3, 5);
            this.ArtistListBox.Name = "ArtistListBox";
            this.ArtistListBox.Size = new System.Drawing.Size(185, 238);
            this.ArtistListBox.TabIndex = 2;
            this.ArtistListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistListBox_SelectedIndexChanged);
            // 
            // AlbumListBox
            // 
            this.AlbumListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AlbumListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumListBox.FormattingEnabled = true;
            this.AlbumListBox.Location = new System.Drawing.Point(194, 5);
            this.AlbumListBox.Name = "AlbumListBox";
            this.AlbumListBox.Size = new System.Drawing.Size(185, 238);
            this.AlbumListBox.TabIndex = 3;
            this.AlbumListBox.SelectedIndexChanged += new System.EventHandler(this.AlbumListBox_SelectedIndexChanged);
            // 
            // TrackListBox
            // 
            this.TrackListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TrackListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackListBox.FormattingEnabled = true;
            this.TrackListBox.Location = new System.Drawing.Point(385, 5);
            this.TrackListBox.Name = "TrackListBox";
            this.TrackListBox.Size = new System.Drawing.Size(235, 238);
            this.TrackListBox.TabIndex = 4;
            this.TrackListBox.SelectedIndexChanged += new System.EventHandler(this.TrackListBox_SelectedIndexChanged);
            // 
            // NextListBox
            // 
            this.NextListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NextListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextListBox.FormattingEnabled = true;
            this.NextListBox.Location = new System.Drawing.Point(623, 5);
            this.NextListBox.Name = "NextListBox";
            this.NextListBox.Size = new System.Drawing.Size(285, 238);
            this.NextListBox.TabIndex = 5;
            // 
            // LibraryGrid
            // 
            this.LibraryGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LibraryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LibraryGrid.Location = new System.Drawing.Point(12, 12);
            this.LibraryGrid.Name = "LibraryGrid";
            this.LibraryGrid.Size = new System.Drawing.Size(824, 472);
            this.LibraryGrid.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ArtistListBox);
            this.panel2.Controls.Add(this.AlbumListBox);
            this.panel2.Controls.Add(this.NextListBox);
            this.panel2.Controls.Add(this.TrackListBox);
            this.panel2.Location = new System.Drawing.Point(12, 493);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(911, 255);
            this.panel2.TabIndex = 8;
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 760);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LibraryGrid);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MusicPlayer";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox AlbumListBox;
        private System.Windows.Forms.ListBox TrackListBox;
        private System.Windows.Forms.Button ScanRoot;
        private System.Windows.Forms.Button ClearLibButton;
        private System.Windows.Forms.ListBox NextListBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView LibraryGrid;
        private System.Windows.Forms.ListBox ArtistListBox;
        private System.Windows.Forms.Panel panel2;
    }
}

