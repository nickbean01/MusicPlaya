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

        public Form1()
        {
            InitializeComponent();

            lib = new MusicLibrary("E:\\Music\\test folder", ".mp3", "E:\\Music\\LIBRARY.xml");

            lib.ReadLibrary();

            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {          
            IEnumerable<XElement> de =
                (from el in lib.GetXEl().Elements("Track").Elements("Artist")
                select el)
                .OrderBy(x => x.Value)
                .GroupBy(x => x.Value)                          
                .Select(x => x.First());

            ArtistListBox.Items.Clear();
            ArtistListBox.Items.Add("All Artists");

            foreach (XElement el in de)
            {
                ArtistListBox.Items.Add(el.Value);
            }
        }

        /* add albums depending on artist selected */
        public void PopulateAlbums(string artist)
        {
            IEnumerable<XElement> de = null;
            AlbumListBox.Items.Clear();
            AlbumListBox.Items.Add("All Albums");

            if (artist == null)
            {
                de =
                    (from el in lib.GetXEl().Elements("Track").Elements("Album")
                     select el)
                     .OrderBy(x => x.Value)
                     .GroupBy(x => x.Value)
                     .Select(x => x.First());
            }
            else
            {
                de =
                   (from el in lib.GetXEl().Elements("Track")
                   where (string)el.Element("Artist") == artist
                   select el.Element("Album"))
                   .OrderBy(x => Int32.Parse(x.Parent.Element("Year").Value))
                   .GroupBy(x => x.Value)
                   .Select(x => x.First());
            }
            foreach (XElement el in de)
            {
                AlbumListBox.Items.Add(el.Value);
            }
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks(string artist, string album)
        {
            IEnumerable<XElement> de = null;
            TrackListBox.Items.Clear();

            // all tracks alphabetically
            if ((artist == null) && (album == null))
            {
                de = lib.GetXEl().Elements("Track").Elements("Title")
                         .OrderBy(element => element.Value)
                         .ToList();                           
            }
            else if ((artist != null) && (album == null))   // specific artist
            {
                de =
                    (from el in lib.GetXEl().Elements("Track")
                     where (string)el.Element("Artist") == artist
                     select el.Element("Title"))
                     .OrderBy(x => Int32.Parse(x.Parent.Element("Year").Value))
                     .ThenBy(x => x.Parent.Element("Album").Value)
                     .ThenBy(x => Int32.Parse(x.Parent.Element("TrackNumber").Value));
            }
            else if ((artist == null) && (album != null))   // specific album
            {
                de =
                    (from el in lib.GetXEl().Elements("Track")
                     where (string)el.Element("Album") == album
                     select el.Element("Title"))
                     .OrderBy(x => Int32.Parse(x.Parent.Element("TrackNumber").Value));
            }
            else // specific artist and album
            {
                de =
                    (from el in lib.GetXEl().Elements("Track")
                     where (string)el.Element("Album") == album
                     where (string)el.Element("Artist") == artist
                     select el.Element("Title"))
                     .OrderBy(x => Int32.Parse(x.Parent.Element("TrackNumber").Value));
            }

            foreach (XElement el in de)
            {
                TrackListBox.Items.Add(el.Value);
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
    }
}
