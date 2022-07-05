using System;
using System.Collections.Generic;
using System.IO;
using NewsEditorCore.Types;

namespace NewsEditorCore
{
    class LocalWarehouse : IWarehouse
    {
        private readonly string _path;
        public LocalWarehouse(string path)
        {
            _path = path;
        }

        public DirectoryItem[] GetList(string path)
        {
            var result = new List<DirectoryItem>();

            if (!string.IsNullOrEmpty(path))
            {
                var parentLink =
                    new DirectoryItem("..", Path.GetDirectoryName(path).Replace("\\", "/"), true);

                if (!path.Equals(_path, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(parentLink);
                }
            }

            var directories = Directory.GetDirectories(!string.IsNullOrEmpty(path) ? path : _path);
            foreach (var directory in directories)
            {
                var node = new DirectoryItem(Path.GetFileName(directory), directory.Replace("\\", "/"), true);
                result.Add(node);
            }

            var files = Directory.GetFiles(!string.IsNullOrEmpty(path) ? path : _path);
            foreach(var file in files)
            {
                var leaf = new DirectoryItem(Path.GetFileName(file), file.Replace("\\", "/"), false);
                result.Add(leaf);
            }

            return result.ToArray();
        }

        public DirectoryItem CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);

            var directory = new DirectoryItem(Path.GetFileName(path), path, true);
            return directory;
        }

        public void Remove(DirectoryItem node)
        {
            if (node.IsDirectory)
            {
                Directory.Delete(node.FullPath, true);
            }
            else
            {
                File.Delete(node.FullPath);
            }
        }

        public string GetUrl(string path)
        {
            return path;
        }

        public string GetPath()
        {
            return _path;
        }

        public DirectoryItem UploadFile(string sourcePath, string targetPath)
        {
            var name = Path.GetFileName(sourcePath);
            var path = $"{targetPath}/{name}";
            File.Copy(sourcePath, $"{targetPath}/{name}");

            return new DirectoryItem(name, path, false);
        }
    }
}
