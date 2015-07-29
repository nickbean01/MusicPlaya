using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WindowsFormsApplication2
{
    internal class MusicLibrary
    {
        XElement root;
        string RootDirectory;
        string FileType;
        string xmlPath;

        public MusicLibrary(string rootPath, string type, string path)
        {
            this.RootDirectory = rootPath;
            this.FileType = type;
            this.xmlPath = path;
        }

        private void CreateLibrary()
        {
            if (File.Exists(xmlPath))
            {                
                return;
            }

            root = new XElement("Library",
                new XAttribute("Count", "0")
                );
            root.Save(xmlPath);

            ScanDirectory(RootDirectory);
        }

        /* reads from XML library file */
        public void ReadLibrary()
        {
            // creates XML file if it doesn't already exist
            if (!File.Exists(xmlPath))
                CreateLibrary();
            else
                root = XElement.Load(xmlPath);
        }

        /* removes all data from XML library file */
        public void ClearLibrary()
        {
            this.root = new XElement("Library",
                new XAttribute("Count", "0")
                );
            this.root.Save(this.GetPath());
        }

        /* scans given root directory and adds missing files to XML library */
        public void ScanDirectory(string TargetDirectory)
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

        /* inserts new track to XML file */
        /* pulls info from metadata (eventually) */
        public void InsertTrack(string TargetPath)
        {
            XElement Track;
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
                    new XElement("Path", TargetPath)
                );
            root.Add(Track);
        }

        /* getters */
        public XElement GetXEl()
        {
            return root;
        }

        public string GetRoot()
        {
            return this.RootDirectory;
        }

        public string GetFileType()
        {
            return this.FileType;
        }

        public string GetPath()
        {
            return this.xmlPath;
        }

        /* setters */
        public void SetXEl(XElement newX)
        {
            root = newX;
        }

        public void SetRoot(string newRoot)
        {
            RootDirectory = newRoot;
        }

        public void SetFileType(string newType)
        {
            FileType = newType;
        }

        public void SetPath(string newPath)
        {
            xmlPath = newPath;
        }

        /* utility method */
        /* checks if a track with the given path already exists in the library */
        private Boolean CheckPathExists(string TargetPath)
        {
            IEnumerable<XElement> de =
                from el in root.Descendants("Path")
                select el;
            foreach (XElement el in de)
            {
                if (String.Compare(el.Value, TargetPath) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}