using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace NewsEditorCore
{
    public class ConfigurationManager
    {
        private static ConfigurationManager _instance = null;
        private const string CONFIG_FILE = "configuration.json";

        public static ConfigurationManager Instance
        {
            get => _instance ??= new ConfigurationManager();
        }

        public FTPConfiguration Ftp { get; }
        public MySqlConfiguration MySql { get; }
        public PrintConfiguration PrintConfiguration { get; }

        private ConfigurationManager()
        {
            var roadConfig = File.ReadAllText(CONFIG_FILE);

            var jsonObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(roadConfig);

            Ftp = JsonConvert.DeserializeObject<FTPConfiguration>(jsonObj["Ftp"].ToString());
            MySql = JsonConvert.DeserializeObject<MySqlConfiguration>(jsonObj["MySql"].ToString());
            PrintConfiguration = JsonConvert.DeserializeObject<PrintConfiguration>(jsonObj["PrintConfiguration"].ToString());
        }
    }

    public class FTPConfiguration
    {
        public string Host { get; }
        public string Path { get; }
        public string Login { get; }
        public string Password { get; }

        public FTPConfiguration(string host, string path, string login, string password)
        {
            Host = host;
            Path = path;
            Login = login;
            Password = password;
        }
    }

    public class MySqlConfiguration
    {
        public string ConnectionString { get; }

        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }

    public class PrintConfiguration
    {
        public bool Landscape { get; }
        public int[] Margin { get; }
        public int FontSize { get; }
        public PrintConfiguration(bool landscape, int[] margin, int fontSize)
        {
            Landscape = landscape;
            Margin = margin;
            FontSize = fontSize;
        }
    }
}
