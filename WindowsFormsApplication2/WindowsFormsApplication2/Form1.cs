using DGVColumnSelector;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    public partial class MusicPlayer : Form
    {
        MusicLibrary lib;        
        XElement currentTrack;
        XmlReader xmlFile;
        DataGridViewColumnSelector selector; 
        
        public MusicPlayer()
        {
            InitializeComponent();

            lib = new MusicLibrary(Properties.Settings.Default.MusicFolderPath, ".mp3", Properties.Settings.Default.LibraryFilePath);
            
            lib.PopulateArtists(ArtistListBox);
            lib.PopulateAlbums(AlbumListBox, null);
            lib.PopulateTracks(TrackListBox, null, null);

            LinkGrid();
            selector = new DataGridViewColumnSelector(LibraryGrid);
        }       

        /* links XML file data to LibraryGrid */
        public void LinkGrid()
        {
            try
            {
                if (File.Exists(lib.GetLibraryFilePath()))
                {
                    xmlFile = XmlReader.Create(lib.GetLibraryFilePath(), new XmlReaderSettings());
                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlFile);
                    if (ds.Tables.Count > 0)
                    {
                        LibraryGrid.DataSource = ds.Tables[1];
                    }
                    xmlFile.Close();
                    LibraryGrid.Columns[5].Visible = false;
                    LibraryGrid.Columns[6].Visible = false;
                    LibraryGrid.Columns[7].Visible = false;
                    LibraryGrid.Columns[8].Visible = false;
                }
                           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        /* rescans music directory */
        private void ScanRoot_Click(object sender, EventArgs e)
        {
            if (lib.GetRoot() == "")
            {
                lib.ChooseMusicFolder();
            }

            LibraryGrid.DataSource = null;
            LibraryGrid.Rows.Clear();

            lib.ScanDirectory(lib.GetRoot());
            LinkGrid();

            lib.PopulateArtists(ArtistListBox);
            lib.PopulateAlbums(AlbumListBox, null);
            lib.PopulateTracks(TrackListBox, null, null);

        }

        /* clears library file */
        private void ClearLibButton_Click(object sender, EventArgs e)
        {
            xmlFile.Close();
            const string message = "Are you sure that you would like to clear your library?";
            const string caption = "WARNING";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ... 
            if (result == DialogResult.Yes)
            {
                lib.ClearLibrary();

                lib.PopulateArtists(ArtistListBox);
                lib.PopulateAlbums(AlbumListBox, null);
                lib.PopulateTracks(TrackListBox, null, null);

                LibraryGrid.DataSource = null;
                LibraryGrid.Rows.Clear();
            }    
        }

        private void ArtistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string artist = null;
            if(ArtistListBox.SelectedIndex != -1)
                if((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists")
                    artist = null;

            lib.PopulateAlbums(AlbumListBox, artist);
            lib.PopulateTracks(TrackListBox, artist, null);
        }

        private void AlbumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string album = null;
            string artist = null;
            if (AlbumListBox.SelectedIndex != -1)
            {
                if ((AlbumListBox.SelectedIndex >= 0) && ((album = AlbumListBox.SelectedItem.ToString()) == "All Albums"))
                    album = null;

                if ((ArtistListBox.SelectedIndex >= 0) && ((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists"))
                    artist = null;
            }           
            lib.PopulateTracks(TrackListBox, artist, album);
        }

        /* make this a wrapper method to another in a new thread */
        private void TrackListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int boxIndex = TrackListBox.SelectedIndex;
            if (boxIndex != -1)
            {
                int rowIndex = -1;
                DataGridViewRow row = LibraryGrid.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["ID"].Value.ToString().Equals(lib.XmlTrackList.ElementAt(boxIndex).Attribute("ID").Value))
                    .First();

                rowIndex = row.Index;

                LibraryGrid.ClearSelection();
                LibraryGrid.Rows[rowIndex].Selected = true;
                LibraryGrid.FirstDisplayedScrollingRowIndex = LibraryGrid.SelectedRows[0].Index;
            }
        }

        private void SelectTrackButton_Click(object sender, EventArgs e)
        {
            int n = TrackListBox.SelectedIndex;
            if(n != -1)
            {
                currentTrack = lib.XmlTrackList.ElementAt(n);
                CurrentLabel.Text = "Now Playing: " + currentTrack.Element("Title").Value;
            }
            
        }        
    }
}
