namespace WindowsFormsApplication2
{
    internal class Track
    {
        string mytitle;
        string mypath;

        public Track(string newTitle, string newPath)
        {
            this.mytitle = newTitle;
            this.mypath = newPath;
        }

        public string title
        {
            get
            {
                return mytitle;
            }
        }

        public string path
        {
            get
            {
                return mypath;
            }
        }

        public void setTitle(string newTitle)
        {
            mytitle = newTitle;
        }

        public void setPath(string newPath)
        {
            mypath = newPath;
        }
    }
}