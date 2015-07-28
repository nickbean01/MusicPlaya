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
        string RootDirectory = "E:\\Music\\TEST FOLDER";
        string FileType = ".mp3";
        string xmlPath = "E:\\Music\\test3.xml";
        XElement root;

        public Form1()
        {
            InitializeComponent();
            ReadLibrary();
        }

        /* reads from XML library file */
        public void ReadLibrary()
        {
            XDocument doc;

            // creates XML file if it doesn't already exist
            if (!File.Exists(xmlPath))
            {
                CreateLibrary();
            }
            else
            {
                root = XElement.Load(xmlPath);
            }
        }

        /* add all artists to artist list */
        public void PopulateArtists()
        {
            XDocument doc = XDocument.Load(xmlPath);
            ArtistListBox.Items.Add("All Artists");
            /*foreach (var name in doc.Root.Element("Artist").OfType<XElement>()
                .Select(x => x.Name).Distinct())
            {
                System.Diagnostics.Debug.WriteLine(name);
            }*/
        }
        
        /* add albums depending on artist selected */
        public void PopulateAlbums()
        {
            AlbumListBox.Items.Add("All Albums");
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks()
        {
            
        }

        /* creates XML library file */
        public void CreateLibrary()
        {
            System.Diagnostics.Debug.WriteLine("HWAAYYYYYY");
            if (File.Exists(xmlPath))
            {
                // you goofed, should never happen
                return;
            }
            //File.Create(xmlPath);

            root = new XElement("Library",
                new XAttribute("Count", "1")
                );
            root.Save(xmlPath);

            System.Diagnostics.Debug.WriteLine(root);

            ScanDirectory(RootDirectory);
        }

        /* scans given root directory and adds missing files to XML library */
        public void ScanDirectory(String TargetDirectory)
        {
            string[] FileEntries;
            

            if (!Directory.Exists(TargetDirectory))
            {
                System.Diagnostics.Debug.WriteLine("\"" + TargetDirectory + "\"  does not exist.");
                return;
            }
            System.Diagnostics.Debug.WriteLine("Scanning: " + TargetDirectory);

            FileEntries = Directory.GetFileSystemEntries(TargetDirectory);
            foreach (string TargetPath in FileEntries)
            {
                if (File.Exists(TargetPath))            // make sure file exists
                {
                    if (TargetPath.EndsWith(FileType))  // check if mp3
                    {
                        TrackListBox.Items.Add(TargetPath);

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

        /* checks if an track with the path exists in the library */
        private Boolean CheckPathExists(string TargetPath)
        {
            return false;
        }

        /* inserts new track to XML file */
        /* pulls info from metadata (eventually) */
        private void InsertTrack(string TargetPath)
        {
            string title;
            string album;
            string artist;
            int trackNum;
            int num;
            int year;
            string dateAdded;

            // dumby info for testing
            title = "Hysteria";
            album = "Zoo";
            artist = "Ceremony";
            trackNum = 1;
            num = 1;
            year = 2012;
            dateAdded = "7-27-2015";

            XElement Track =
                new XElement("Track",
                    new XAttribute("ID", num),
                    new XElement("Title", title),
                    new XElement("Album", album),
                    new XElement("Artist", artist),
                    new XElement("TrackNumber", trackNum),
                    new XElement("Year", year),
                    new XElement("DateAdded", dateAdded),
                    new XElement("Path", TargetPath)
                );
            root.Add(Track);
            // need to increment 'global' counter in XML to prevent duplicate Track ID attribute
            // maybe just use path as a 'key'? would prevent duplicates no probbbb
            System.Diagnostics.Debug.WriteLine(root);
        }

        private void ScanRoot_Click(object sender, EventArgs e)
        {
            ScanDirectory(RootDirectory);
        }
    }
}
