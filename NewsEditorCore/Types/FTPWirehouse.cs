using FluentFTP;
using NewsEditorCore.Types;
using System;
using System.Collections.Generic;
using System.IO;

namespace NewsEditorCore
{
    class FTPWirehouse : IWarehouse, IDisposable
    {
        private readonly string _path;
        private readonly FtpClient _ftpClient;

        public FTPWirehouse(string username, string password, string host, string path)
        {
            _path = path;

            _ftpClient = new FtpClient(host, username, password);
            _ftpClient.Connect();
        }

        public DirectoryItem[] GetList(string path)
        {
            var result = new List<DirectoryItem>();
            var validPath = path ?? _path;

            if (_ftpClient.IsConnected)
            {
                var filesList = _ftpClient.GetListing(validPath);
                foreach (var file in filesList)
                {
                    var name = file.Name;
                    if (name == "." || name == "..")
                    {
                        continue;
                    }
                    var extension = Path.GetExtension(file.FullName);
                    var node = new DirectoryItem(name, Path.Combine(validPath, name).Replace('\\', '/'), false);
                    if (string.IsNullOrEmpty(extension))
                    {
                        node = new DirectoryItem(name, Path.Combine(validPath, name).Replace('\\', '/'), true);
                    }
                    result.Add(node);
                }

                result.Sort((a, b) =>
                {
                    if (a.IsDirectory && b.IsDirectory)
                    {
                        return string.Compare(a.Label, b.Label);
                    }
                    else if (!a.IsDirectory && !b.IsDirectory)
                    {
                        return string.Compare(a.Label, b.Label);
                    }
                    else if (!a.IsDirectory && b.IsDirectory)
                    {
                        return 1;
                    }
                    else if (a.IsDirectory && !b.IsDirectory)
                    {
                        return -1;
                    }

                    return 0;
                });

                if (!string.IsNullOrEmpty(path))
                {
                    var parentLink =
                        new DirectoryItem("..", Path.GetDirectoryName(path).Replace("\\", "/"), true);

                    if (!path.Equals(_path, StringComparison.OrdinalIgnoreCase))
                    {
                        result.Insert(0, parentLink);
                    }
                }

                return result.ToArray();
            }
            else
            {
                throw new FtpException("FTP соединение разорвано.");
            }
        }

        public DirectoryItem CreateDirectory(string path)
        {
            if (_ftpClient.IsConnected)
            {
                _ftpClient.CreateDirectory(path);
                return new DirectoryItem(Path.GetFileName(path), path, true);
            }
            else
            {
                throw new FtpException("FTP соединение разорвано.");
            }
        }

        public void Remove(DirectoryItem node)
        {
            if (_ftpClient.IsConnected)
            {
                if (node.IsDirectory)
                {
                    _ftpClient.DeleteDirectory(node.FullPath, FtpListOption.Recursive);
                }
                else
                {
                    _ftpClient.DeleteFile(node.FullPath);
                }
            }
            else
            {
                throw new FtpException("FTP соединение разорвано.");
            }
        }

        public DirectoryItem UploadFile(string sourcePath, string targetPath)
        {
            var fileName = Path.GetFileName(sourcePath);
            var filePath = Path.Combine(targetPath, fileName).Replace('\\', '/');

            byte[] fileContents = File.ReadAllBytes(sourcePath);

            if (_ftpClient.IsConnected)
            {
                if (!_ftpClient.DirectoryExists(targetPath))
                {
                    CreateDirectory(targetPath);
                }
                _ftpClient.UploadFile(sourcePath, filePath);
            }

            return new DirectoryItem(fileName, filePath, false);
        }

        public string GetUrl(string path)
        {
            return "http://" + path.Replace("docs/", "");
        }

        public string GetPath()
        {
            return _path;
        }

        public void Dispose()
        {
            _ftpClient.Disconnect();
        }
    }
}
