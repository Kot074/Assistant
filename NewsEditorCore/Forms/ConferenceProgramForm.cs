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
    public partial class ConferenceProgramForm : Form
    {
        private ConferenceProgram _program;
        public ConferenceProgram ConferenceProgram
        {
            get => _program;
        }

        private readonly string _ftpHost;
        private readonly string _ftpPath;
        private readonly string _ftpLogin;
        private readonly string _ftpPass;

        public ConferenceProgramForm()
        {
            InitializeComponent();
            _program = new ConferenceProgram();

            var config = ConfigurationManager.Instance;
            _ftpHost = config.Ftp.Host;
            _ftpPath = config.Ftp.Path;
            _ftpLogin = config.Ftp.Login;
            _ftpPass = config.Ftp.Password;
        }

        public ConferenceProgramForm(ConferenceProgram program) : this()
        {
            _program = program;
            txtTitle.Text = program.Title;
            txtDocument.Text = program.DocumentUrl;
        }

        private void btnDocumentUpload_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Documents|*.pdf;*.doc;*.docx|All files|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var extension = Path.GetExtension(dialog.FileName);
                var filePath = $"{_ftpPath}/conferences/{DateTime.Now.ToString("yyyy")}/{DateTime.Now.ToString("yyyyMMdd_HHmmss")}{extension}";
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

                txtDocument.Text = "http://" + filePath.Replace("docs/", "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Название сборника не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;

            _program.Title = txtTitle.Text;
            _program.DocumentUrl = txtDocument.Text;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
