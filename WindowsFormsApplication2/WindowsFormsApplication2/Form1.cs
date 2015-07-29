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
        IEnumerable<XElement> XmlTrackList;    // collection of Track elements in TrackListBox
        XElement currentTrack;

        public Form1()
        {
            InitializeComponent();

            lib = new MusicLibrary("E:\\Music\\test folder", ".mp3", "E:\\Music\\LIBRARY.xml");

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

            if ((ArtistListBox.SelectedIndex >= 0) && ((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists"))
                artist = null;

            PopulateTracks(artist, album);
        }

        private void TrackListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selection;
            if ((selection = TrackListBox.SelectedIndex) != -1)
                currentTrack = XmlTrackList.ElementAt(selection);

        }

        /* make a class for the Up-Next listbox with (title - Artist), and value as the path */
    }
}
