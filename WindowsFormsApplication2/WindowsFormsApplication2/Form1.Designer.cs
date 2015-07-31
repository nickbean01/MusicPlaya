using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.BigSplitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.LeftBottomContainer = new System.Windows.Forms.SplitContainer();
            this.RightBottomContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BigSplitContainer)).BeginInit();
            this.BigSplitContainer.Panel1.SuspendLayout();
            this.BigSplitContainer.Panel2.SuspendLayout();
            this.BigSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftBottomContainer)).BeginInit();
            this.LeftBottomContainer.Panel1.SuspendLayout();
            this.LeftBottomContainer.Panel2.SuspendLayout();
            this.LeftBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightBottomContainer)).BeginInit();
            this.RightBottomContainer.Panel1.SuspendLayout();
            this.RightBottomContainer.Panel2.SuspendLayout();
            this.RightBottomContainer.SuspendLayout();
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
            this.LibraryGrid.AllowUserToAddRows = false;
            this.LibraryGrid.AllowUserToDeleteRows = false;
            this.LibraryGrid.AllowUserToOrderColumns = true;
            this.LibraryGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.LibraryGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LibraryGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LibraryGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LibraryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LibraryGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LibraryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LibraryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LibraryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LibraryGrid.Location = new System.Drawing.Point(0, 0);
            this.LibraryGrid.Name = "LibraryGrid";
            this.LibraryGrid.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.LibraryGrid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.LibraryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LibraryGrid.Size = new System.Drawing.Size(760, 308);
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
            this.SelectTrackButton.Location = new System.Drawing.Point(693, 41);
            this.SelectTrackButton.Name = "SelectTrackButton";
            this.SelectTrackButton.Size = new System.Drawing.Size(75, 23);
            this.SelectTrackButton.TabIndex = 10;
            this.SelectTrackButton.Text = "Select";
            this.SelectTrackButton.UseVisualStyleBackColor = true;
            this.SelectTrackButton.Click += new System.EventHandler(this.SelectTrackButton_Click);
            // 
            // TrackListBox
            // 
            this.TrackListBox.BackColor = System.Drawing.Color.DimGray;
            this.TrackListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrackListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TrackListBox.FormattingEnabled = true;
            this.TrackListBox.Location = new System.Drawing.Point(0, 0);
            this.TrackListBox.Name = "TrackListBox";
            this.TrackListBox.Size = new System.Drawing.Size(125, 167);
            this.TrackListBox.TabIndex = 4;
            this.TrackListBox.SelectedIndexChanged += new System.EventHandler(this.TrackListBox_SelectedIndexChanged);
            // 
            // NextListBox
            // 
            this.NextListBox.BackColor = System.Drawing.Color.DimGray;
            this.NextListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NextListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NextListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NextListBox.FormattingEnabled = true;
            this.NextListBox.Location = new System.Drawing.Point(0, 0);
            this.NextListBox.Name = "NextListBox";
            this.NextListBox.Size = new System.Drawing.Size(248, 167);
            this.NextListBox.TabIndex = 5;
            // 
            // AlbumListBox
            // 
            this.AlbumListBox.BackColor = System.Drawing.Color.DimGray;
            this.AlbumListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlbumListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbumListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AlbumListBox.FormattingEnabled = true;
            this.AlbumListBox.Location = new System.Drawing.Point(0, 0);
            this.AlbumListBox.Name = "AlbumListBox";
            this.AlbumListBox.Size = new System.Drawing.Size(183, 167);
            this.AlbumListBox.TabIndex = 3;
            this.AlbumListBox.SelectedIndexChanged += new System.EventHandler(this.AlbumListBox_SelectedIndexChanged);
            // 
            // ArtistListBox
            // 
            this.ArtistListBox.BackColor = System.Drawing.Color.DimGray;
            this.ArtistListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArtistListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArtistListBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ArtistListBox.FormattingEnabled = true;
            this.ArtistListBox.Location = new System.Drawing.Point(0, 0);
            this.ArtistListBox.Name = "ArtistListBox";
            this.ArtistListBox.Size = new System.Drawing.Size(192, 167);
            this.ArtistListBox.TabIndex = 2;
            this.ArtistListBox.SelectedIndexChanged += new System.EventHandler(this.ArtistListBox_SelectedIndexChanged);
            // 
            // BigSplitContainer
            // 
            this.BigSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BigSplitContainer.Location = new System.Drawing.Point(12, 70);
            this.BigSplitContainer.Name = "BigSplitContainer";
            this.BigSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BigSplitContainer.Panel1
            // 
            this.BigSplitContainer.Panel1.Controls.Add(this.LibraryGrid);
            // 
            // BigSplitContainer.Panel2
            // 
            this.BigSplitContainer.Panel2.Controls.Add(this.splitContainer4);
            this.BigSplitContainer.Size = new System.Drawing.Size(760, 479);
            this.BigSplitContainer.SplitterDistance = 308;
            this.BigSplitContainer.TabIndex = 11;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.LeftBottomContainer);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.RightBottomContainer);
            this.splitContainer4.Size = new System.Drawing.Size(760, 167);
            this.splitContainer4.SplitterDistance = 379;
            this.splitContainer4.TabIndex = 0;
            // 
            // LeftBottomContainer
            // 
            this.LeftBottomContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftBottomContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftBottomContainer.Name = "LeftBottomContainer";
            // 
            // LeftBottomContainer.Panel1
            // 
            this.LeftBottomContainer.Panel1.Controls.Add(this.ArtistListBox);
            // 
            // LeftBottomContainer.Panel2
            // 
            this.LeftBottomContainer.Panel2.Controls.Add(this.AlbumListBox);
            this.LeftBottomContainer.Size = new System.Drawing.Size(379, 167);
            this.LeftBottomContainer.SplitterDistance = 192;
            this.LeftBottomContainer.TabIndex = 0;
            // 
            // RightBottomContainer
            // 
            this.RightBottomContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomContainer.Location = new System.Drawing.Point(0, 0);
            this.RightBottomContainer.Name = "RightBottomContainer";
            // 
            // RightBottomContainer.Panel1
            // 
            this.RightBottomContainer.Panel1.Controls.Add(this.TrackListBox);
            // 
            // RightBottomContainer.Panel2
            // 
            this.RightBottomContainer.Panel2.Controls.Add(this.NextListBox);
            this.RightBottomContainer.Size = new System.Drawing.Size(377, 167);
            this.RightBottomContainer.SplitterDistance = 125;
            this.RightBottomContainer.TabIndex = 0;
            // 
            // MusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.BigSplitContainer);
            this.Controls.Add(this.SelectTrackButton);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.ClearLibButton);
            this.Controls.Add(this.ScanRoot);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MusicPlayer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LibraryGrid)).EndInit();
            this.BigSplitContainer.Panel1.ResumeLayout(false);
            this.BigSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BigSplitContainer)).EndInit();
            this.BigSplitContainer.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.LeftBottomContainer.Panel1.ResumeLayout(false);
            this.LeftBottomContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftBottomContainer)).EndInit();
            this.LeftBottomContainer.ResumeLayout(false);
            this.RightBottomContainer.Panel1.ResumeLayout(false);
            this.RightBottomContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightBottomContainer)).EndInit();
            this.RightBottomContainer.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer BigSplitContainer;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer LeftBottomContainer;
        private System.Windows.Forms.SplitContainer RightBottomContainer;
    }
}

