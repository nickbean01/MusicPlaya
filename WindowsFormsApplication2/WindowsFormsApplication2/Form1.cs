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
        XElement root;
        string RootDirectory = "E:\\Music\\Test Folder";
        string FileType = ".mp3";
        string xmlPath = "E:\\Music\\LIBRARY.xml";       

        public Form1()
        {
            InitializeComponent();
            ReadLibrary();
        }

        private void ClearLibrary()
        {
            root = new XElement("Library",
                new XAttribute("Count", "0")
                );
            root.Save(xmlPath);
        }

        /* reads from XML library file */
        public void ReadLibrary()
        {
            // creates XML file if it doesn't already exist
            if (!File.Exists(xmlPath))
            {
                CreateLibrary();
            }
            else
            {
                root = XElement.Load(xmlPath);
                PopulateArtists();
                PopulateAlbums(null);
                PopulateTracks(null, null);
            }
        }        

        /* creates XML library file */
        public void CreateLibrary()
        {
            if (File.Exists(xmlPath))
            {
                // you goofed, should never happen
                return;
            }

            root = new XElement("Library",
                new XAttribute("Count", "0")
                );
            root.Save(xmlPath);

            ScanDirectory(RootDirectory);
        }

        /* scans given root directory and adds missing files to XML library */
        public void ScanDirectory(String TargetDirectory)
        {
            string[] FileEntries;
            

            if (!Directory.Exists(TargetDirectory))
            {
                System.Diagnostics.Debug.WriteLine(TargetDirectory + " does not exist.");
                return;
            }

            FileEntries = Directory.GetFileSystemEntries(TargetDirectory);
            foreach (string TargetPath in FileEntries)
            {
                if (File.Exists(TargetPath))            // make sure file exists
                {
                    if (TargetPath.EndsWith(FileType))  // check if mp3
                    {
                        // if path is not in XML file, insert
                        if (!CheckPathExists(TargetPath))
                        {
                            InsertTrack(TargetPath);
                            
                        }                                            
                    }
                }
                else if (Directory.Exists(TargetPath))
                {
                    ScanDirectory(TargetPath);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(TargetPath + " does not exist or cannot be opened.");
                }
            }
            root.Save(xmlPath);       
            return;
        }

        /* checks if a track with the given path already exists in the library */
        private Boolean CheckPathExists(string TargetPath)
        {
            IEnumerable<XElement> de =
                from el in root.Descendants("Path")
                select el;
            foreach (XElement el in de)
            {
                if(String.Compare(el.Value, TargetPath) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /* inserts new track to XML file */
        /* pulls info from metadata (eventually) */
        private void InsertTrack(string TargetPath)
        {
            XAttribute att;
            string title;
            string album;
            string artist;
            int trackNum;
            int num;
            int year;

            // check for nulls on these and fill in dummy values (Unknown Artist)
            TagLib.File tag = TagLib.File.Create(TargetPath);

            if ((artist = tag.Tag.FirstAlbumArtist) == null)
            {
                if ((artist = tag.Tag.FirstPerformer) == null)
                {
                    artist = "Unknown Artist";
                }                    
            }               

            if ((title = tag.Tag.Title) == null)
            {
                title = Path.GetFileNameWithoutExtension(TargetPath);
            }

            if ((album = tag.Tag.Album) == null)
            {
                album = "Unknown Album";
            }
            year = (int)tag.Tag.Year;
            trackNum = (int)tag.Tag.Track;

            // get library track counter and increment
            root.Attribute("Count").SetValue((num = Int32.Parse(root.Attribute("Count").Value) + 1).ToString());

            XElement Track =
                new XElement("Track",
                    new XAttribute("ID", num),
                    new XElement("Title", title),
                    new XElement("Album", album),
                    new XElement("Artist", artist),
                    new XElement("TrackNumber", trackNum),
                    new XElement("Year", year),
                    new XElement("DateAdded", DateTime.Now.ToString("g")),
                    new XElement("Path", TargetPath)
                );
            root.Add(Track);
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {          
            IEnumerable<XElement> de =
                (from el in root.Elements("Track").Elements("Artist")
                select el).OrderBy(x => x.Value)
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
                    (from el in root.Elements("Track").Elements("Album")
                     select el).OrderBy(x => x.Value)
                              .GroupBy(x => x.Value)
                              .Select(x => x.First());
            }
            else
            {
                de =
                   (from el in root.Elements("Track")
                   where (string)el.Element("Artist") == artist
                   select el.Element("Album")).OrderBy(x => Int32.Parse(x.Parent.Element("Year").Value))
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
                de = root.Elements("Track").Elements("Title")
                         .OrderBy(element => element.Value)
                         .ToList();                           
            }
            else if ((artist != null) && (album == null))   // specific artist
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Artist") == artist
                     select el.Element("Title"))
                    .OrderBy(x => x.Parent.Element("Album").Value)
                    .ThenBy(x => x.Parent.Element("TrackNumber").Value);
            }
            else if ((artist == null) && (album != null))   // specific album
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Album") == album
                     select el.Element("Title")).OrderBy(x => Int32.Parse(x.Parent.Element("TrackNumber").Value));
            }
            else // specific artist and album
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Album") == album
                     where (string)el.Element("Artist") == artist
                     select el.Element("Title")).OrderBy(x => Int32.Parse(x.Parent.Element("TrackNumber").Value));
            }

            foreach (XElement el in de)
            {
                TrackListBox.Items.Add(el.Value);
            }            
        }

        private void ScanRoot_Click(object sender, EventArgs e)
        {
            ScanDirectory(RootDirectory);
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
            
        }

        private void ClearLibButton_Click(object sender, EventArgs e)
        {
            ClearLibrary();
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
            string album, artist = null;

            if ((album = AlbumListBox.SelectedItem.ToString()) == "All Albums")
                album = null;

            if ((artist = ArtistListBox.SelectedItem.ToString()) == "All Artists")
                artist = null;

            PopulateTracks(artist, album);
        }
    }
}
