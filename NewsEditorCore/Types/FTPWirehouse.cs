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
        private string _password;
        private string _userName;
        private string _host;
        private string _path;

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

            var request = CreateRequest(Combine(_host, validPath), WebRequestMethods.Ftp.ListDirectory);
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            var info = reader.ReadLine();
                            var name = Path.GetFileName(info);
                            if (name == "." || name == "..")
                            {
                                continue;
                            }
                            var extension = Path.GetExtension(info);
                            var node = new DirectoryItem(name, Combine(validPath, name), false);
                            if (string.IsNullOrEmpty(extension))
                            {
                                node = new DirectoryItem(name, Combine(validPath, name), true);
                            }
                            result.Add(node);
                        }
                    }
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
            var request = CreateRequest(Combine(_host, path), WebRequestMethods.Ftp.MakeDirectory);
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
                Combine(_host, node.FullPath),
                node.IsDirectory ? WebRequestMethods.Ftp.RemoveDirectory : WebRequestMethods.Ftp.DeleteFile);
            request.GetResponse();
        }

        public DirectoryItem UploadFile(string sourcePath, string targetPath)
        {
            var fileName = Path.GetFileName(sourcePath);
            var filePath = Combine(targetPath, fileName);
            var request = CreateRequest(
                Combine(_host, filePath),
                WebRequestMethods.Ftp.UploadFile);


            byte[] fileContents = File.ReadAllBytes(sourcePath);

            request.ContentLength = fileContents.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            var response = request.GetResponse();

            return new DirectoryItem(fileName, filePath, false);
        }

        public string GetUrl(string path)
        {
            return "http://" + path.Replace("docs/", "");
        }

        private string Combine(string path1, string path2)
        {
            var end = path2.StartsWith('/') ? path2 : "/" + path2;
            var path = $"{path1}{end}";
            return path;
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
