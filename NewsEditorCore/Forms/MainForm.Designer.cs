
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            newsDataGrid = new System.Windows.Forms.DataGridView();
            Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            PublishUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            newsPanel = new System.Windows.Forms.Panel();
            btnEdit = new System.Windows.Forms.Button();
            btnRemove = new System.Windows.Forms.Button();
            tabsControl = new System.Windows.Forms.TabControl();
            tabNews = new System.Windows.Forms.TabPage();
            btnCreate = new System.Windows.Forms.Button();
            tabSaleCollections = new System.Windows.Forms.TabPage();
            splitContainerCollections = new System.Windows.Forms.SplitContainer();
            listOfCollectionsTheme = new System.Windows.Forms.ListBox();
            btnCreateTheme = new System.Windows.Forms.Button();
            btnEditTheme = new System.Windows.Forms.Button();
            btnRemoveTheme = new System.Windows.Forms.Button();
            listOfCollections = new System.Windows.Forms.ListBox();
            btnRemoveCollection = new System.Windows.Forms.Button();
            btnEditCollection = new System.Windows.Forms.Button();
            btnCreateCollection = new System.Windows.Forms.Button();
            tabProgramsOfConferences = new System.Windows.Forms.TabPage();
            splitContainer = new System.Windows.Forms.SplitContainer();
            btnRemoveConferenceProgramsTheme = new System.Windows.Forms.Button();
            btnEditConferenceProgramsTheme = new System.Windows.Forms.Button();
            btnCreateConferenceProgramsTheme = new System.Windows.Forms.Button();
            listOfConferenceProgramsTheme = new System.Windows.Forms.ListBox();
            btnDeleteConferenceProgram = new System.Windows.Forms.Button();
            btnEditConferenceProgram = new System.Windows.Forms.Button();
            btnAddConferenceProgram = new System.Windows.Forms.Button();
            listOfConferencePrograms = new System.Windows.Forms.ListBox();
            tabFiles = new System.Windows.Forms.TabPage();
            qrCodeBox = new System.Windows.Forms.PictureBox();
            listBox = new System.Windows.Forms.ListBox();
            btnDelete = new System.Windows.Forms.Button();
            btnLoadFile = new System.Windows.Forms.Button();
            btnCreateDirectory = new System.Windows.Forms.Button();
            btnCopyAddress = new System.Windows.Forms.Button();
            tabOrdersReestr = new System.Windows.Forms.TabPage();
            lblFilterEnd = new System.Windows.Forms.Label();
            lblFilterStart = new System.Windows.Forms.Label();
            dtpFilterStart = new System.Windows.Forms.DateTimePicker();
            dtpFilterEnd = new System.Windows.Forms.DateTimePicker();
            btnFilterReset = new System.Windows.Forms.Button();
            btnPrintOrderReestr = new System.Windows.Forms.Button();
            btnRemoveOrderRecord = new System.Windows.Forms.Button();
            btnEditOrderRecord = new System.Windows.Forms.Button();
            btnCreateOrderRecord = new System.Windows.Forms.Button();
            gridOrdersReestr = new System.Windows.Forms.DataGridView();
            Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ordersReestrPrintDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)newsDataGrid).BeginInit();
            newsPanel.SuspendLayout();
            tabsControl.SuspendLayout();
            tabNews.SuspendLayout();
            tabSaleCollections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerCollections).BeginInit();
            splitContainerCollections.Panel1.SuspendLayout();
            splitContainerCollections.Panel2.SuspendLayout();
            splitContainerCollections.SuspendLayout();
            tabProgramsOfConferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qrCodeBox).BeginInit();
            tabOrdersReestr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridOrdersReestr).BeginInit();
            SuspendLayout();
            // 
            // newsDataGrid
            // 
            newsDataGrid.AllowUserToAddRows = false;
            newsDataGrid.AllowUserToDeleteRows = false;
            newsDataGrid.AllowUserToResizeColumns = false;
            newsDataGrid.AllowUserToResizeRows = false;
            newsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            newsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Title, PublishUp });
            newsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            newsDataGrid.Location = new System.Drawing.Point(0, 0);
            newsDataGrid.MultiSelect = false;
            newsDataGrid.Name = "newsDataGrid";
            newsDataGrid.ReadOnly = true;
            newsDataGrid.RowHeadersVisible = false;
            newsDataGrid.RowTemplate.Height = 25;
            newsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            newsDataGrid.Size = new System.Drawing.Size(914, 578);
            newsDataGrid.TabIndex = 0;
            newsDataGrid.CellFormatting += NewsDataGridCellFormatting;
            newsDataGrid.DoubleClick += BtnEditClick;
            newsDataGrid.KeyDown += NewsDataGridKeyDown;
            // 
            // Title
            // 
            Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Title.DataPropertyName = "Title";
            Title.HeaderText = "Заголовок";
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // PublishUp
            // 
            PublishUp.DataPropertyName = "PublishUp";
            PublishUp.HeaderText = "Дата публикации";
            PublishUp.Name = "PublishUp";
            PublishUp.ReadOnly = true;
            PublishUp.Width = 150;
            // 
            // newsPanel
            // 
            newsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            newsPanel.Controls.Add(newsDataGrid);
            newsPanel.Location = new System.Drawing.Point(6, 6);
            newsPanel.Name = "newsPanel";
            newsPanel.Size = new System.Drawing.Size(914, 578);
            newsPanel.TabIndex = 1;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEdit.Location = new System.Drawing.Point(927, 42);
            btnEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(150, 30);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEditClick;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemove.Location = new System.Drawing.Point(927, 78);
            btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(150, 30);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Удалить";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemoveClick;
            // 
            // tabsControl
            // 
            tabsControl.Controls.Add(tabNews);
            tabsControl.Controls.Add(tabSaleCollections);
            tabsControl.Controls.Add(tabProgramsOfConferences);
            tabsControl.Controls.Add(tabFiles);
            tabsControl.Controls.Add(tabOrdersReestr);
            tabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabsControl.Location = new System.Drawing.Point(0, 0);
            tabsControl.Name = "tabsControl";
            tabsControl.SelectedIndex = 0;
            tabsControl.Size = new System.Drawing.Size(1094, 620);
            tabsControl.TabIndex = 3;
            tabsControl.Selecting += TabsControlSelecting;
            // 
            // tabNews
            // 
            tabNews.Controls.Add(newsPanel);
            tabNews.Controls.Add(btnRemove);
            tabNews.Controls.Add(btnCreate);
            tabNews.Controls.Add(btnEdit);
            tabNews.Location = new System.Drawing.Point(4, 24);
            tabNews.Name = "tabNews";
            tabNews.Padding = new System.Windows.Forms.Padding(3);
            tabNews.Size = new System.Drawing.Size(1086, 592);
            tabNews.TabIndex = 0;
            tabNews.Text = "Новости";
            tabNews.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreate.Location = new System.Drawing.Point(927, 6);
            btnCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new System.Drawing.Size(150, 30);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Создать";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreateClick;
            // 
            // tabSaleCollections
            // 
            tabSaleCollections.Controls.Add(splitContainerCollections);
            tabSaleCollections.Location = new System.Drawing.Point(4, 24);
            tabSaleCollections.Name = "tabSaleCollections";
            tabSaleCollections.Size = new System.Drawing.Size(1086, 592);
            tabSaleCollections.TabIndex = 2;
            tabSaleCollections.Text = "Продажа сборников";
            tabSaleCollections.UseVisualStyleBackColor = true;
            // 
            // splitContainerCollections
            // 
            splitContainerCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerCollections.Location = new System.Drawing.Point(0, 0);
            splitContainerCollections.Name = "splitContainerCollections";
            // 
            // splitContainerCollections.Panel1
            // 
            splitContainerCollections.Panel1.Controls.Add(listOfCollectionsTheme);
            splitContainerCollections.Panel1.Controls.Add(btnCreateTheme);
            splitContainerCollections.Panel1.Controls.Add(btnEditTheme);
            splitContainerCollections.Panel1.Controls.Add(btnRemoveTheme);
            // 
            // splitContainerCollections.Panel2
            // 
            splitContainerCollections.Panel2.Controls.Add(listOfCollections);
            splitContainerCollections.Panel2.Controls.Add(btnRemoveCollection);
            splitContainerCollections.Panel2.Controls.Add(btnEditCollection);
            splitContainerCollections.Panel2.Controls.Add(btnCreateCollection);
            splitContainerCollections.Size = new System.Drawing.Size(1086, 592);
            splitContainerCollections.SplitterDistance = 483;
            splitContainerCollections.TabIndex = 7;
            // 
            // listOfCollectionsTheme
            // 
            listOfCollectionsTheme.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listOfCollectionsTheme.FormattingEnabled = true;
            listOfCollectionsTheme.ItemHeight = 15;
            listOfCollectionsTheme.Location = new System.Drawing.Point(0, 0);
            listOfCollectionsTheme.Name = "listOfCollectionsTheme";
            listOfCollectionsTheme.Size = new System.Drawing.Size(483, 544);
            listOfCollectionsTheme.TabIndex = 0;
            listOfCollectionsTheme.SelectedIndexChanged += ListOfCollectionsThemeSelectedIndexChanged;
            // 
            // btnCreateTheme
            // 
            btnCreateTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnCreateTheme.Location = new System.Drawing.Point(9, 554);
            btnCreateTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateTheme.Name = "btnCreateTheme";
            btnCreateTheme.Size = new System.Drawing.Size(150, 30);
            btnCreateTheme.TabIndex = 2;
            btnCreateTheme.Text = "Новая тема";
            btnCreateTheme.UseVisualStyleBackColor = true;
            btnCreateTheme.Click += BtnCreateThemeClick;
            // 
            // btnEditTheme
            // 
            btnEditTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEditTheme.Enabled = false;
            btnEditTheme.Location = new System.Drawing.Point(167, 554);
            btnEditTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEditTheme.Name = "btnEditTheme";
            btnEditTheme.Size = new System.Drawing.Size(150, 30);
            btnEditTheme.TabIndex = 3;
            btnEditTheme.Text = "Переименовать тему";
            btnEditTheme.UseVisualStyleBackColor = true;
            btnEditTheme.Click += BtnEditThemeClick;
            // 
            // btnRemoveTheme
            // 
            btnRemoveTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnRemoveTheme.Enabled = false;
            btnRemoveTheme.Location = new System.Drawing.Point(325, 554);
            btnRemoveTheme.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveTheme.Name = "btnRemoveTheme";
            btnRemoveTheme.Size = new System.Drawing.Size(150, 30);
            btnRemoveTheme.TabIndex = 4;
            btnRemoveTheme.Text = "Удалить тему";
            btnRemoveTheme.UseVisualStyleBackColor = true;
            btnRemoveTheme.Click += BtnRemoveThemeClick;
            // 
            // listOfCollections
            // 
            listOfCollections.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listOfCollections.FormattingEnabled = true;
            listOfCollections.ItemHeight = 15;
            listOfCollections.Location = new System.Drawing.Point(0, 0);
            listOfCollections.Name = "listOfCollections";
            listOfCollections.Size = new System.Drawing.Size(599, 544);
            listOfCollections.TabIndex = 1;
            // 
            // btnRemoveCollection
            // 
            btnRemoveCollection.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveCollection.Location = new System.Drawing.Point(440, 554);
            btnRemoveCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveCollection.Name = "btnRemoveCollection";
            btnRemoveCollection.Size = new System.Drawing.Size(150, 30);
            btnRemoveCollection.TabIndex = 1;
            btnRemoveCollection.Text = "Удалить сборник";
            btnRemoveCollection.UseVisualStyleBackColor = true;
            btnRemoveCollection.Click += BtnRemoveCollectionClick;
            // 
            // btnEditCollection
            // 
            btnEditCollection.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnEditCollection.Location = new System.Drawing.Point(282, 554);
            btnEditCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEditCollection.Name = "btnEditCollection";
            btnEditCollection.Size = new System.Drawing.Size(150, 30);
            btnEditCollection.TabIndex = 5;
            btnEditCollection.Text = "Редактировать сборник";
            btnEditCollection.UseVisualStyleBackColor = true;
            btnEditCollection.Click += BtnEditCollectionClick;
            // 
            // btnCreateCollection
            // 
            btnCreateCollection.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCreateCollection.Location = new System.Drawing.Point(124, 554);
            btnCreateCollection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateCollection.Name = "btnCreateCollection";
            btnCreateCollection.Size = new System.Drawing.Size(150, 30);
            btnCreateCollection.TabIndex = 6;
            btnCreateCollection.Text = "Добавить сборник";
            btnCreateCollection.UseVisualStyleBackColor = true;
            btnCreateCollection.Click += BtnCreateCollectionClick;
            // 
            // tabProgramsOfConferences
            // 
            tabProgramsOfConferences.Controls.Add(splitContainer);
            tabProgramsOfConferences.Location = new System.Drawing.Point(4, 24);
            tabProgramsOfConferences.Name = "tabProgramsOfConferences";
            tabProgramsOfConferences.Size = new System.Drawing.Size(1086, 592);
            tabProgramsOfConferences.TabIndex = 3;
            tabProgramsOfConferences.Text = "Программы конференций";
            tabProgramsOfConferences.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(btnRemoveConferenceProgramsTheme);
            splitContainer.Panel1.Controls.Add(btnEditConferenceProgramsTheme);
            splitContainer.Panel1.Controls.Add(btnCreateConferenceProgramsTheme);
            splitContainer.Panel1.Controls.Add(listOfConferenceProgramsTheme);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(btnDeleteConferenceProgram);
            splitContainer.Panel2.Controls.Add(btnEditConferenceProgram);
            splitContainer.Panel2.Controls.Add(btnAddConferenceProgram);
            splitContainer.Panel2.Controls.Add(listOfConferencePrograms);
            splitContainer.Size = new System.Drawing.Size(1086, 592);
            splitContainer.SplitterDistance = 481;
            splitContainer.TabIndex = 0;
            // 
            // btnRemoveConferenceProgramsTheme
            // 
            btnRemoveConferenceProgramsTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnRemoveConferenceProgramsTheme.Location = new System.Drawing.Point(320, 554);
            btnRemoveConferenceProgramsTheme.Name = "btnRemoveConferenceProgramsTheme";
            btnRemoveConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            btnRemoveConferenceProgramsTheme.TabIndex = 3;
            btnRemoveConferenceProgramsTheme.Text = "Удалить тему";
            btnRemoveConferenceProgramsTheme.UseVisualStyleBackColor = true;
            btnRemoveConferenceProgramsTheme.Click += BtnRemoveConferenceProgramsThemeClick;
            // 
            // btnEditConferenceProgramsTheme
            // 
            btnEditConferenceProgramsTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnEditConferenceProgramsTheme.Location = new System.Drawing.Point(164, 554);
            btnEditConferenceProgramsTheme.Name = "btnEditConferenceProgramsTheme";
            btnEditConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            btnEditConferenceProgramsTheme.TabIndex = 2;
            btnEditConferenceProgramsTheme.Text = "Переименовать тему";
            btnEditConferenceProgramsTheme.UseVisualStyleBackColor = true;
            btnEditConferenceProgramsTheme.Click += BtnEditConferenceProgramsThemeClick;
            // 
            // btnCreateConferenceProgramsTheme
            // 
            btnCreateConferenceProgramsTheme.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnCreateConferenceProgramsTheme.Location = new System.Drawing.Point(8, 554);
            btnCreateConferenceProgramsTheme.Name = "btnCreateConferenceProgramsTheme";
            btnCreateConferenceProgramsTheme.Size = new System.Drawing.Size(150, 30);
            btnCreateConferenceProgramsTheme.TabIndex = 1;
            btnCreateConferenceProgramsTheme.Text = "Создать тему";
            btnCreateConferenceProgramsTheme.UseVisualStyleBackColor = true;
            btnCreateConferenceProgramsTheme.Click += BtnCreateConferenceProgramsThemeClick;
            // 
            // listOfConferenceProgramsTheme
            // 
            listOfConferenceProgramsTheme.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listOfConferenceProgramsTheme.FormattingEnabled = true;
            listOfConferenceProgramsTheme.ItemHeight = 15;
            listOfConferenceProgramsTheme.Location = new System.Drawing.Point(0, 0);
            listOfConferenceProgramsTheme.Name = "listOfConferenceProgramsTheme";
            listOfConferenceProgramsTheme.Size = new System.Drawing.Size(481, 544);
            listOfConferenceProgramsTheme.TabIndex = 0;
            listOfConferenceProgramsTheme.SelectedIndexChanged += ListOfConferenceProgramsThemeSelectedIndexChanged;
            // 
            // btnDeleteConferenceProgram
            // 
            btnDeleteConferenceProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteConferenceProgram.Location = new System.Drawing.Point(443, 554);
            btnDeleteConferenceProgram.Name = "btnDeleteConferenceProgram";
            btnDeleteConferenceProgram.Size = new System.Drawing.Size(150, 30);
            btnDeleteConferenceProgram.TabIndex = 4;
            btnDeleteConferenceProgram.Text = "Удалить программу";
            btnDeleteConferenceProgram.UseVisualStyleBackColor = true;
            btnDeleteConferenceProgram.Click += BtnDeleteConferenceProgramClick;
            // 
            // btnEditConferenceProgram
            // 
            btnEditConferenceProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnEditConferenceProgram.Location = new System.Drawing.Point(287, 554);
            btnEditConferenceProgram.Name = "btnEditConferenceProgram";
            btnEditConferenceProgram.Size = new System.Drawing.Size(150, 30);
            btnEditConferenceProgram.TabIndex = 3;
            btnEditConferenceProgram.Text = "Изменить программу";
            btnEditConferenceProgram.UseVisualStyleBackColor = true;
            btnEditConferenceProgram.Click += BtnEditConferenceProgramClick;
            // 
            // btnAddConferenceProgram
            // 
            btnAddConferenceProgram.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnAddConferenceProgram.Location = new System.Drawing.Point(131, 554);
            btnAddConferenceProgram.Name = "btnAddConferenceProgram";
            btnAddConferenceProgram.Size = new System.Drawing.Size(150, 30);
            btnAddConferenceProgram.TabIndex = 2;
            btnAddConferenceProgram.Text = "Добавить программу";
            btnAddConferenceProgram.UseVisualStyleBackColor = true;
            btnAddConferenceProgram.Click += BtnAddConferenceProgramClick;
            // 
            // listOfConferencePrograms
            // 
            listOfConferencePrograms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listOfConferencePrograms.FormattingEnabled = true;
            listOfConferencePrograms.ItemHeight = 15;
            listOfConferencePrograms.Location = new System.Drawing.Point(0, 0);
            listOfConferencePrograms.Name = "listOfConferencePrograms";
            listOfConferencePrograms.Size = new System.Drawing.Size(601, 544);
            listOfConferencePrograms.TabIndex = 0;
            // 
            // tabFiles
            // 
            tabFiles.Controls.Add(qrCodeBox);
            tabFiles.Controls.Add(listBox);
            tabFiles.Controls.Add(btnDelete);
            tabFiles.Controls.Add(btnLoadFile);
            tabFiles.Controls.Add(btnCreateDirectory);
            tabFiles.Controls.Add(btnCopyAddress);
            tabFiles.Location = new System.Drawing.Point(4, 24);
            tabFiles.Name = "tabFiles";
            tabFiles.Padding = new System.Windows.Forms.Padding(3);
            tabFiles.Size = new System.Drawing.Size(1086, 592);
            tabFiles.TabIndex = 1;
            tabFiles.Text = "Файлы";
            tabFiles.UseVisualStyleBackColor = true;
            // 
            // qrCodeBox
            // 
            qrCodeBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            qrCodeBox.BackColor = System.Drawing.Color.White;
            qrCodeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            qrCodeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            qrCodeBox.Image = (System.Drawing.Image)resources.GetObject("qrCodeBox.Image");
            qrCodeBox.Location = new System.Drawing.Point(927, 358);
            qrCodeBox.Name = "qrCodeBox";
            qrCodeBox.Padding = new System.Windows.Forms.Padding(5);
            qrCodeBox.Size = new System.Drawing.Size(150, 150);
            qrCodeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            qrCodeBox.TabIndex = 8;
            qrCodeBox.TabStop = false;
            qrCodeBox.Click += qrCodeBox_Click;
            // 
            // listBox
            // 
            listBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 15;
            listBox.Location = new System.Drawing.Point(6, 6);
            listBox.Name = "listBox";
            listBox.Size = new System.Drawing.Size(914, 574);
            listBox.TabIndex = 7;
            listBox.SelectedIndexChanged += ListBoxSelectedIndexChanged;
            listBox.DoubleClick += ListBoxEnter;
            listBox.KeyDown += ListBoxKeyDown;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.Enabled = false;
            btnDelete.Location = new System.Drawing.Point(927, 550);
            btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(150, 30);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDeleteClick;
            // 
            // btnLoadFile
            // 
            btnLoadFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnLoadFile.Location = new System.Drawing.Point(927, 42);
            btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new System.Drawing.Size(150, 30);
            btnLoadFile.TabIndex = 4;
            btnLoadFile.Text = "Загрузить файл";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += BtnLoadFileClick;
            // 
            // btnCreateDirectory
            // 
            btnCreateDirectory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreateDirectory.Location = new System.Drawing.Point(927, 6);
            btnCreateDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateDirectory.Name = "btnCreateDirectory";
            btnCreateDirectory.Size = new System.Drawing.Size(150, 30);
            btnCreateDirectory.TabIndex = 2;
            btnCreateDirectory.Text = "Создать папку";
            btnCreateDirectory.UseVisualStyleBackColor = true;
            btnCreateDirectory.Click += BtnCreateDirectoryClick;
            // 
            // btnCopyAddress
            // 
            btnCopyAddress.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCopyAddress.Enabled = false;
            btnCopyAddress.Location = new System.Drawing.Point(927, 514);
            btnCopyAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCopyAddress.Name = "btnCopyAddress";
            btnCopyAddress.Size = new System.Drawing.Size(150, 30);
            btnCopyAddress.TabIndex = 1;
            btnCopyAddress.Text = "Скопировать адрес";
            btnCopyAddress.UseVisualStyleBackColor = true;
            btnCopyAddress.Click += BtnCopyAddressClick;
            // 
            // tabOrdersReestr
            // 
            tabOrdersReestr.Controls.Add(lblFilterEnd);
            tabOrdersReestr.Controls.Add(lblFilterStart);
            tabOrdersReestr.Controls.Add(dtpFilterStart);
            tabOrdersReestr.Controls.Add(dtpFilterEnd);
            tabOrdersReestr.Controls.Add(btnFilterReset);
            tabOrdersReestr.Controls.Add(btnPrintOrderReestr);
            tabOrdersReestr.Controls.Add(btnRemoveOrderRecord);
            tabOrdersReestr.Controls.Add(btnEditOrderRecord);
            tabOrdersReestr.Controls.Add(btnCreateOrderRecord);
            tabOrdersReestr.Controls.Add(gridOrdersReestr);
            tabOrdersReestr.Location = new System.Drawing.Point(4, 24);
            tabOrdersReestr.Name = "tabOrdersReestr";
            tabOrdersReestr.Size = new System.Drawing.Size(1086, 592);
            tabOrdersReestr.TabIndex = 4;
            tabOrdersReestr.Text = "Реестр приказов";
            tabOrdersReestr.UseVisualStyleBackColor = true;
            // 
            // lblFilterEnd
            // 
            lblFilterEnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblFilterEnd.AutoSize = true;
            lblFilterEnd.Location = new System.Drawing.Point(929, 507);
            lblFilterEnd.Name = "lblFilterEnd";
            lblFilterEnd.Size = new System.Drawing.Size(21, 15);
            lblFilterEnd.TabIndex = 3;
            lblFilterEnd.Text = "по";
            // 
            // lblFilterStart
            // 
            lblFilterStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblFilterStart.AutoSize = true;
            lblFilterStart.Location = new System.Drawing.Point(929, 463);
            lblFilterStart.Name = "lblFilterStart";
            lblFilterStart.Size = new System.Drawing.Size(63, 15);
            lblFilterStart.TabIndex = 3;
            lblFilterStart.Text = "Выбрать с";
            // 
            // dtpFilterStart
            // 
            dtpFilterStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            dtpFilterStart.CustomFormat = "dd:MM:yyyy";
            dtpFilterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFilterStart.Location = new System.Drawing.Point(929, 481);
            dtpFilterStart.Name = "dtpFilterStart";
            dtpFilterStart.Size = new System.Drawing.Size(150, 23);
            dtpFilterStart.TabIndex = 2;
            dtpFilterStart.ValueChanged += dtpFilter_ValueChanged;
            // 
            // dtpFilterEnd
            // 
            dtpFilterEnd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            dtpFilterEnd.CustomFormat = "dd:MM:yyyy";
            dtpFilterEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFilterEnd.Location = new System.Drawing.Point(929, 525);
            dtpFilterEnd.Name = "dtpFilterEnd";
            dtpFilterEnd.Size = new System.Drawing.Size(148, 23);
            dtpFilterEnd.TabIndex = 2;
            dtpFilterEnd.ValueChanged += dtpFilter_ValueChanged;
            // 
            // btnFilterReset
            // 
            btnFilterReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnFilterReset.Location = new System.Drawing.Point(927, 554);
            btnFilterReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFilterReset.Name = "btnFilterReset";
            btnFilterReset.Size = new System.Drawing.Size(150, 30);
            btnFilterReset.TabIndex = 1;
            btnFilterReset.Text = "Сбросить";
            btnFilterReset.UseVisualStyleBackColor = true;
            btnFilterReset.Click += btnFilterReset_Click;
            // 
            // btnPrintOrderReestr
            // 
            btnPrintOrderReestr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnPrintOrderReestr.Location = new System.Drawing.Point(927, 150);
            btnPrintOrderReestr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPrintOrderReestr.Name = "btnPrintOrderReestr";
            btnPrintOrderReestr.Size = new System.Drawing.Size(150, 30);
            btnPrintOrderReestr.TabIndex = 1;
            btnPrintOrderReestr.Text = "Печать";
            btnPrintOrderReestr.UseVisualStyleBackColor = true;
            btnPrintOrderReestr.Click += btnPrintOrderReestr_Click;
            // 
            // btnRemoveOrderRecord
            // 
            btnRemoveOrderRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRemoveOrderRecord.Location = new System.Drawing.Point(927, 75);
            btnRemoveOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveOrderRecord.Name = "btnRemoveOrderRecord";
            btnRemoveOrderRecord.Size = new System.Drawing.Size(150, 30);
            btnRemoveOrderRecord.TabIndex = 1;
            btnRemoveOrderRecord.Text = "Удалить";
            btnRemoveOrderRecord.UseVisualStyleBackColor = true;
            btnRemoveOrderRecord.Click += btnRemoveOrderRecord_Click;
            // 
            // btnEditOrderRecord
            // 
            btnEditOrderRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEditOrderRecord.Location = new System.Drawing.Point(927, 39);
            btnEditOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEditOrderRecord.Name = "btnEditOrderRecord";
            btnEditOrderRecord.Size = new System.Drawing.Size(150, 30);
            btnEditOrderRecord.TabIndex = 1;
            btnEditOrderRecord.Text = "Редактировать";
            btnEditOrderRecord.UseVisualStyleBackColor = true;
            btnEditOrderRecord.Click += btnEditOrderRecord_Click;
            // 
            // btnCreateOrderRecord
            // 
            btnCreateOrderRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCreateOrderRecord.Location = new System.Drawing.Point(927, 3);
            btnCreateOrderRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCreateOrderRecord.Name = "btnCreateOrderRecord";
            btnCreateOrderRecord.Size = new System.Drawing.Size(150, 30);
            btnCreateOrderRecord.TabIndex = 1;
            btnCreateOrderRecord.Text = "Создать";
            btnCreateOrderRecord.UseVisualStyleBackColor = true;
            btnCreateOrderRecord.Click += btnCreateOrderRecord_Click;
            // 
            // gridOrdersReestr
            // 
            gridOrdersReestr.AllowUserToAddRows = false;
            gridOrdersReestr.AllowUserToDeleteRows = false;
            gridOrdersReestr.AllowUserToResizeColumns = false;
            gridOrdersReestr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gridOrdersReestr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridOrdersReestr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Id, Date, Label });
            gridOrdersReestr.Location = new System.Drawing.Point(3, 3);
            gridOrdersReestr.MultiSelect = false;
            gridOrdersReestr.Name = "gridOrdersReestr";
            gridOrdersReestr.ReadOnly = true;
            gridOrdersReestr.RowHeadersVisible = false;
            gridOrdersReestr.RowTemplate.Height = 25;
            gridOrdersReestr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            gridOrdersReestr.Size = new System.Drawing.Size(917, 586);
            gridOrdersReestr.TabIndex = 0;
            // 
            // Id
            // 
            Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Id.DataPropertyName = "Id";
            Id.FillWeight = 75F;
            Id.HeaderText = "Номер";
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 70;
            // 
            // Date
            // 
            Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Date.DataPropertyName = "Date";
            Date.FillWeight = 75F;
            Date.HeaderText = "Дата";
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.Width = 57;
            // 
            // Label
            // 
            Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Label.DataPropertyName = "Label";
            Label.HeaderText = "Название";
            Label.Name = "Label";
            Label.ReadOnly = true;
            Label.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ordersReestrPrintDocument
            // 
            ordersReestrPrintDocument.PrintPage += ordersReestrPrintDocument_PrintPage;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1094, 620);
            Controls.Add(tabsControl);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Помощник (v.1.4.1)";
            Load += MainFormLoad;
            ((System.ComponentModel.ISupportInitialize)newsDataGrid).EndInit();
            newsPanel.ResumeLayout(false);
            tabsControl.ResumeLayout(false);
            tabNews.ResumeLayout(false);
            tabSaleCollections.ResumeLayout(false);
            splitContainerCollections.Panel1.ResumeLayout(false);
            splitContainerCollections.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerCollections).EndInit();
            splitContainerCollections.ResumeLayout(false);
            tabProgramsOfConferences.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)qrCodeBox).EndInit();
            tabOrdersReestr.ResumeLayout(false);
            tabOrdersReestr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridOrdersReestr).EndInit();
            ResumeLayout(false);
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
        private System.Windows.Forms.Label lblFilterEnd;
        private System.Windows.Forms.Label lblFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterStart;
        private System.Windows.Forms.DateTimePicker dtpFilterEnd;
        private System.Windows.Forms.Button btnFilterReset;
        private System.Windows.Forms.Button btnPrintOrderReestr;
        private System.Drawing.Printing.PrintDocument ordersReestrPrintDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.PictureBox qrCodeBox;
    }
}

