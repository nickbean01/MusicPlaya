using System;

public class MusicLibrary
{
    XElement root;
    string RootDirectory = "E:\\Music";
    string FileType = ".mp3";
    string xmlPath = "E:\\Music\\LIBRARY.xml";

    public MusicLibrary(string root, string type, string path)
	{
        this.RootDirectory = root;
        this.FileType = type;
        this.xmlPath = path;
	}
}
