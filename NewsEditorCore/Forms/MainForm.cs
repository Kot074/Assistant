using System;
using System.Linq;
using System.Windows.Forms;
using AssistantCore.Forms;
using Atom.VectorSiteLibrary.Storage;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Models;
using NewsEditor.Forms;
using NewsEditorCore;
using NewsEditorCore.Forms;
using NewsEditorCore.Types;

namespace NewsEditor
{
    public partial class MainForm : Form
    {
        private IStorage<JosContent> _content;
        private IStorage<JosContentFrontpage> _contentFrontpage;
        private IWarehouse _warehouse;
        private string _currentPath;
        private SplashScreenForm splashScreen;

        private readonly string ftpHost;
        private readonly string fptPath;
        private readonly string ftpLogin;
        private readonly string ftpPassword;

        public MainForm()
        {
            splashScreen = new SplashScreenForm();
            splashScreen.Show();

            InitializeComponent();
            
            var configuration = ConfigurationManager.Instance;

            ftpHost = configuration.Ftp.Host;
            fptPath = configuration.Ftp.Path;
            ftpLogin = configuration.Ftp.Login;
            ftpPassword = configuration.Ftp.Password;

            _warehouse = new FTPWirehouse(ftpLogin, ftpPassword, ftpHost, fptPath);
            _currentPath = fptPath;

            listBox.DisplayMember = "Label";
            var list = _warehouse.GetList(null);
            listBox.Items.AddRange(list);

            var factory = new StorageFactory(StorageTypes.MYSQL, configuration.MySql.ConnectionString);
            _content = factory.GetContentStorage();
            _contentFrontpage = factory.GetContentFrontpageStorage();
            var cfp = _contentFrontpage.GetAll();
            RefreshNews();

            var collectionsTheme = _content.GetAll().Where(c =>
                    c.Catid == (uint)CategoriesEnum.SALES_OF_COLLECTIONS && c.Sectionid == (uint)SectionsEnum.SALES_OF_COLLECTIONS).OrderBy(c => c.Title);
            listOfCollectionsTheme.DisplayMember = "Title";
            listOfCollections.DisplayMember = "Text";
            listOfCollectionsTheme.DataSource = collectionsTheme.ToArray();

            var conferenceProgramsThemes = _content.GetAll().Where(c =>
                c.Catid == (uint)CategoriesEnum.CONFERENCES_PROGRAMS && c.Sectionid == (uint)SectionsEnum.CONFERENCES_PROGRAM).OrderBy(c => c.Title);
            listOfConferenceProgramsTheme.DisplayMember = "Title";
            listOfConferenceProgramsTheme.DataSource = conferenceProgramsThemes.ToArray();
            listOfConferencePrograms.DisplayMember = "Title";

            foreach (DataGridViewColumn column in newsDataGrid.Columns)
            {
                if (column.Name != "Title" && column.Name != "PublishUp")
                {
                    column.Visible = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var editor = new EditorForm();
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                var news = _content.Save(editor.Content);
                var front = new JosContentFrontpage()
                {
                    ContentId = (int)news.Id
                };
                _contentFrontpage.Save(front);

                RefreshNews();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var content = (JosContent)newsDataGrid.SelectedRows[0].DataBoundItem;
            var editor = new EditorForm(content);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                _content.Save(editor.Content);
                RefreshNews();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var content = (JosContent)newsDataGrid.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show(this, "Вы уверены, что хотите удалить новость?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _content.Remove(content);
                RefreshNews();
            }
        }

        private void RefreshNews()
        {
            try
            {
                var news = _content.GetAll().Where(c =>
                        c.Catid == (uint) CategoriesEnum.NEWS && c.Sectionid == (uint) SectionsEnum.NEWS)
                    .OrderByDescending(n => n.PublishUp);
                newsDataGrid.DataSource = news.ToArray();
                newsDataGrid.Refresh();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyAddress_Click(object sender, EventArgs e)
        {
            var selected = (DirectoryItem) listBox.SelectedItem;
            if (selected is not null)
            {
                Clipboard.SetText(_warehouse.GetUrl(selected.FullPath));
            }
        }

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        {
            var input = new TextInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.CreateDirectory($"{_currentPath}/{input.Value}");
                listBox.Items.Add(newItem);
                listBox.Refresh();
            }
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.UploadFile(fileDialog.FileName, _currentPath);
                listBox.Items.Add(newItem);
                listBox.Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = (DirectoryItem) listBox.SelectedItem;

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

        private void listBox_Enter(object sender, EventArgs e)
        {
            var selected = (DirectoryItem) listBox.SelectedItem;

            if (selected is not null && selected.IsDirectory)
            {
                _currentPath = selected.FullPath;
                listBox.Items.Clear();
                listBox.Items.AddRange(_warehouse.GetList(selected.FullPath));
                listBox.Refresh();
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void listOfCollectionsTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfCollectionsTheme.SelectedItem;

            if (selected is not null)
            {
                btnEditTheme.Enabled = true;
                btnRemoveTheme.Enabled = true;
                btnCreateCollection.Enabled = true;
                listOfCollections.DataSource = CollectionToSale.Parse(selected.Introtext);
                listOfCollections.Refresh();
            }
            else
            {
                btnEditTheme.Enabled = false;
                btnRemoveTheme.Enabled = false;
                btnCreateCollection.Enabled = false;
            }
        }

        private void btnCreateTheme_Click(object sender, EventArgs e)
        {
            var inputForm = new TextInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                var now = DateTime.UtcNow;
                var theme = new JosContent
                {
                    Access = 0,
                    Alias = Guid.NewGuid().ToString(),
                    Attribs = "show_title =\nlink_titles =\nshow_intro =\nshow_section =\nlink_section =\nshow_category =\nlink_category =\nshow_vote =\nshow_author =\nshow_create_date =\nshow_modify_date =\nshow_pdf_icon =\nshow_print_icon =\nshow_email_icon =\nlanguage =\nkeyref =\nreadmore = ",
                    Catid = (uint)CategoriesEnum.SALES_OF_COLLECTIONS,
                    CheckedOut = 0,
                    CheckedOutTime = DateTime.MaxValue,
                    Created = now,
                    CreatedBy = 62,
                    CreatedByAlias = "",
                    Fulltext = "",
                    Hits = 0,
                    Images = "",
                    Introtext = "",
                    Mask = 0,
                    Metadata = "robots=\nauthor=",
                    Metadesc = "",
                    Metakey = "",
                    Modified = now,
                    ModifiedBy = 62,
                    Ordering = -1,
                    Parentid = 0,
                    PublishDown = DateTime.MaxValue,
                    PublishUp = now,
                    Sectionid = (uint)SectionsEnum.SALES_OF_COLLECTIONS,
                    State = 1,
                    Title = inputForm.Value,
                    TitleAlias = "",
                    Urls = "",
                    Version = 1
                };

                _content.Save(theme);

                var themes = _content.GetAll().Where(c =>
                    c.Catid == (uint)CategoriesEnum.SALES_OF_COLLECTIONS && c.Sectionid == (uint)SectionsEnum.SALES_OF_COLLECTIONS).OrderBy(c => c.Title);
                listOfCollectionsTheme.DataSource = themes.ToArray();
                listOfCollectionsTheme.Refresh();
            }
        }

        private void btnEditTheme_Click(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfCollectionsTheme.SelectedItem;

            if (selected is not null)
            {
                var inputForm = new TextInputForm(selected.Title);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    selected.Title = inputForm.Value;
                    selected.Modified = DateTime.UtcNow;
                    selected.CheckedOutTime = DateTime.MaxValue;
                    selected.PublishDown = DateTime.MaxValue;
                    _content.Save(selected);

                    var themes = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.SALES_OF_COLLECTIONS && c.Sectionid == (uint)SectionsEnum.SALES_OF_COLLECTIONS).OrderBy(c => c.Title);
                    listOfCollectionsTheme.DataSource = themes.ToArray();
                    listOfCollectionsTheme.Refresh();
                }
            }
        }

        private void btnRemoveTheme_Click(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfCollectionsTheme.SelectedItem;
            if (selected is not null)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {selected.Title}?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _content.Remove(selected);

                    var themes = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.SALES_OF_COLLECTIONS && c.Sectionid == (uint)SectionsEnum.SALES_OF_COLLECTIONS).OrderBy(c => c.Title);
                    listOfCollectionsTheme.DataSource = themes.ToArray();
                    listOfCollectionsTheme.Refresh();
                }
            }
        }

        private void btnCreateCollection_Click(object sender, EventArgs e)
        {
            var collectionToSaleForm = new CollectionToSaleForm();

            if (collectionToSaleForm.ShowDialog() == DialogResult.OK)
            {
                var selectedTheme = (JosContent)listOfCollectionsTheme.SelectedItem;
                var items = CollectionToSale.Parse(selectedTheme.Introtext).ToList();
                items.Add(collectionToSaleForm.CollectionToSale);
                listOfCollections.DataSource = items.ToArray();
                listOfCollections.Refresh();

                selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                selectedTheme.Modified = DateTime.UtcNow;
                selectedTheme.CheckedOutTime = DateTime.MaxValue;
                selectedTheme.PublishDown = DateTime.MaxValue;
                _content.Save(selectedTheme);
            }
        }

        private void btnEditCollection_Click(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfCollectionsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = CollectionToSale.Parse(selectedTheme.Introtext).ToArray();
                var selectedCollectionIndex = listOfCollections.SelectedIndex;
                if (selectedCollectionIndex >= 0)
                {
                    var collectionToSaleForm = new CollectionToSaleForm(items[selectedCollectionIndex]);

                    if (collectionToSaleForm.ShowDialog() == DialogResult.OK)
                    {
                        items[selectedCollectionIndex] = collectionToSaleForm.CollectionToSale;
                        listOfCollections.DataSource = items;
                        listOfCollections.Refresh();

                        selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                        selectedTheme.Modified = DateTime.UtcNow;
                        selectedTheme.CheckedOutTime = DateTime.MaxValue;
                        selectedTheme.PublishDown = DateTime.MaxValue;
                        _content.Save(selectedTheme);
                    }
                }
            }
        }

        private void btnRemoveCollection_Click(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfCollectionsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = CollectionToSale.Parse(selectedTheme.Introtext).ToList();
                var selectedCollectionIndex = listOfCollections.SelectedIndex;
                if (selectedCollectionIndex >= 0)
                {
                    if (MessageBox.Show($"Вы действительно хотите удалить {items[selectedCollectionIndex].Text}?", "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        items.Remove(items[selectedCollectionIndex]);
                        listOfCollections.DataSource = items.ToArray();
                        listOfCollections.Refresh();

                        selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                        selectedTheme.Modified = DateTime.UtcNow;
                        selectedTheme.CheckedOutTime = DateTime.MaxValue;
                        selectedTheme.PublishDown = DateTime.MaxValue;
                        _content.Save(selectedTheme);
                    }
                }
            }
        }

        private void listOfConferenceProgramsTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (JosContent) listOfConferenceProgramsTheme.SelectedItem;

            if (selected is not null)
            {
                listOfConferencePrograms.DataSource = ConferenceProgram.Parse(selected.Introtext);
                listOfConferencePrograms.Refresh();
            }
        }

        private void btnCreateConferenceProgramsTheme_Click(object sender, EventArgs e)
        {
            var inputForm = new TextInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                var now = DateTime.UtcNow;
                var theme = new JosContent
                {
                    Access = 0,
                    Alias = Guid.NewGuid().ToString(),
                    Attribs = "show_title =\nlink_titles =\nshow_intro =\nshow_section =\nlink_section =\nshow_category =\nlink_category =\nshow_vote =\nshow_author =\nshow_create_date =\nshow_modify_date =\nshow_pdf_icon =\nshow_print_icon =\nshow_email_icon =\nlanguage =\nkeyref =\nreadmore = ",
                    Catid = (uint)CategoriesEnum.CONFERENCES_PROGRAMS,
                    CheckedOut = 0,
                    CheckedOutTime = DateTime.MaxValue,
                    Created = now,
                    CreatedBy = 62,
                    CreatedByAlias = "",
                    Fulltext = "",
                    Hits = 0,
                    Images = "",
                    Introtext = "",
                    Mask = 0,
                    Metadata = "robots=\nauthor=",
                    Metadesc = "",
                    Metakey = "",
                    Modified = now,
                    ModifiedBy = 62,
                    Ordering = -1,
                    Parentid = 0,
                    PublishDown = DateTime.MaxValue,
                    PublishUp = now,
                    Sectionid = (uint)SectionsEnum.CONFERENCES_PROGRAM,
                    State = 1,
                    Title = inputForm.Value,
                    TitleAlias = "",
                    Urls = "",
                    Version = 1
                };

                _content.Save(theme);

                var themes = _content.GetAll().Where(c =>
                    c.Catid == (uint)CategoriesEnum.CONFERENCES_PROGRAMS && c.Sectionid == (uint)SectionsEnum.CONFERENCES_PROGRAM).OrderBy(c => c.Title);
                listOfConferenceProgramsTheme.DataSource = themes.ToArray();
                listOfConferenceProgramsTheme.Refresh();
            }
        }

        private void btnEditConferenceProgramsTheme_Click(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfConferenceProgramsTheme.SelectedItem;

            if (selected is not null)
            {
                var inputForm = new TextInputForm(selected.Title);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    selected.Title = inputForm.Value;
                    selected.Modified = DateTime.UtcNow;
                    selected.CheckedOutTime = DateTime.MaxValue;
                    selected.PublishDown = DateTime.MaxValue;
                    _content.Save(selected);

                    var themes = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.CONFERENCES_PROGRAMS && c.Sectionid == (uint)SectionsEnum.CONFERENCES_PROGRAM).OrderBy(c => c.Title);
                    listOfConferenceProgramsTheme.DataSource = themes.ToArray();
                    listOfConferenceProgramsTheme.Refresh();
                }
            }
        }

        private void btnRemoveConferenceProgramsTheme_Click(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
            if (selected is not null)
            {
                if (MessageBox.Show($"Вы действительно хотите удалить {selected.Title}?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _content.Remove(selected);

                    var themes = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.CONFERENCES_PROGRAMS && c.Sectionid == (uint)SectionsEnum.CONFERENCES_PROGRAM).OrderBy(c => c.Title);
                    listOfConferenceProgramsTheme.DataSource = themes.ToArray();
                    listOfConferenceProgramsTheme.Refresh();
                }
            }
        }

        private void btnAddConferenceProgram_Click(object sender, EventArgs e)
        {
            var conferenceProgramForm = new ConferenceProgramForm();

            if (conferenceProgramForm.ShowDialog() == DialogResult.OK)
            {
                var selectedTheme = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
                var items = ConferenceProgram.Parse(selectedTheme.Introtext).ToList();
                items.Add(conferenceProgramForm.ConferenceProgram);
                listOfConferencePrograms.DataSource = items.ToArray();
                listOfConferencePrograms.Refresh();

                selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                selectedTheme.Modified = DateTime.UtcNow;
                selectedTheme.CheckedOutTime = DateTime.MaxValue;
                selectedTheme.PublishDown = DateTime.MaxValue;
                _content.Save(selectedTheme);
            }
        }

        private void btnEditConferenceProgram_Click(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = ConferenceProgram.Parse(selectedTheme.Introtext).ToArray();
                var selectedIndex = listOfCollections.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    var conferenceProgramForm = new ConferenceProgramForm(items[selectedIndex]);

                    if (conferenceProgramForm.ShowDialog() == DialogResult.OK)
                    {
                        items[selectedIndex] = conferenceProgramForm.ConferenceProgram;
                        listOfConferencePrograms.DataSource = items;
                        listOfConferencePrograms.Refresh();

                        selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                        selectedTheme.Modified = DateTime.UtcNow;
                        selectedTheme.CheckedOutTime = DateTime.MaxValue;
                        selectedTheme.PublishDown = DateTime.MaxValue;
                        _content.Save(selectedTheme);
                    }
                }
            }
        }

        private void btnDeleteConferenceProgram_Click(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = ConferenceProgram.Parse(selectedTheme.Introtext).ToList();
                var selectedIndex = listOfCollections.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    if (MessageBox.Show($"Вы действительно хотите удалить {items[selectedIndex].Title}?", "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        items.Remove(items[selectedIndex]);
                        listOfConferencePrograms.DataSource = items.ToArray();
                        listOfConferencePrograms.Refresh();

                        selectedTheme.Introtext = string.Join(' ', items.Select(i => i.ToHTML()));
                        selectedTheme.Modified = DateTime.UtcNow;
                        selectedTheme.CheckedOutTime = DateTime.MaxValue;
                        selectedTheme.PublishDown = DateTime.MaxValue;
                        _content.Save(selectedTheme);
                    }
                }
            }
        }

        private void newsDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime dt)
            {
                e.Value = dt.ToLocalTime();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            splashScreen.Close();
        }
    }
}
