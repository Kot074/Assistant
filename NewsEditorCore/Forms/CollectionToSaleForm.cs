using System;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;
using NewsEditorCore.Types;

namespace NewsEditorCore.Forms
{
    public partial class CollectionToSaleForm : Form
    {
        private readonly CollectionToSale _collection;
        private readonly IWarehouse _warehouse;
        public CollectionToSale CollectionToSale {
            get => _collection;
        }

        public CollectionToSaleForm(IWarehouse warehouse)
        {
            InitializeComponent();
            _collection = new CollectionToSale();
            _warehouse = warehouse;
        }

        public CollectionToSaleForm(IWarehouse warehouse, CollectionToSale collection) : this(warehouse)
        {
            _collection = collection;
            txtTitle.Text = collection.Text;
            txtDocumentLink.Text = collection.FilePath;
            txtImageLink.Text = collection.ImgPath;
        }

        private void BntImageLoadClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp|All files|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = $"{_warehouse.GetPath()}/sborniki{DateTime.Now:yyyy}/";
                _warehouse.UploadFile(dialog.FileName, filePath);

                var url = HttpUtility.UrlPathEncode("http://" + filePath.Replace("docs/", "") + Path.GetFileName(dialog.FileName));
                txtImageLink.Text = url;
            }
        }

        private void BtnDocumentLoadClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Documents|*.pdf;*.doc;*.docx|All files|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = $"{_warehouse.GetPath()}/sborniki{DateTime.Now:yyyy}/";
                _warehouse.UploadFile(dialog.FileName, filePath);

                var url = HttpUtility.UrlPathEncode("http://" + filePath.Replace("docs/", "") + Path.GetFileName(dialog.FileName));
                txtDocumentLink.Text = url;
            }
        }

        private void BtnSaveCollectionClick(object sender, EventArgs e)
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

        private void BtnCollectionCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
