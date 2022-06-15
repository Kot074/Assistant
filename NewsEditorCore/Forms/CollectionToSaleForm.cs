using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsEditorCore.Types;

namespace NewsEditorCore.Forms
{
    public partial class CollectionToSaleForm : Form
    {
        private CollectionToSale _collection;
        public CollectionToSale CollectionToSale {
            get => _collection;
        }

        private readonly string _ftpHost;
        private readonly string _ftpPath;
        private readonly string _ftpLogin;
        private readonly string _ftpPass;

        public CollectionToSaleForm()
        {
            InitializeComponent();
            _collection = new CollectionToSale();

            var config = ConfigurationManager.Instance;
            _ftpHost = config.Ftp.Host;
            _ftpPath = config.Ftp.Path;
            _ftpLogin = config.Ftp.Login;
            _ftpPass = config.Ftp.Password;
        }

        public CollectionToSaleForm(CollectionToSale collection) : this()
        {
            _collection = collection;
            txtTitle.Text = collection.Text;
            txtDocumentLink.Text = collection.FilePath;
            txtImageLink.Text = collection.ImgPath;
        }

        private void bntImageLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(dialog.FileName);
                var filePath = $"{_ftpPath}/sborniki{DateTime.Now.ToString("yyyy")}/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{extension}";
                var ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + $"{_ftpHost}/{filePath}");

                ftpRequest.Credentials = new NetworkCredential(_ftpLogin, _ftpPass);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.EnableSsl = false;
                ftpRequest.UsePassive = true;
                ftpRequest.UseBinary = true;

                byte[] fileContents = File.ReadAllBytes(dialog.FileName);

                ftpRequest.ContentLength = fileContents.Length;
                var requestStream = ftpRequest.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                ftpRequest.GetResponse();

                txtImageLink.Text = "http://" + filePath.Replace("docs/", "");
            }
        }

        private void btnDocumentLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Documents|*.pdf;*.doc;*.docx|All files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(dialog.FileName);
                var filePath = $"{_ftpPath}/sborniki{DateTime.Now.ToString("yyyy")}/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{extension}";
                var ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://" + $"{_ftpHost}/{filePath}");

                ftpRequest.Credentials = new NetworkCredential(_ftpLogin, _ftpPass);
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.EnableSsl = false;
                ftpRequest.UsePassive = true;
                ftpRequest.UseBinary = true;

                byte[] fileContents = File.ReadAllBytes(dialog.FileName);

                ftpRequest.ContentLength = fileContents.Length;
                var requestStream = ftpRequest.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                ftpRequest.GetResponse();

                txtDocumentLink.Text = "http://" + filePath.Replace("docs/", "");
            }
        }

        private void btnSaveCollection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Название сборника не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;

            _collection.Text = txtTitle.Text;
            _collection.ImgPath = txtImageLink.Text;
            _collection.FilePath = txtDocumentLink.Text;

            this.Close();
        }

        private void btnCollectionCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
