﻿using System;
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

            lib = new MusicLibrary("E:\\Music\\test folder", ".mp3", "E:\\Music\\LIBRARY.xml");            

            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);

            LinkGrid();
        }

        public void LinkGrid()
        {
            try
            {
                xmlFile = XmlReader.Create("E:\\Music\\LIBRARY.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                if (ds.Tables.Count > 0)
                {
                    LibraryGrid.DataSource = ds.Tables[1];
                }
                xmlFile.Close();
                
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

        private void ScanRoot_Click(object sender, EventArgs e)
        {
            lib.ScanDirectory(lib.GetRoot());
            LinkGrid();
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
            
        }

        private void ClearLibButton_Click(object sender, EventArgs e)
        {
            xmlFile.Close();
            lib.ClearLibrary();
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
        }

        private void ArtistListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string artist;
            if((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists")
                artist = null;

            PopulateAlbums(artist);
            PopulateTracks(artist, null);
        }

        private void AlbumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string album = null;
            string artist = null;

            if ((AlbumListBox.SelectedIndex >= 0) && ((album = AlbumListBox.SelectedItem.ToString()) == "All Albums"))
                album = null;

            if ((ArtistListBox.SelectedIndex >= 0) && ((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists"))
                artist = null;

            PopulateTracks(artist, album);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int c = LibraryGrid.CurrentCell.ColumnIndex;
            if (c == 2) // album
            {
                MultiSort("Album ASC, TrackNumber ASC");
            }
            else if (c == 3) // artist
            {
                MultiSort("Artist ASC, Year DESC, TrackNumber ASC");
            }
            else if (c == 4) // tracknumber
            {
                MultiSort("TrackNumber ASC, Title ASC");
            }
            else if (c == 5) // year
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
        }

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
