using System;
using System.Windows.Forms;

namespace FtpLibrary
{
    class FtpConfiguration
    {
        private static FtpConfiguration Instance { get; set; } = null;
        public string Host { get; }
        public string Login { get; }
        public string Password { get; }
        //public string DefaultPath { get; } = "xn--80adjnibthssp.xn--p1ai/docs/images/";
        public string DefaultPath { get; } = "ftp/images";

        private FtpConfiguration()
        {
            string ConnectionString = Environment.GetEnvironmentVariable("PosterEditorFtpConnection", EnvironmentVariableTarget.User);
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show(
                    "Ошибка! Строка для подключения к ftp не обнаружена!",
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.Exit(-1);
            } else
            {
                Host = "192.168.1.116"; //ConnectionString.Split(';')[0];
                Login = "kot074"; //ConnectionString.Split(';')[1];
                Password = "123"; //ConnectionString.Split(';')[2];
            }
        }

        public static FtpConfiguration GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FtpConfiguration();
            }
            return Instance;
        }
    }
}
