
namespace NewsEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.newsDataGrid = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PublishUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newsPanel = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tabsControl = new System.Windows.Forms.TabControl();
            this.tabNews = new System.Windows.Forms.TabPage();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tabSaleCollections = new System.Windows.Forms.TabPage();
            this.splitContainerCollections = new System.Windows.Forms.SplitContainer();
            this.listOfCollectionsTheme = new System.Windows.Forms.ListBox();
            this.btnCreateTheme = new System.Windows.Forms.Button();
            this.btnEditTheme = new System.Windows.Forms.Button();
            this.btnRemoveTheme = new System.Windows.Forms.Button();
            this.listOfCollections = new System.Windows.Forms.ListBox();
            this.btnRemoveCollection = new System.Windows.Forms.Button();
            this.btnEditCollection = new System.Windows.Forms.Button();
            this.btnCreateCollection = new System.Windows.Forms.Button();
            this.tabProgramsOfConferences = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnRemoveConferenceProgramsTheme = new System.Windows.Forms.Button();
            this.btnEditConferenceProgramsTheme = new System.Windows.Forms.Button();
            this.btnCreateConferenceProgramsTheme = new System.Windows.Forms.Button();
            this.listOfConferenceProgramsTheme = new System.Windows.Forms.ListBox();
            this.btnDeleteConferenceProgram = new System.Windows.Forms.Button();
            this.btnEditConferenceProgram = new System.Windows.Forms.Button();
            this.btnAddConferenceProgram = new System.Windows.Forms.Button();
            this.listOfConferencePrograms = new System.Windows.Forms.ListBox();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnCreateDirectory = new System.Windows.Forms.Button();
            this.btnCopyAddress = new System.Windows.Forms.Button();
            this.tabOrdersReestr = new System.Windows.Forms.TabPage();
            this.lblFilterEnd = new System.Windows.Forms.Label();
            this.lblFilterStart = new System.Windows.Forms.Label();
            this.dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            this.dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            this.btnFilterReset = new System.Windows.Forms.Button();
            this.btnRemoveOrderRecord = new System.Windows.Forms.Button();
            this.btnEditOrderRecord = new System.Windows.Forms.Button();
            this.btnCreateOrderRecord = new System.Windows.Forms.Button();
            this.gridOrdersReestr = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.newsDataGrid)).BeginInit();
            this.newsPanel.SuspendLayout();
            this.tabsControl.SuspendLayout();
            this.tabNews.SuspendLayout();
            this.tabSaleCollections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCollections)).BeginInit();
            this.splitContainerCollections.Panel1.SuspendLayout();
            this.splitContainerCollections.Panel2.SuspendLayout();
            this.splitContainerCollections.SuspendLayout();
            this.tabProgramsOfConferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabFiles.SuspendLayout();
            this.tabOrdersReestr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrdersReestr)).BeginInit();
            this.SuspendLayout();
            // 
            // newsDataGrid
            // 
            this.newsDataGrid.AllowUserToAddRows = false;
            this.newsDataGrid.AllowUserToDeleteRows = false;
            this.newsDataGrid.AllowUserToResizeColumns = false;
            this.newsDataGrid.AllowUserToResizeRows = false;
            this.newsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.newsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.PublishUp});
            this.newsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.newsDataGrid.MultiSelect = false;
            this.newsDataGrid.Name = "newsDataGrid";
            this.newsDataGrid.ReadOnly = true;
            this.newsDataGrid.RowHeadersVisible = false;
            this.newsDataGrid.RowTemplate.Height = 25;
            this.newsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.newsDataGrid.Size = new System.Drawing.Size(914, 578);
            this.newsDataGrid.TabIndex = 0;
            this.newsDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.NewsDataGridCellFormatting);
            this.newsDataGrid.DoubleClick += new System.EventHandler(this.BtnEditClick);
            this.newsDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewsDataGridKeyDown);
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Заголовок";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // PublishUp
            // 
            this.PublishUp.DataPropertyName = "PublishUp";
            this.PublishUp.HeaderText = "Дата публикации";
            this.PublishUp.Name = "PublishUp";
            this.PublishUp.ReadOnly = true;
            this.PublishUp.Width = 150;
            // 
            // newsPanel
            // 
            this.newsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newsPanel.Controls.Add(this.newsDataGrid);
            this.newsPanel.Location = new System.Drawing.Point(6, 6);
            this.newsPanel.Name = "newsPanel";
            this.newsPanel.Size = new System.Drawing.Size(914, 578);
            this.newsPanel.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(927, 42);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(927, 78);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(150, 30);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemoveClick);
            // 
            // tabsControl
            // 
            this.tabsControl.Controls.Add(this.tabNews);
            this.tabsControl.Controls.Add(this.tabSaleCollections);
            this.tabsControl.Controls.Add(this.tabProgramsOfConferences);
            this.tabsControl.Controls.Add(this.tabFiles);
            this.tabsControl.Controls.Add(this.tabOrdersReestr);
            this.tabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsControl.Location = new System.Drawing.Point(0, 0);
            this.tabsControl.Name = "tabsControl";
            this.tabsControl.SelectedIndex = 0;
            this.tabsControl.Size = new System.Drawing.Size(1094, 620);
            this.tabsControl.TabIndex = 3;
            this.tabsControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabsControlSelecting);
            // 
            // tabNews
            // 
            this.tabNews.Controls.Add(this.newsPanel);
            this.tabNews.Controls.Add(this.btnRemove);
            this.tabNews.Controls.Add(this.btnCreate);
            this.tabNews.Controls.Add(this.btnEdit);
            this.tabNews.Location = new System.Drawing.Point(4, 24);
            this.tabNews.Name = "tabNews";
            this.tabNews.Padding = new System.Windows.Forms.Padding(3);
            this.tabNews.Size = new System.Drawing.Size(1086, 592);
            this.tabNews.TabIndex = 0;
            this.tabNews.Text = "Новости";
            this.tabNews.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Location = new System.Drawing.Point(927, 6);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(150, 30);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreateClick);
            // 
            // tabSaleCollections
            // 
            this.tabSaleCollections.Controls.Add(this.splitContainerCollections);
            this.tabSaleCollections.Location = new System.Drawing.Point(4, 24);
            this.tabSaleCollections.Name = "tabSaleCollections";
            this.tabSaleCollections.Size = new System.Drawing.Size(1086, 592);
            this.tabSaleCollections.TabIndex = 2;
            this.tabSaleCollections.Text = "Продажа сборников";
            this.tabSaleCollections.UseVisualStyleBackColor = true;
            // 
            // splitContainerCollections
            // 
            this.splitContainerCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCollections.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCollections.Name = "splitContainerCollections";
            // 
            // splitContainerCollections.Panel1
            // 
            this.splitContainerCollections.Panel1.Controls.Add(this.listOfCollectionsTheme);
            this.splitContainerCollections.Panel1.Controls.Add(this.btnCreateTheme);
            this.splitContainerCollections.Panel1.Controls.Add(this.btnEditTheme);
            this.splitContainerCollections.Panel1.Controls.Add(this.btnRemoveTheme);
            // 
            // splitContainerCollections.Panel2
            // 
            this.splitContainerCollections.Panel2.Controls.Add(this.listOfCollections);
            this.splitContainerCollections.Panel2.Controls.Add(this.btnRemoveCollection);
            this.splitContainerCollections.Panel2.Controls.Add(this.btnEditCollection);
            this.splitContainerCollections.Panel2.Controls.Add(this.btnCreateCollection);
            this.splitContainerCollections.Size = new System.Drawing.Size(1086, 592);
            this.splitContainerCollections.SplitterDistance = 483;
            this.splitContainerCollections.TabIndex = 7;
            // 
            // listOfCollectionsTheme
            // 
            this.listOfCollectionsTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfCollectionsTheme.FormattingEnabled = true;
            this.listOfCollectionsTheme.ItemHeight = 15;
            this.listOfCollectionsTheme.Location = new System.Drawing.Point(0, 0);
            this.listOfCollectionsTheme.Name = "listOfCollectionsTheme";
            this.listOfCollectionsTheme.Size = new System.Drawing.Size(483, 544);
            this.listOfCollectionsTheme.TabIndex = 0;
            this.listOfCollectionsTheme.SelectedIndexChanged += new System.EventHandler(this.ListOfCollectionsThemeSelectedIndexChanged);
            // 
            // btnCreateTheme
            // 
            this.btnCreateTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTheme.Location = new System.Drawing.Point(9, 554);
            this.btnCreateTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateTheme.Name = "btnCreateTheme";
            this.btnCreateTheme.Size = new System.Drawing.Size(150, 30);
            this.btnCreateTheme.TabIndex = 2;
            this.btnCreateTheme.Text = "Новая тема";
            this.btnCreateTheme.UseVisualStyleBackColor = true;
            this.btnCreateTheme.Click += new System.EventHandler(this.BtnCreateThemeClick);
            // 
            // btnEditTheme
            // 
            this.btnEditTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditTheme.Enabled = false;
            this.btnEditTheme.Location = new System.Drawing.Point(167, 554);
            this.btnEditTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditTheme.Name = "btnEditTheme";
            this.btnEditTheme.Size = new System.Drawing.Size(150, 30);
            this.btnEditTheme.TabIndex = 3;
            this.btnEditTheme.Text = "Переименовать тему";
            this.btnEditTheme.UseVisualStyleBackColor = true;
            this.btnEditTheme.Click += new System.EventHandler(this.BtnEditThemeClick);
            // 
            // btnRemoveTheme
            // 
            this.btnRemoveTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveTheme.Enabled = false;
            this.btnRemoveTheme.Location = new System.Drawing.Point(325, 554);
            this.btnRemoveTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveTheme.Name = "btnRemoveTheme";
            this.btnRemoveTheme.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveTheme.TabIndex = 4;
            this.btnRemoveTheme.Text = "Удалить тему";
            this.btnRemoveTheme.UseVisualStyleBackColor = true;
            this.btnRemoveTheme.Click += new System.EventHandler(this.BtnRemoveThemeClick);
            // 
            // listOfCollections
            // 
            this.listOfCollections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfCollections.FormattingEnabled = true;
            this.listOfCollections.ItemHeight = 15;
            this.listOfCollections.Location = new System.Drawing.Point(0, 0);
            this.listOfCollections.Name = "listOfCollections";
            this.listOfCollections.Size = new System.Drawing.Size(599, 544);
            this.listOfCollections.TabIndex = 1;
            // 
            // btnRemoveCollection
            // 
            this.btnRemoveCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCollection.Location = new System.Drawing.Point(440, 554);
            this.btnRemoveCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveCollection.Name = "btnRemoveCollection";
            this.btnRemoveCollection.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveCollection.TabIndex = 1;
            this.btnRemoveCollection.Text = "Удалить сборник";
            this.btnRemoveCollection.UseVisualStyleBackColor = true;
            this.btnRemoveCollection.Click += new System.EventHandler(this.BtnRemoveCollectionClick);
            // 
            // btnEditCollection
            // 
            this.btnEditCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCollection.Location = new System.Drawing.Point(282, 554);
            this.btnEditCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditCollection.Name = "btnEditCollection";
            this.btnEditCollection.Size = new System.Drawing.Size(150, 30);
            this.btnEditCollection.TabIndex = 5;
            this.btnEditCollection.Text = "Редактировать сборник";
            this.btnEditCollection.UseVisualStyleBackColor = true;
            this.btnEditCollection.Click += new System.EventHandler(this.BtnEditCollectionClick);
            // 
            // btnCreateCollection
            // 
            this.btnCreateCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCollection.Location = new System.Drawing.Point(124, 554);
            this.btnCreateCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateCollection.Name = "btnCreateCollection";
            this.btnCreateCollection.Size = new System.Drawing.Size(150, 30);
            this.btnCreateCollection.TabIndex = 6;
            this.btnCreateCollection.Text = "Добавить сборник";
            this.btnCreateCollection.UseVisualStyleBackColor = true;
            this.btnCreateCollection.Click += new System.EventHandler(this.BtnCreateCollectionClick);
            // 
            // tabProgramsOfConferences
            // 
            this.tabProgramsOfConferences.Controls.Add(this.splitContainer);
            this.tabProgramsOfConferences.Location = new System.Drawing.Point(4, 24);
            this.tabProgramsOfConferences.Name = "tabProgramsOfConferences";
            this.tabProgramsOfConferences.Size = new System.Drawing.Size(1086, 592);
            this.tabProgramsOfConferences.TabIndex = 3;
            this.tabProgramsOfConferences.Text = "Программы конференций";
            this.tabProgramsOfConferences.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.btnRemoveConferenceProgramsTheme);
            this.splitContainer.Panel1.Controls.Add(this.btnEditConferenceProgramsTheme);
            this.splitContainer.Panel1.Controls.Add(this.btnCreateConferenceProgramsTheme);
            this.splitContainer.Panel1.Controls.Add(this.listOfConferenceProgramsTheme);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnDeleteConferenceProgram);
            this.splitContainer.Panel2.Controls.Add(this.btnEditConferenceProgram);
            this.splitContainer.Panel2.Controls.Add(this.btnAddConferenceProgram);
            this.splitContainer.Panel2.Controls.Add(this.listOfConferencePrograms);
            this.splitContainer.Size = new System.Drawing.Size(1086, 592);
            this.splitContainer.SplitterDistance = 481;
            this.splitContainer.TabIndex = 0;
            // 
            // btnRemoveConferenceProgramsTheme
            // 
            this.btnRemoveConferenceProgramsTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveConferenceProgramsTheme.Location = new System.Drawing.Point(320, 554);
            this.btnRemoveConferenceProgramsTheme.Name = "btnRemoveConferenceProgramsTheme";
            this.btnRemoveConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveConferenceProgramsTheme.TabIndex = 3;
            this.btnRemoveConferenceProgramsTheme.Text = "Удалить тему";
            this.btnRemoveConferenceProgramsTheme.UseVisualStyleBackColor = true;
            this.btnRemoveConferenceProgramsTheme.Click += new System.EventHandler(this.BtnRemoveConferenceProgramsThemeClick);
            // 
            // btnEditConferenceProgramsTheme
            // 
            this.btnEditConferenceProgramsTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditConferenceProgramsTheme.Location = new System.Drawing.Point(164, 554);
            this.btnEditConferenceProgramsTheme.Name = "btnEditConferenceProgramsTheme";
            this.btnEditConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            this.btnEditConferenceProgramsTheme.TabIndex = 2;
            this.btnEditConferenceProgramsTheme.Text = "Переименовать тему";
            this.btnEditConferenceProgramsTheme.UseVisualStyleBackColor = true;
            this.btnEditConferenceProgramsTheme.Click += new System.EventHandler(this.BtnEditConferenceProgramsThemeClick);
            // 
            // btnCreateConferenceProgramsTheme
            // 
            this.btnCreateConferenceProgramsTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateConferenceProgramsTheme.Location = new System.Drawing.Point(8, 554);
            this.btnCreateConferenceProgramsTheme.Name = "btnCreateConferenceProgramsTheme";
            this.btnCreateConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            this.btnCreateConferenceProgramsTheme.TabIndex = 1;
            this.btnCreateConferenceProgramsTheme.Text = "Создать тему";
            this.btnCreateConferenceProgramsTheme.UseVisualStyleBackColor = true;
            this.btnCreateConferenceProgramsTheme.Click += new System.EventHandler(this.BtnCreateConferenceProgramsThemeClick);
            // 
            // listOfConferenceProgramsTheme
            // 
            this.listOfConferenceProgramsTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfConferenceProgramsTheme.FormattingEnabled = true;
            this.listOfConferenceProgramsTheme.ItemHeight = 15;
            this.listOfConferenceProgramsTheme.Location = new System.Drawing.Point(0, 0);
            this.listOfConferenceProgramsTheme.Name = "listOfConferenceProgramsTheme";
            this.listOfConferenceProgramsTheme.Size = new System.Drawing.Size(481, 544);
            this.listOfConferenceProgramsTheme.TabIndex = 0;
            this.listOfConferenceProgramsTheme.SelectedIndexChanged += new System.EventHandler(this.ListOfConferenceProgramsThemeSelectedIndexChanged);
            // 
            // btnDeleteConferenceProgram
            // 
            this.btnDeleteConferenceProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteConferenceProgram.Location = new System.Drawing.Point(443, 554);
            this.btnDeleteConferenceProgram.Name = "btnDeleteConferenceProgram";
            this.btnDeleteConferenceProgram.Size = new System.Drawing.Size(150, 30);
            this.btnDeleteConferenceProgram.TabIndex = 4;
            this.btnDeleteConferenceProgram.Text = "Удалить программу";
            this.btnDeleteConferenceProgram.UseVisualStyleBackColor = true;
            this.btnDeleteConferenceProgram.Click += new System.EventHandler(this.BtnDeleteConferenceProgramClick);
            // 
            // btnEditConferenceProgram
            // 
            this.btnEditConferenceProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditConferenceProgram.Location = new System.Drawing.Point(287, 554);
            this.btnEditConferenceProgram.Name = "btnEditConferenceProgram";
            this.btnEditConferenceProgram.Size = new System.Drawing.Size(150, 30);
            this.btnEditConferenceProgram.TabIndex = 3;
            this.btnEditConferenceProgram.Text = "Изменить программу";
            this.btnEditConferenceProgram.UseVisualStyleBackColor = true;
            this.btnEditConferenceProgram.Click += new System.EventHandler(this.BtnEditConferenceProgramClick);
            // 
            // btnAddConferenceProgram
            // 
            this.btnAddConferenceProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddConferenceProgram.Location = new System.Drawing.Point(131, 554);
            this.btnAddConferenceProgram.Name = "btnAddConferenceProgram";
            this.btnAddConferenceProgram.Size = new System.Drawing.Size(150, 30);
            this.btnAddConferenceProgram.TabIndex = 2;
            this.btnAddConferenceProgram.Text = "Добавить программу";
            this.btnAddConferenceProgram.UseVisualStyleBackColor = true;
            this.btnAddConferenceProgram.Click += new System.EventHandler(this.BtnAddConferenceProgramClick);
            // 
            // listOfConferencePrograms
            // 
            this.listOfConferencePrograms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfConferencePrograms.FormattingEnabled = true;
            this.listOfConferencePrograms.ItemHeight = 15;
            this.listOfConferencePrograms.Location = new System.Drawing.Point(0, 0);
            this.listOfConferencePrograms.Name = "listOfConferencePrograms";
            this.listOfConferencePrograms.Size = new System.Drawing.Size(601, 544);
            this.listOfConferencePrograms.TabIndex = 0;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.listBox);
            this.tabFiles.Controls.Add(this.btnDelete);
            this.tabFiles.Controls.Add(this.btnLoadFile);
            this.tabFiles.Controls.Add(this.btnCreateDirectory);
            this.tabFiles.Controls.Add(this.btnCopyAddress);
            this.tabFiles.Location = new System.Drawing.Point(4, 24);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(1086, 592);
            this.tabFiles.TabIndex = 1;
            this.tabFiles.Text = "Файлы";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(6, 6);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(914, 574);
            this.listBox.TabIndex = 7;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxSelectedIndexChanged);
            this.listBox.DoubleClick += new System.EventHandler(this.ListBoxEnter);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxKeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(927, 550);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 30);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.Location = new System.Drawing.Point(927, 42);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(150, 30);
            this.btnLoadFile.TabIndex = 4;
            this.btnLoadFile.Text = "Загрузить файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.BtnLoadFileClick);
            // 
            // btnCreateDirectory
            // 
            this.btnCreateDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDirectory.Location = new System.Drawing.Point(927, 6);
            this.btnCreateDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateDirectory.Name = "btnCreateDirectory";
            this.btnCreateDirectory.Size = new System.Drawing.Size(150, 30);
            this.btnCreateDirectory.TabIndex = 2;
            this.btnCreateDirectory.Text = "Создать папку";
            this.btnCreateDirectory.UseVisualStyleBackColor = true;
            this.btnCreateDirectory.Click += new System.EventHandler(this.BtnCreateDirectoryClick);
            // 
            // btnCopyAddress
            // 
            this.btnCopyAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyAddress.Enabled = false;
            this.btnCopyAddress.Location = new System.Drawing.Point(927, 514);
            this.btnCopyAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCopyAddress.Name = "btnCopyAddress";
            this.btnCopyAddress.Size = new System.Drawing.Size(150, 30);
            this.btnCopyAddress.TabIndex = 1;
            this.btnCopyAddress.Text = "Скопировать адрес";
            this.btnCopyAddress.UseVisualStyleBackColor = true;
            this.btnCopyAddress.Click += new System.EventHandler(this.BtnCopyAddressClick);
            // 
            // tabOrdersReestr
            // 
            this.tabOrdersReestr.Controls.Add(this.lblFilterEnd);
            this.tabOrdersReestr.Controls.Add(this.lblFilterStart);
            this.tabOrdersReestr.Controls.Add(this.dtpFilterStart);
            this.tabOrdersReestr.Controls.Add(this.dtpFilterEnd);
            this.tabOrdersReestr.Controls.Add(this.btnFilterReset);
            this.tabOrdersReestr.Controls.Add(this.btnRemoveOrderRecord);
            this.tabOrdersReestr.Controls.Add(this.btnEditOrderRecord);
            this.tabOrdersReestr.Controls.Add(this.btnCreateOrderRecord);
            this.tabOrdersReestr.Controls.Add(this.gridOrdersReestr);
            this.tabOrdersReestr.Location = new System.Drawing.Point(4, 24);
            this.tabOrdersReestr.Name = "tabOrdersReestr";
            this.tabOrdersReestr.Size = new System.Drawing.Size(1086, 592);
            this.tabOrdersReestr.TabIndex = 4;
            this.tabOrdersReestr.Text = "Реестр приказов";
            this.tabOrdersReestr.UseVisualStyleBackColor = true;
            // 
            // lblFilterEnd
            // 
            this.lblFilterEnd.AutoSize = true;
            this.lblFilterEnd.Location = new System.Drawing.Point(929, 507);
            this.lblFilterEnd.Name = "lblFilterEnd";
            this.lblFilterEnd.Size = new System.Drawing.Size(21, 15);
            this.lblFilterEnd.TabIndex = 3;
            this.lblFilterEnd.Text = "по";
            // 
            // lblFilterStart
            // 
            this.lblFilterStart.AutoSize = true;
            this.lblFilterStart.Location = new System.Drawing.Point(929, 463);
            this.lblFilterStart.Name = "lblFilterStart";
            this.lblFilterStart.Size = new System.Drawing.Size(63, 15);
            this.lblFilterStart.TabIndex = 3;
            this.lblFilterStart.Text = "Выбрать с";
            // 
            // dtpFilterStart
            // 
            this.dtpFilterStart.CustomFormat = "dd:MM:yyyy";
            this.dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterStart.Location = new System.Drawing.Point(929, 481);
            this.dtpFilterStart.Name = "dtpFilterStart";
            this.dtpFilterStart.Size = new System.Drawing.Size(150, 23);
            this.dtpFilterStart.TabIndex = 2;
            this.dtpFilterStart.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // dtpFilterEnd
            // 
            this.dtpFilterEnd.CustomFormat = "dd:MM:yyyy";
            this.dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFilterEnd.Location = new System.Drawing.Point(929, 525);
            this.dtpFilterEnd.Name = "dtpFilterEnd";
            this.dtpFilterEnd.Size = new System.Drawing.Size(148, 23);
            this.dtpFilterEnd.TabIndex = 2;
            this.dtpFilterEnd.ValueChanged += new System.EventHandler(this.dtpFilter_ValueChanged);
            // 
            // btnFilterReset
            // 
            this.btnFilterReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilterReset.Location = new System.Drawing.Point(927, 554);
            this.btnFilterReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFilterReset.Name = "btnFilterReset";
            this.btnFilterReset.Size = new System.Drawing.Size(150, 30);
            this.btnFilterReset.TabIndex = 1;
            this.btnFilterReset.Text = "Сбросить";
            this.btnFilterReset.UseVisualStyleBackColor = true;
            this.btnFilterReset.Click += new System.EventHandler(this.btnFilterReset_Click);
            // 
            // btnRemoveOrderRecord
            // 
            this.btnRemoveOrderRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveOrderRecord.Location = new System.Drawing.Point(927, 75);
            this.btnRemoveOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRemoveOrderRecord.Name = "btnRemoveOrderRecord";
            this.btnRemoveOrderRecord.Size = new System.Drawing.Size(150, 30);
            this.btnRemoveOrderRecord.TabIndex = 1;
            this.btnRemoveOrderRecord.Text = "Удалить";
            this.btnRemoveOrderRecord.UseVisualStyleBackColor = true;
            this.btnRemoveOrderRecord.Click += new System.EventHandler(this.btnRemoveOrderRecord_Click);
            // 
            // btnEditOrderRecord
            // 
            this.btnEditOrderRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditOrderRecord.Location = new System.Drawing.Point(927, 39);
            this.btnEditOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEditOrderRecord.Name = "btnEditOrderRecord";
            this.btnEditOrderRecord.Size = new System.Drawing.Size(150, 30);
            this.btnEditOrderRecord.TabIndex = 1;
            this.btnEditOrderRecord.Text = "Редактировать";
            this.btnEditOrderRecord.UseVisualStyleBackColor = true;
            this.btnEditOrderRecord.Click += new System.EventHandler(this.btnEditOrderRecord_Click);
            // 
            // btnCreateOrderRecord
            // 
            this.btnCreateOrderRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrderRecord.Location = new System.Drawing.Point(927, 3);
            this.btnCreateOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCreateOrderRecord.Name = "btnCreateOrderRecord";
            this.btnCreateOrderRecord.Size = new System.Drawing.Size(150, 30);
            this.btnCreateOrderRecord.TabIndex = 1;
            this.btnCreateOrderRecord.Text = "Создать";
            this.btnCreateOrderRecord.UseVisualStyleBackColor = true;
            this.btnCreateOrderRecord.Click += new System.EventHandler(this.btnCreateOrderRecord_Click);
            // 
            // gridOrdersReestr
            // 
            this.gridOrdersReestr.AllowUserToAddRows = false;
            this.gridOrdersReestr.AllowUserToDeleteRows = false;
            this.gridOrdersReestr.AllowUserToResizeColumns = false;
            this.gridOrdersReestr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrdersReestr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrdersReestr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Date,
            this.Label});
            this.gridOrdersReestr.Location = new System.Drawing.Point(3, 3);
            this.gridOrdersReestr.Name = "gridOrdersReestr";
            this.gridOrdersReestr.ReadOnly = true;
            this.gridOrdersReestr.RowHeadersVisible = false;
            this.gridOrdersReestr.RowTemplate.Height = 25;
            this.gridOrdersReestr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOrdersReestr.Size = new System.Drawing.Size(917, 586);
            this.gridOrdersReestr.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 75F;
            this.Id.HeaderText = "Номер";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 75F;
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 75;
            // 
            // Label
            // 
            this.Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Label.DataPropertyName = "Label";
            this.Label.HeaderText = "Название";
            this.Label.Name = "Label";
            this.Label.ReadOnly = true;
            this.Label.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 620);
            this.Controls.Add(this.tabsControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Помощник (v.1.3.0)";
            this.Load += new System.EventHandler(this.MainFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.newsDataGrid)).EndInit();
            this.newsPanel.ResumeLayout(false);
            this.tabsControl.ResumeLayout(false);
            this.tabNews.ResumeLayout(false);
            this.tabSaleCollections.ResumeLayout(false);
            this.splitContainerCollections.Panel1.ResumeLayout(false);
            this.splitContainerCollections.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCollections)).EndInit();
            this.splitContainerCollections.ResumeLayout(false);
            this.tabProgramsOfConferences.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabFiles.ResumeLayout(false);
            this.tabOrdersReestr.ResumeLayout(false);
            this.tabOrdersReestr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrdersReestr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel newsPanel;
        private System.Windows.Forms.DataGridView newsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn PublishUp;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TabControl tabsControl;
        private System.Windows.Forms.TabPage tabNews;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.Button btnCopyAddress;
        private System.Windows.Forms.Button btnCreateDirectory;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TabPage tabSaleCollections;
        private System.Windows.Forms.TabPage tabProgramsOfConferences;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRemoveCollection;
        private System.Windows.Forms.ListBox listOfCollections;
        private System.Windows.Forms.ListBox listOfCollectionsTheme;
        private System.Windows.Forms.Button btnCreateCollection;
        private System.Windows.Forms.Button btnEditCollection;
        private System.Windows.Forms.Button btnRemoveTheme;
        private System.Windows.Forms.Button btnEditTheme;
        private System.Windows.Forms.Button btnCreateTheme;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnRemoveConferenceProgramsTheme;
        private System.Windows.Forms.Button btnEditConferenceProgramsTheme;
        private System.Windows.Forms.Button btnCreateConferenceProgramsTheme;
        private System.Windows.Forms.ListBox listOfConferenceProgramsTheme;
        private System.Windows.Forms.Button btnDeleteConferenceProgram;
        private System.Windows.Forms.Button btnEditConferenceProgram;
        private System.Windows.Forms.Button btnAddConferenceProgram;
        private System.Windows.Forms.ListBox listOfConferencePrograms;
        private System.Windows.Forms.SplitContainer splitContainerCollections;
        private System.Windows.Forms.TabPage tabOrdersReestr;
        private System.Windows.Forms.Button btnCreateOrderRecord;
        private System.Windows.Forms.DataGridView gridOrdersReestr;
        private System.Windows.Forms.Button btnRemoveOrderRecord;
        private System.Windows.Forms.Button btnEditOrderRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Button btnFilterReset;
    }
}

