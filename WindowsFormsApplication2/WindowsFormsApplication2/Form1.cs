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
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        MusicLibrary lib;
        List<string> TrackIDs;
        IEnumerable<XElement> TrackList;

        public Form1()
        {
            InitializeComponent();

            lib = new MusicLibrary("E:\\Music\\test folder", ".mp3", "E:\\Music\\LIBRARY.xml");
            TrackIDs = new List<string>();

            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {
            ArtistListBox.Items.Clear();
            ArtistListBox.Items.Add("All Artists");

            foreach (XElement el in lib.GetArtists())
            {
                ArtistListBox.Items.Add(el.Value);
            }
        }

        /* add albums depending on artist selected */
        public void PopulateAlbums(string artist)
        {
            AlbumListBox.Items.Clear();
            AlbumListBox.Items.Add("All Albums");

            foreach (XElement el in lib.GetAlbums(artist))
            {
                AlbumListBox.Items.Add(el.Value);
            }
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks(string artist, string album)
        {
            TrackListBox.Items.Clear();
            TrackIDs.Clear();
            TrackList = lib.GetTracks(artist, album);

            foreach (XElement el in TrackList)
            {
                TrackListBox.Items.Add(el.Element("Title").Value);
                TrackIDs.Add(el.Attribute("ID").Value);
            }            
        }

        private void ScanRoot_Click(object sender, EventArgs e)
        {
            lib.ScanDirectory(lib.GetRoot());
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
            
        }

        private void ClearLibButton_Click(object sender, EventArgs e)
        {
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

            if ((ArtistListBox.SelectedIndex >= 0) && (artist = ArtistListBox.SelectedItem.ToString()) == "All Artists")
                artist = null;

            PopulateTracks(artist, album);
        }

        private void TrackListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selection = TrackListBox.SelectedIndex;
            string ID = TrackIDs.ElementAt(TrackListBox.SelectedIndex);
            StatusLabel.Text = ID;

        }
    }
}
