using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    public partial class MusicPlayer : Form
    {
        MusicLibrary lib;
        IEnumerable<XElement> XmlTrackList;    // collection of Track elements in TrackListBox
        XElement currentTrack;
        XmlReader xmlFile;
        

        public MusicPlayer()
        {
            InitializeComponent();
            CheckSettings();

            lib = new MusicLibrary(Properties.Settings.Default.MusicFolderPath, ".mp3", Properties.Settings.Default.LibraryFilePath);            

            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);

            LinkGrid();
        }

        /* checks setting variables for paths */
        private void CheckSettings()
        {
            if (Properties.Settings.Default.MusicFolderPath == "")
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.MusicFolderPath = fbd.SelectedPath;
                    Properties.Settings.Default.LibraryFilePath = fbd.SelectedPath + "\\LIBRARY.xml";
                    Properties.Settings.Default.Save();
                }
            }            
        }

        /* links XML file data to LibraryGrid */
        public void LinkGrid()
        {
            try
            {
                xmlFile = XmlReader.Create(Properties.Settings.Default.LibraryFilePath, new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                if (ds.Tables.Count > 0)
                {
                    LibraryGrid.DataSource = ds.Tables[1];
                }
                xmlFile.Close();
                LibraryGrid.Columns[6].Visible = false;
                LibraryGrid.Columns[7].Visible = false;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {
            ArtistListBox.Items.Clear();
            ArtistListBox.Items.Add("All Artists");

            foreach (XElement el in lib.GetArtists())
                ArtistListBox.Items.Add(el.Value);
        }

        /* add albums depending on artist selected */
        public void PopulateAlbums(string artist)
        {
            AlbumListBox.Items.Clear();
            AlbumListBox.Items.Add("All Albums");

            foreach (XElement el in lib.GetAlbums(artist))
                AlbumListBox.Items.Add(el.Value);
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks(string artist, string album)
        {
            TrackListBox.Items.Clear();
            TrackListBox.ClearSelected();          
            XmlTrackList = lib.GetTracks(artist, album);

            foreach (XElement el in XmlTrackList)
            {
                TrackListBox.Items.Add(el.Element("Title").Value);
            }
        }

        /* rescans music directory */
        private void ScanRoot_Click(object sender, EventArgs e)
        {
            lib.ScanDirectory(lib.GetRoot());
            LinkGrid();
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
            
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
                PopulateArtists();
                PopulateAlbums(null);
                PopulateTracks(null, null);
            }    
        }

        private void ArtistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string artist = null;
            if(ArtistListBox.SelectedIndex != -1)
                if((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists")
                    artist = null;

            PopulateAlbums(artist);
            PopulateTracks(artist, null);
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
            PopulateTracks(artist, album);
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
                    .Where(r => r.Cells["ID"].Value.ToString().Equals(XmlTrackList.ElementAt(boxIndex).Attribute("ID").Value))
                    .First();

                rowIndex = row.Index;

                LibraryGrid.ClearSelection();
                LibraryGrid.Rows[rowIndex].Selected = true;
                LibraryGrid.FirstDisplayedScrollingRowIndex = LibraryGrid.SelectedRows[0].Index;
            }
        }

        /*private void LibraryGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int c = LibraryGrid.CurrentCell.ColumnIndex;

            // gotta change this cause hard coded as fuuuuck
            if (c == 1) // album
            {
                MessageBox.Show("ALBUM");
                MultiSort("Album ASC, TrackNumber ASC");
            }
            else if (c == 2) // artist
            {
                MessageBox.Show("ARTIST");
                MultiSort("Artist ASC, Year DESC, Album ASC, TrackNumber ASC");
            }
            else if (c == 3) // tracknumber
            {
                MultiSort("TrackNumber ASC, Title ASC");
            }
            else if (c == 4) // year
            {
                MultiSort("Year ASC, Album ASC, TrackNumber ASC");
            }
        }

        private void MultiSort(string query)
        {
            DataTable dt = (DataTable)LibraryGrid.DataSource;
            DataView view = new DataView(dt);
            view.Sort = query;
            LibraryGrid.DataSource = view;
        }*/

        private void SelectTrackButton_Click(object sender, EventArgs e)
        {
            int n = TrackListBox.SelectedIndex;
            if(n != -1)
            {
                currentTrack = XmlTrackList.ElementAt(n);
                CurrentLabel.Text = "Now Playing: " + currentTrack.Element("Title").Value;
            }
            
        }        

        /*public event System.EventHandler CurrentTrackChanged;

        protected virtual void OnCurrentTrackChanged()
        {

        }

        public XElement CurrentTrack
        {
            get
            {
                return currentTrack;
            }
            set
            {
                currentTrack = value;
                OnCurrentTrackChanged();
            }
        }*/

        /* make a class for the Up-Next listbox with (title - Artist), and value as the path */
    }
}
