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
        string RootDirectory = "E:\\Music\\Ceremony";
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
                PopulateTracks();
                PopulateArtists();
                PopulateAlbums();
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

            TagLib.File tag = TagLib.File.Create(TargetPath);
            if((artist = tag.Tag.FirstAlbumArtist) == null)
            {
                artist = tag.Tag.FirstPerformer;
            }
            title = tag.Tag.Title;
            album = tag.Tag.Album;
            year = (int)tag.Tag.Year;
            trackNum = (int)tag.Tag.Track;

            // get library track counter and increment
            att = root.Attribute("Count");
            num = Int32.Parse(att.Value) + 1;
            att.SetValue(num.ToString());

            XElement Track =
                new XElement("Track",
                    new XAttribute("ID", num),
                    new XElement("Title", title),
                    new XElement("Album", album),
                    new XElement("Artist", artist),
                    new XElement("TrackNumber", trackNum),
                    new XElement("Year", year),
                    new XElement("DateAdded", DateTime.Now.ToString("d")),
                    new XElement("Path", TargetPath)
                );

            root.Add(Track);
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {
            ArtistListBox.Items.Clear();
            ArtistListBox.Items.Add("All Artists");
        }

        /* add albums depending on artist selected */
        public void PopulateAlbums()
        {
            AlbumListBox.Items.Clear();
            AlbumListBox.Items.Add("All Albums");
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks()
        {
            IEnumerable<XElement> de =
                from el in root.Descendants("Title")
                select el;
            TrackListBox.Items.Clear();
            foreach (XElement el in de)
            {
                TrackListBox.Items.Add(el.Value);
            }
        }

        private void ScanRoot_Click(object sender, EventArgs e)
        {
            ScanDirectory(RootDirectory);
            PopulateTracks();
            PopulateArtists();
            PopulateAlbums();
        }

        private void ClearLibButton_Click(object sender, EventArgs e)
        {
            ClearLibrary();
            PopulateTracks();
            PopulateArtists();
            PopulateAlbums();
        }
    }
}
