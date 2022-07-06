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
using System.Web;
using System.Windows.Forms;
using NewsEditorCore.Types;

namespace NewsEditorCore.Forms
{
    public partial class ConferenceProgramForm : Form
    {
        private readonly ConferenceProgram _program;
        private readonly IWarehouse _warehouse;
        public ConferenceProgram ConferenceProgram
        {
            get => _program;
        }

        public ConferenceProgramForm(IWarehouse warehouse)
        {
            InitializeComponent();
            _program = new ConferenceProgram();
            _warehouse = warehouse;
        }

        public ConferenceProgramForm(IWarehouse warehouse, ConferenceProgram program) : this(warehouse)
        {
            _program = program;
            txtTitle.Text = program.Title;
            txtDocument.Text = program.DocumentUrl;
        }

        private void BtnDocumentUploadClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Documents|*.pdf;*.doc;*.docx|All files|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = $"{_warehouse.GetPath()}/conferences/{DateTime.Now:yyyy}/";
                _warehouse.UploadFile(dialog.FileName, filePath);

                var url = HttpUtility.UrlPathEncode("http://" + filePath.Replace("docs/", "") + Path.GetFileName(dialog.FileName));
                txtDocument.Text = url;
            }
        }

        private void BtnSaveClick(object sender, EventArgs e)
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

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
