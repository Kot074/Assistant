namespace NewsEditorCore.Types
{
    public class DirectoryItem
    {
        public string Label { get; }
        public string FullPath { get; }
        public bool IsDirectory{ get; }

        public DirectoryItem(string label, string path, bool isDirectory)
        {
            Label = label;
            FullPath = path;
            IsDirectory = isDirectory;
        }
    }
}
