using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssistantCore.Forms;
using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Storage;
using NewsEditor;

namespace NewsEditorCore
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var configuration = ConfigurationManager.Instance;
            var warehouse = new FTPWirehouse(
                configuration.Ftp.Login, 
                configuration.Ftp.Password,
                configuration.Ftp.Host, 
                configuration.Ftp.Path);
            var context = new VectorContext(configuration.MySql.ConnectionString);
            var factory = new StorageFactory(StorageTypes.MYSQL, context);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(
                warehouse,
                factory.GetContentStorage(),
                factory.GetContentFrontpageStorage(),
                new SplashScreenForm()));
        }
    }
}