using AssistantCore.Forms;
using Atom.VectorSiteLibrary.Enums;
using Atom.VectorSiteLibrary.Models;
using Atom.VectorSiteLibrary.Storage;
using NewsEditor.Forms;
using NewsEditorCore;
using NewsEditorCore.Forms;
using NewsEditorCore.Types;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NewsEditor
{
    public partial class MainForm : Form
    {
        private readonly IStorage<JosContent> _content;
        private readonly IStorage<Order> _orders;
        private readonly IStorage<JosContentFrontpage> _contentFrontpage;
        private readonly IWarehouse _warehouse;
        private string _currentPath;
        private readonly SplashScreenForm _splashScreen;

        public MainForm(IWarehouse warehouse, IStorage<JosContent> content, IStorage<JosContentFrontpage> contentFrontpage, IStorage<Order> orders, SplashScreenForm splashScreen)
        {
            var startInitialization = DateTime.UtcNow;

            _splashScreen = splashScreen;
            _splashScreen.Show();
            _warehouse = warehouse;
            _currentPath = warehouse.GetPath();
            _content = content;
            _orders = orders;
            _contentFrontpage = contentFrontpage;

            InitializeComponent();

            RefreshNews();

            foreach (DataGridViewColumn column in newsDataGrid.Columns)
            {
                if (column.Name != "Title" && column.Name != "PublishUp")
                {
                    column.Visible = false;
                }
            }

            // Делаем в реестре приказов поле с текстом многострочным и автоматически расширяемым по высоте.
            gridOrdersReestr.Columns["Label"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            gridOrdersReestr.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            var endInitialization = DateTime.UtcNow;
#if (DEBUG)
            File.AppendAllText(
                Environment.ExpandEnvironmentVariables(
                    "%USERPROFILE%\\Desktop\\log.txt"),
                    endInitialization.ToString("dd-MM-yyyy HH:mm:ss") + " - Initialization span: " + (endInitialization - startInitialization).ToString("G") + "\n"
                );
#elif (RELEASE)
            File.WriteAllText(
                    "initSpan.txt",
                    endInitialization.ToString("dd-MM-yyyy HH:mm:ss") + " - Initialization span: " + (endInitialization - startInitialization).ToString("G") + "\n"
                );
#endif
        }

        private void BtnCreateClick(object sender, EventArgs e)
        {
            var editor = new EditorForm(_warehouse);
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

        private void BtnEditClick(object sender, EventArgs e)
        {
            EditNews();
        }

        private void BtnRemoveClick(object sender, EventArgs e)
        {
            RemoveNews();
        }

        private void EditNews()
        {
            var content = (JosContent)newsDataGrid.SelectedRows[0].DataBoundItem;
            var editor = new EditorForm(_warehouse, content);
            if (editor.ShowDialog(this) == DialogResult.OK)
            {
                _content.Save(editor.Content);
                RefreshNews();
            }
        }
        private void RemoveNews()
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
                        c.Catid == (uint)CategoriesEnum.NEWS && c.Sectionid == (uint)SectionsEnum.NEWS)
                    .OrderByDescending(n => n.PublishUp);
                newsDataGrid.DataSource = news.ToArray();
                newsDataGrid.Refresh();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCopyAddressClick(object sender, EventArgs e)
        {
            CopyAddress();
        }

        private void BtnCreateDirectoryClick(object sender, EventArgs e)
        {
            CreateDirectory();
        }

        private void BtnLoadFileClick(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            RemoveDirectoryItem();
        }

        private void ListBoxEnter(object sender, EventArgs e)
        {
            GoIntoTheFolder();
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

        private void UploadFile()
        {
            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.UploadFile(fileDialog.FileName, _currentPath);
                listBox.Items.Add(newItem);
                listBox.Refresh();
                listBox.SelectedItem = newItem;
            }
        }

        private void CreateDirectory()
        {
            var input = new TextInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                var newItem = _warehouse.CreateDirectory($"{_currentPath}/{input.Value}");
                listBox.Items.Add(newItem);
                listBox.Refresh();
                listBox.SelectedItem = newItem;
            }
        }

        private void GoIntoTheFolder()
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

        private void RemoveDirectoryItem()
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

        private void CopyAddress()
        {
            var selected = (DirectoryItem)listBox.SelectedItem;
            if (selected is not null)
            {
                Clipboard.SetText(_warehouse.GetUrl(selected.FullPath));
            }
        }

        private void ListOfCollectionsThemeSelectedIndexChanged(object sender, EventArgs e)
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

        private void BtnCreateThemeClick(object sender, EventArgs e)
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

        private void BtnEditThemeClick(object sender, EventArgs e)
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

        private void BtnRemoveThemeClick(object sender, EventArgs e)
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

        private void BtnCreateCollectionClick(object sender, EventArgs e)
        {
            var collectionToSaleForm = new CollectionToSaleForm(_warehouse);

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

        private void BtnEditCollectionClick(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfCollectionsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = CollectionToSale.Parse(selectedTheme.Introtext).ToArray();
                var selectedCollectionIndex = listOfCollections.SelectedIndex;
                if (selectedCollectionIndex >= 0)
                {
                    var collectionToSaleForm = new CollectionToSaleForm(_warehouse, items[selectedCollectionIndex]);

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

        private void BtnRemoveCollectionClick(object sender, EventArgs e)
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

        private void ListOfConferenceProgramsThemeSelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (JosContent)listOfConferenceProgramsTheme.SelectedItem;

            if (selected is not null)
            {
                listOfConferencePrograms.DataSource = ConferenceProgram.Parse(selected.Introtext);
                listOfConferencePrograms.Refresh();
            }
        }

        private void BtnCreateConferenceProgramsThemeClick(object sender, EventArgs e)
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

        private void BtnEditConferenceProgramsThemeClick(object sender, EventArgs e)
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

        private void BtnRemoveConferenceProgramsThemeClick(object sender, EventArgs e)
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

        private void BtnAddConferenceProgramClick(object sender, EventArgs e)
        {
            var conferenceProgramForm = new ConferenceProgramForm(_warehouse);

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

        private void BtnEditConferenceProgramClick(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = ConferenceProgram.Parse(selectedTheme.Introtext).ToArray();
                var selectedIndex = listOfConferencePrograms.SelectedIndex;
                if (selectedIndex >= 0)
                {
                    var conferenceProgramForm = new ConferenceProgramForm(_warehouse, items[selectedIndex]);

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

        private void BtnDeleteConferenceProgramClick(object sender, EventArgs e)
        {
            var selectedTheme = (JosContent)listOfConferenceProgramsTheme.SelectedItem;
            if (selectedTheme is not null)
            {
                var items = ConferenceProgram.Parse(selectedTheme.Introtext).ToList();
                var selectedIndex = listOfConferencePrograms.SelectedIndex;
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

        private void NewsDataGridCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DateTime dt)
            {
                e.Value = dt.ToLocalTime();
            }
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            _splashScreen.Close();
        }

        private void TabsControlSelecting(object sender, TabControlCancelEventArgs e)
        {
            var tab = e.TabPage;

            switch (tab.Name)
            {
                case "tabFiles":
                    listBox.DisplayMember = "Label";
                    var list = _warehouse.GetList(_currentPath);
                    listBox.Items.Clear();
                    listBox.Items.AddRange(list);
                    break;
                case "tabProgramsOfConferences":
                    var conferenceProgramsThemes = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.CONFERENCES_PROGRAMS && c.Sectionid == (uint)SectionsEnum.CONFERENCES_PROGRAM).OrderBy(c => c.Title);
                    listOfConferenceProgramsTheme.DisplayMember = "Title";
                    listOfConferenceProgramsTheme.DataSource = conferenceProgramsThemes.ToArray();
                    listOfConferencePrograms.DisplayMember = "Title";
                    break;
                case "tabSaleCollections":
                    var collectionsTheme = _content.GetAll().Where(c =>
                        c.Catid == (uint)CategoriesEnum.SALES_OF_COLLECTIONS && c.Sectionid == (uint)SectionsEnum.SALES_OF_COLLECTIONS).OrderBy(c => c.Title);
                    listOfCollectionsTheme.DisplayMember = "Title";
                    listOfCollections.DisplayMember = "Text";
                    listOfCollectionsTheme.DataSource = collectionsTheme.ToArray();
                    break;
                case "tabOrdersReestr":
                    var orders = _orders.GetAll()
                        .OrderByDescending(_ => _.Date)
                        .ThenByDescending(_ => _.Id)
                        .ToArray();
                    gridOrdersReestr.DataSource = orders;
                    break;
                case "tabNews":
                    break;
                default:
                    MessageBox.Show("Не удалось открыть вкладку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void NewsDataGridKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    EditNews();
                    break;
                case Keys.Delete:
                    RemoveNews();
                    break;
            }
        }

        private void ListBoxKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    GoIntoTheFolder();
                    break;
                case Keys.Delete:
                    RemoveDirectoryItem();
                    break;
                case Keys.C:
                    if (e.Control)
                    {
                        CopyAddress();
                    }
                    break;
                case Keys.N:
                    if (e.Control)
                    {
                        CreateDirectory();
                    }
                    break;
                case Keys.U:
                    if (e.Control)
                    {
                        UploadFile();
                    }
                    break;
            }
        }

        private void btnCreateOrderRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var baseOrder = new Order() { Date = DateTime.Now };
                var lastOrder = _orders.GetAll().Where(_ => _.Date.Year == DateTime.Now.Year)?.OrderBy(_ => _.Id).LastOrDefault();

                if (lastOrder is null || lastOrder.Date.Year < DateTime.Now.Year)
                {
                    baseOrder.Id = 1;
                }
                else
                {
                    baseOrder.Id = lastOrder.Id + 1;
                }

                var orderRecordForm = new OrderRecordForm(baseOrder);

                if (orderRecordForm.ShowDialog() == DialogResult.OK)
                {
                    var orderRecord = orderRecordForm.Order;
                    _orders.Save(orderRecord);

                    var orders = _orders.GetAll()
                        .OrderByDescending(_ => _.Date)
                        .ThenByDescending(_ => _.Id)
                        .ToArray();
                    gridOrdersReestr.DataSource = orders;
                    gridOrdersReestr.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveOrderRecord_Click(object sender, EventArgs e)
        {
            var selected = gridOrdersReestr.SelectedRows[0];

            var selectedOrderRecord = new Order
            {
                Id = long.Parse(selected.Cells["Id"].Value.ToString()),
                Date = DateTime.Parse(selected.Cells["Date"].Value.ToString()),
                Label = selected.Cells["Label"].Value.ToString()
            };

            if (MessageBox.Show($"Вы уверены что хотите удалить приказ: {selectedOrderRecord.Label} ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _orders.Remove(selectedOrderRecord);

                var orders = _orders.GetAll()
                    .OrderByDescending(_ => _.Date)
                    .ThenByDescending(_ => _.Id)
                    .ToArray();
                gridOrdersReestr.DataSource = orders;
                gridOrdersReestr.Refresh();
            }
        }

        private void btnEditOrderRecord_Click(object sender, EventArgs e)
        {
            var selected = gridOrdersReestr.SelectedRows[0];

            var selectedOrderRecord = new Order
            {
                Id = long.Parse(selected.Cells["Id"].Value.ToString()),
                Date = DateTime.Parse(selected.Cells["Date"].Value.ToString()),
                Label = selected.Cells["Label"].Value.ToString()
            };

            var orderRecordForm = new OrderRecordForm(selectedOrderRecord, true);

            if (orderRecordForm.ShowDialog() == DialogResult.OK)
            {
                var orderRecord = orderRecordForm.Order;
                _orders.Save(orderRecord);

                var orders = _orders.GetAll()
                    .OrderByDescending(_ => _.Date)
                    .ThenByDescending(_ => _.Id)
                    .ToArray();
                gridOrdersReestr.DataSource = orders;
                gridOrdersReestr.Refresh();
            }
        }
    }
}
