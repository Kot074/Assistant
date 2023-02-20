using AssistantCore.Forms;
using Atom.VectorSiteLibrary.Data;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Storage;
using NewsEditor;
using System;
using System.Windows.Forms;

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
#if DEBUG
            var context = new VectorContext("datasource=127.0.0.1;initial catalog=soft123_vn;user id=root;password=12345;Allow Zero DateTime=true;Convert Zero Datetime=true;");
#else
            var context = new VectorContext(configuration.MySql.ConnectionString);
#endif
            var factory = new StorageFactory(StorageTypes.MYSQL, context);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(
                warehouse,
                factory.GetContentStorage(),
                factory.GetContentFrontpageStorage(),
                factory.GetOrderStorage(),
                new SplashScreenForm()));
        }
    }
}