using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsEditorCore.Types
{
    class DirectoryItem
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
