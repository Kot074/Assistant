using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Models;
using NewsEditorCore;
using NewsEditorCore.Forms;
using NewsEditorCore.Types;

namespace NewsEditor.Forms
{
    public partial class EditorForm : Form
    {
        private readonly JosContent _content;

        private readonly IWarehouse _warehouse;
        private string _currentPath;

        public JosContent Content
        {
            get
            {
                return _content;
            }
        }

        public EditorForm(IWarehouse warehouse)
        {
            InitializeComponent();

            var now = DateTime.UtcNow;
            _content = new JosContent()
            {
                PublishUp = now,
                Created = now,
                Alias = Guid.NewGuid().ToString(),
                Introtext = string.Empty,
                Sectionid = (uint)SectionsEnum.NEWS,
                Mask = 0,
                Catid = (uint)CategoriesEnum.NEWS,
                CreatedBy = 62,
                CheckedOut = 0,
                Attribs = "show_title=\nlink_titles =\nshow_intro =\nshow_section =\nlink_section =\nshow_category =\nlink_category =\nshow_vote =\nshow_author =\nshow_create_date =\nshow_modify_date =\nshow_pdf_icon =\nshow_print_icon =\nshow_email_icon =\nlanguage =\nkeyref =\nreadmore = ",
                Version = 1,
                Parentid = 0,
                Ordering = 0,
                Access = 0,
                Hits = 0,
                Metadata = "robots=\nauthor=",
                Fulltext = string.Empty,
                TitleAlias = string.Empty,
                State=1,
                CreatedByAlias = string.Empty,
                Images = string.Empty,
                Urls = string.Empty,
                Metakey = string.Empty,
                Metadesc = string.Empty,
                Title = string.Empty
            };

            _warehouse = warehouse;
            _currentPath = warehouse.GetPath();

            listBox.DisplayMember = "Label";
            var list = _warehouse.GetList(null);
            listBox.Items.AddRange(list);
        }

        public EditorForm(IWarehouse warehouse, JosContent content) : this(warehouse)
        {
            _content = content;
        }

        private void EditorForm_Load(object sender, EventArgs e)
        {
            tinyMceEditor.CreateEditor(_content.Introtext);
            txtTitle.Text = _content.Title;
            dtpDate.Value = _content.PublishUp.ToLocalTime();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            _content.Title = txtTitle.Text;
            _content.Introtext = 
                tinyMceEditor.HtmlContent
                    .Replace("<p>", "<p style=\"text-indent: 1.25cm; font-family:Times New Roman, Times, serif; font-size: 12pt; margin-top: 0.5em; margin-bottom: 0.5em; line-height: 150%;\">");
            _content.PublishUp = dtpDate.Value.ToUniversalTime();
            _content.PublishDown = DateTime.MaxValue;
            _content.Created = dtpDate.Value.ToUniversalTime();

            this.Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCopyAddressClick(object sender, EventArgs e)
        {
            var selected = (DirectoryItem)listBox.SelectedItem;
            if (selected is not null)
            {
                Clipboard.SetText(_warehouse.GetUrl(selected.FullPath));
            }
        }

        private void BtnCreateDirectoryClick(object sender, EventArgs e)
        {
            var input = new TextInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.CreateDirectory($"{_currentPath}/{input.Value}");
                listBox.Items.Add(newItem);
                listBox.Refresh();
            }
        }

        private void BtnLoadFileClick(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.UploadFile(fileDialog.FileName, _currentPath);
                listBox.Items.Add(newItem);
                listBox.Refresh();
            }
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            var selected = (DirectoryItem)listBox.SelectedItem;

            if (selected is not null)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {selected.Label}?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _warehouse.Remove(selected);
                    listBox.Items.Remove(selected);
                    listBox.Refresh();
                }
            }
        }

        private void ListBoxEnter(object sender, EventArgs e)
        {
            var selected = (DirectoryItem)listBox.SelectedItem;

            if (selected is not null && selected.IsDirectory)
            {
                _currentPath = selected.FullPath;
                listBox.Items.Clear();
                listBox.Items.AddRange(_warehouse.GetList(selected.FullPath));
                listBox.Refresh();
            }
        }

        private void ListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = listBox.SelectedItem;
            if (selected is not null)
            {
                btnCopyAddress.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnCopyAddress.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
    }
}
