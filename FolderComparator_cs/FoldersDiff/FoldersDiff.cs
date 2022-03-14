namespace FolderComparator_cs.FoldersDiff
{
    internal class FoldersDiff
    {
        public int FilesNumberDiff { init; get; }
        public List<string> FilesDiff { get; set; } = new List<string>();

        public void SaveToFile(string path)
        {
            Console.WriteLine("Writing the output to: " + path);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(ToString());
                writer.WriteLine(DateTime.Now);
                writer.WriteLine("Number of files diff: " + FilesNumberDiff);
                writer.WriteLine("List of diff files");

                foreach (string file in FilesDiff)
                {
                    writer.WriteLine(file);
                }
            }
            Console.WriteLine("Finished !");
        }
    }
}
