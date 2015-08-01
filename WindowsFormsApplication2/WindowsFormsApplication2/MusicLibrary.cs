using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    internal class MusicLibrary
    {
        public IEnumerable<XElement> XmlTrackList { get; set; }    // collection of Track elements in TrackListBox
        XElement root { get; set; }
        string FileType;

        public MusicLibrary(string rootPath, string type, string path)
        {
            if (rootPath == "")
            {
                ChooseMusicFolder();               
            }
            if(path == "")
            {
                SetLibraryFilePath(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\LIBRARY.xml");
                //ChooseLibFileLocation();
            }
            else
            {
                SetRoot(rootPath);
                SetLibraryFilePath(path);
            }
            this.FileType = type;
            ReadLibrary();
        }

        private void CreateLibrary()
        {
            if (File.Exists(GetLibraryFilePath()))
                return;

            root = new XElement("Library",
                new XAttribute("Count", "0")
                );
            root.Save(GetLibraryFilePath());

            ScanDirectory(GetRoot());
        }    

        /* reads from XML library file */
        public void ReadLibrary()
        {
            // creates XML file if it doesn't already exist
            if (!File.Exists(GetLibraryFilePath()))
                CreateLibrary();
            else
                root = XElement.Load(GetLibraryFilePath());
        }

        /* removes all data from XML library file */
        public void ClearLibrary()
        {
            this.root = new XElement("Library",
                new XAttribute("Count", "0")
                );

            File.Delete(this.GetLibraryFilePath());
            SetRoot("");
            Properties.Settings.Default.Save();
        }

        /* scans given root directory and adds missing files to XML library */
        public void ScanDirectory(string TargetDirectory)
        {
            string[] FileEntries = null;

            if (!Directory.Exists(TargetDirectory))
                return;

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
                            InsertTrack(TargetPath, FileType);
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
            root.Save(GetLibraryFilePath());
            return;
        }

        /* inserts new track to XML file */
        public void InsertTrack(string TargetPath, string FileType)
        {
            TagLib.File tag;
            XElement Track;
            string title;
            string album;
            string artist;
            string trackNum;
            int num;
            string year;

            // check for nulls on these and fill in dummy values (Unknown Artist)
            tag = TagLib.File.Create(TargetPath);

            if ((artist = tag.Tag.FirstAlbumArtist) == null)
                if ((artist = tag.Tag.FirstPerformer) == null)
                    artist = "Unknown Artist";

            if ((title = tag.Tag.Title) == null)
                title = Path.GetFileNameWithoutExtension(TargetPath);

            if ((album = tag.Tag.Album) == null)
                album = "Unknown Album";

            year = tag.Tag.Year.ToString();

            trackNum = tag.Tag.Track.ToString();
            if (trackNum.Length == 1)
            {
                trackNum = "0" + trackNum;
            }

            // get library track counter and increment
            root.Attribute("Count").SetValue((num = Int32.Parse(root.Attribute("Count").Value) + 1).ToString());

            // create track element and insert to xml tree
            Track =
                new XElement("Track",
                    new XAttribute("ID", num),
                    new XElement("Title", title),
                    new XElement("Album", album),
                    new XElement("Artist", artist),
                    new XElement("TrackNumber", trackNum),
                    new XElement("Year", year),
                    new XElement("DateAdded", DateTime.Now.ToString("g")),
                    new XElement("Path", TargetPath),
                    new XElement("Type", FileType)
                );
            root.Add(Track);
        }

        /* return collection of tracks */
        public IEnumerable<XElement> GetTracks(string artist, string album)
        {
            IEnumerable<XElement> de = null;

            if ((artist == null) && (album == null))        // all tracks alphabetically
            {
                de =
                    (from el in root.Elements("Track")
                     .OrderBy(x => x.Element("Title").Value)
                     select el);
            }
            else if ((artist != null) && (album == null))   // specific artist
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Artist") == artist
                     select el)
                     .OrderBy(x => Int32.Parse(x.Element("Year").Value))
                     .ThenBy(x => x.Element("Album").Value)
                     .ThenBy(x => Int32.Parse(x.Element("TrackNumber").Value));
            }
            else if ((artist == null) && (album != null))   // specific album
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Album") == album
                     select el)
                     .OrderBy(x => Int32.Parse(x.Element("TrackNumber").Value));
            }
            else    // specific artist and album
            {
                de =
                    (from el in root.Elements("Track")
                     where (string)el.Element("Album") == album
                     where (string)el.Element("Artist") == artist
                     select el)
                     .OrderBy(x => Int32.Parse(x.Element("TrackNumber").Value));
            }
            return de;
        }

        /* return collection of albums */
        public IEnumerable<XElement> GetAlbums(string artist)
        {
            IEnumerable<XElement> de = null;
            if (artist == null)
            {
                de =
                    (from el in root.Elements("Track").Elements("Album")
                     select el)
                     .OrderBy(x => x.Value)
                     .GroupBy(x => x.Value)
                     .Select(x => x.First());
            }
            else
            {
                de =
                   (from el in root.Elements("Track")
                    where (string)el.Element("Artist") == artist
                    select el.Element("Album"))
                   .OrderBy(x => Int32.Parse(x.Parent.Element("Year").Value))
                   .GroupBy(x => x.Value)
                   .Select(x => x.First());
            }
            return de;
        }

        /* return collection of artists */
        public IEnumerable<XElement> GetArtists()
        {
            IEnumerable<XElement> de =
                (from el in root.Elements("Track").Elements("Artist")
                select el)
                .OrderBy(x => x.Value)
                .GroupBy(x => x.Value)
                .Select(x => x.First());

            return de;
        }

        /*public void DefaultLoad()
        {
            PopulateArtists();
            PopulateAlbums(null);
            PopulateTracks(null, null);
        }*/

        /* add all artists to artist list */
        public void PopulateArtists(ListBox lb)
        {
            lb.Items.Clear();
            lb.Items.Add("All Artists");

            foreach (XElement el in GetArtists())
                lb.Items.Add(el.Value);
        }

        /* add albums depending on artist selected */
        public void PopulateAlbums(ListBox lb, string artist)
        {
            lb.Items.Clear();
            lb.Items.Add("All Albums");

            foreach (XElement el in GetAlbums(artist))
                lb.Items.Add(el.Value);
        }

        /* add songs depending on album(s) selected */
        public void PopulateTracks(ListBox lb, string artist, string album)
        {
            lb.Items.Clear();
            lb.ClearSelected();
            XmlTrackList = GetTracks(artist, album);

            foreach (XElement el in XmlTrackList)
            {
                lb.Items.Add(el.Element("Title").Value);
            }
        }

        /* prompts user for music folder location */
        public Boolean ChooseMusicFolder()
        {
            string message =
                "Music folder "
                + Properties.Settings.Default.MusicFolderPath
                + " already exists. Are you sure you want to change it?";
            string caption = "WARNING";

            /* prompts user if music folder already exists */
            if ((Properties.Settings.Default.MusicFolderPath == "") ||
               (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose your music folder.";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SetRoot(fbd.SelectedPath);
                    return true;
                }
            }
            return false;
        }

        public void ChooseLibFileLocation()
        {
            string message =
                "Library location is: "
                + Properties.Settings.Default.LibraryFilePath + Environment.NewLine
                + " Are you sure you want to change it?";
            string caption = "WARNING";

            /* prompts user if music folder already exists */
            if ((Properties.Settings.Default.LibraryFilePath == "") ||
               (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Choose library file location.";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    SetLibraryFilePath(fbd.SelectedPath + "\\LIBRARY.xml");
                }
            }
        }

        /* getters */
        public XElement GetXEl()
        {
            return root;
        }

        public string GetRoot()
        {
            return Properties.Settings.Default.MusicFolderPath;
        }

        public string GetFileType()
        {
            return this.FileType;
        }

        public string GetLibraryFilePath()
        {
            return Properties.Settings.Default.LibraryFilePath;
        }

        /* setters */
        public void SetXEl(XElement newX)
        {
            root = newX;
        }

        public void SetRoot(string newRoot)
        {
            Properties.Settings.Default.MusicFolderPath = newRoot;
            Properties.Settings.Default.Save();
        }

        public void SetFileType(string newType)
        {
            FileType = newType;
        }

        public void SetLibraryFilePath(string newPath)
        {
            Properties.Settings.Default.LibraryFilePath = newPath;
            Properties.Settings.Default.Save();
        }

        /* utility method */
        /* checks if a track with the given path already exists in the library */
        private Boolean CheckPathExists(string TargetPath)
        {
            IEnumerable<XElement> de =
                from el in root.Descendants("Path")
                select el;

            foreach (XElement el in de)
                if (String.Compare(el.Value, TargetPath) == 0)
                    return true;
            
            return false;
        }
    }
}