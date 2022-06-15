using System.IO;
using System.Net;

namespace FtpLibrary
{
    public static class FtpTools
    {
        public static void Upload(string pathFrom, string folderTo, string fileName) 
        {
            FtpConfiguration config = FtpConfiguration.GetInstance();

            string directory = Path.GetDirectoryName(pathFrom);
            string filename = Path.GetFileName(pathFrom);

            string tmpFile = Path.Combine(directory, "__" + filename);

            File.Copy(pathFrom, tmpFile);

            FtpClient ftp = new FtpClient(config.Host, config.Login, config.Password);
            ftp.Connect();

            if(!ftp.DirectoryExists(Path.Combine(config.DefaultPath, folderTo)))
            {
                ftp.CreateDirectory(Path.Combine(config.DefaultPath, folderTo));
            }

            ftp.UploadFile(tmpFile, Path.Combine(config.DefaultPath, folderTo, fileName));
            File.Delete(tmpFile);

            ftp.Disconnect();
        }
    }
}
