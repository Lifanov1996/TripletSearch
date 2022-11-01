using System;
using System.IO;

namespace SearchTriplet
{
    internal class FileSearch
    {
        private string path { get; set; }
        public FileSearch(string Path)
        {
            this.path = Path;
        }

        public string FileReader()
        {
            string text = String.Empty;
            try
            {
                text = File.ReadAllText(path.ToLower());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return text;
        }
    }
}
