using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsEditorCore.Types;

namespace NewsEditorCore
{
    class FTPWirehouse : IWarehouse
    {
        private readonly string _password;
        private readonly string _userName;
        private readonly string _host;
        private readonly string _path;

        public FTPWirehouse(string username, string password, string host, string path)
        {
            _userName = username;
            _password = password;
            _host = host;
            _path = path;
        }

        public DirectoryItem[] GetList(string path)
        {
            var result = new List<DirectoryItem>();
            var validPath = path ?? _path;

            if (!string.IsNullOrEmpty(path))
            {
                var parentLink =
                    new DirectoryItem("..", Path.GetDirectoryName(path).Replace("\\", "/"), true);

                if (!path.Equals(_path, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(parentLink);
                }
            }

            var request = CreateRequest(Path.Combine(_host, validPath).Replace('\\', '/'), WebRequestMethods.Ftp.ListDirectory);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using var stream = response.GetResponseStream();
                using var reader = new StreamReader(stream, true);
                while (!reader.EndOfStream)
                {
                    var info = reader.ReadLine();
                    var name = Path.GetFileName(info);
                    if (name == "." || name == "..")
                    {
                        continue;
                    }
                    var extension = Path.GetExtension(info);
                    var node = new DirectoryItem(name, Path.Combine(validPath, name).Replace('\\', '/'), false);
                    if (string.IsNullOrEmpty(extension))
                    {
                        node = new DirectoryItem(name, Path.Combine(validPath, name).Replace('\\', '/'), true);
                    }
                    result.Add(node);
                }
            }

            result.Sort((a, b) =>
            {
                if (a.IsDirectory && b.IsDirectory)
                {
                    return string.Compare(a.Label, b.Label);
                } else if (!a.IsDirectory && !b.IsDirectory)
                {
                    return string.Compare(a.Label, b.Label);
                } else if (!a.IsDirectory && b.IsDirectory)
                {
                    return 1;
                } else if (a.IsDirectory && !b.IsDirectory)
                {
                    return -1;
                }

                return 0;
            });
            return result.ToArray();
        }

        public DirectoryItem CreateDirectory(string path)
        {
            var request = CreateRequest(Path.Combine(_host, path).Replace('\\', '/'), WebRequestMethods.Ftp.MakeDirectory);
            request.GetResponse();
            return new DirectoryItem(Path.GetFileName(path), path, true);
        }

        public void Remove(DirectoryItem node)
        {
            if (node.IsDirectory)
            {
                var list = GetList(node.FullPath).Where(n => !n.Label.Equals(".."));
                foreach (var item in list)
                {
                    Remove(item);
                }
            }
            var request = CreateRequest(
                Path.Combine(_host, node.FullPath).Replace('\\', '/'),
                node.IsDirectory ? WebRequestMethods.Ftp.RemoveDirectory : WebRequestMethods.Ftp.DeleteFile);
            request.GetResponse();
        }

        public DirectoryItem UploadFile(string sourcePath, string targetPath)
        {
            var fileName = Path.GetFileName(sourcePath);
            var filePath = Path.Combine(targetPath, fileName).Replace('\\', '/');
            var request = CreateRequest(
                Path.Combine(_host, filePath).Replace('\\', '/'),
                WebRequestMethods.Ftp.UploadFile);


            byte[] fileContents = File.ReadAllBytes(sourcePath);

            request.ContentLength = fileContents.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

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

        private FtpWebRequest CreateRequest(string uri, string method)
        {
            var r = (FtpWebRequest) WebRequest.Create("ftp://" + uri);

            r.Credentials = new NetworkCredential(_userName, _password);
            r.Method = method;
            r.EnableSsl = false;
            r.UsePassive = true;
            r.UseBinary = true;

            return r;
        }
    }
}
