namespace Kursik
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExportPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCurrentDb = new System.Windows.Forms.Label();
            this.grpFilm = new System.Windows.Forms.GroupBox();
            this.tlpFilm = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblBoxOffice = new System.Windows.Forms.Label();
            this.txtBoxOffice = new System.Windows.Forms.TextBox();
            this.pnlFilmButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.tlpSearch = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterDirector = new System.Windows.Forms.Label();
            this.txtFilterDirector = new System.Windows.Forms.TextBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.pnlSearchButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvMovies = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuMain.SuspendLayout();
            this.grpFilm.SuspendLayout();
            this.tlpFilm.SuspendLayout();
            this.pnlFilmButtons.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.tlpSearch.SuspendLayout();
            this.pnlSearchButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(841, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreateDb,
            this.menuDeleteDb,
            this.menuSep1,
            this.menuSaveDb,
            this.menuLoadDb,
            this.menuSep2,
            this.menuExportPdf,
            this.menuSep3,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(48, 20);
            this.menuFile.Text = "Файл";
            // 
            // menuCreateDb
            // 
            this.menuCreateDb.Name = "menuCreateDb";
            this.menuCreateDb.Size = new System.Drawing.Size(199, 22);
            this.menuCreateDb.Text = "Создать новую БД...";
            this.menuCreateDb.Click += new System.EventHandler(this.menuCreateDb_Click);
            // 
            // menuDeleteDb
            // 
            this.menuDeleteDb.Name = "menuDeleteDb";
            this.menuDeleteDb.Size = new System.Drawing.Size(199, 22);
            this.menuDeleteDb.Text = "Очистить все записи";
            this.menuDeleteDb.Click += new System.EventHandler(this.menuDeleteDb_Click);
            // 
            // menuSep1
            // 
            this.menuSep1.Name = "menuSep1";
            this.menuSep1.Size = new System.Drawing.Size(196, 6);
            // 
            // menuSaveDb
            // 
            this.menuSaveDb.Name = "menuSaveDb";
            this.menuSaveDb.Size = new System.Drawing.Size(199, 22);
            this.menuSaveDb.Text = "Сохранить копию БД...";
            this.menuSaveDb.Click += new System.EventHandler(this.menuSaveDb_Click);
            // 
            // menuLoadDb
            // 
            this.menuLoadDb.Name = "menuLoadDb";
            this.menuLoadDb.Size = new System.Drawing.Size(199, 22);
            this.menuLoadDb.Text = "Открыть другую БД...";
            this.menuLoadDb.Click += new System.EventHandler(this.menuLoadDb_Click);
            // 
            // menuSep2
            // 
            this.menuSep2.Name = "menuSep2";
            this.menuSep2.Size = new System.Drawing.Size(196, 6);
            // 
            // menuExportPdf
            // 
            this.menuExportPdf.Name = "menuExportPdf";
            this.menuExportPdf.Size = new System.Drawing.Size(199, 22);
            this.menuExportPdf.Text = "Экспорт в PDF...";
            this.menuExportPdf.Click += new System.EventHandler(this.menuExportPdf_Click);
            // 
            // menuSep3
            // 
            this.menuSep3.Name = "menuSep3";
            this.menuSep3.Size = new System.Drawing.Size(196, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(199, 22);
            this.menuExit.Text = "Выход";
            this.menuExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblCurrentDb
            // 
            this.lblCurrentDb.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrentDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblCurrentDb.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblCurrentDb.Location = new System.Drawing.Point(0, 24);
            this.lblCurrentDb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentDb.Name = "lblCurrentDb";
            this.lblCurrentDb.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblCurrentDb.Size = new System.Drawing.Size(841, 23);
            this.lblCurrentDb.TabIndex = 5;
            this.lblCurrentDb.Text = "Текущая база:";
            this.lblCurrentDb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpFilm
            // 
            this.grpFilm.Controls.Add(this.tlpFilm);
            this.grpFilm.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilm.Location = new System.Drawing.Point(0, 47);
            this.grpFilm.Margin = new System.Windows.Forms.Padding(2);
            this.grpFilm.Name = "grpFilm";
            this.grpFilm.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.grpFilm.Size = new System.Drawing.Size(841, 128);
            this.grpFilm.TabIndex = 1;
            this.grpFilm.TabStop = false;
            this.grpFilm.Text = "Данные о фильме";
            // 
            // tlpFilm
            // 
            this.tlpFilm.ColumnCount = 4;
            this.tlpFilm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpFilm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpFilm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFilm.Controls.Add(this.lblTitle, 0, 0);
            this.tlpFilm.Controls.Add(this.txtTitle, 1, 0);
            this.tlpFilm.Controls.Add(this.lblYear, 0, 1);
            this.tlpFilm.Controls.Add(this.txtYear, 1, 1);
            this.tlpFilm.Controls.Add(this.lblCategory, 0, 2);
            this.tlpFilm.Controls.Add(this.cmbCategory, 1, 2);
            this.tlpFilm.Controls.Add(this.txtDirector, 3, 0);
            this.tlpFilm.Controls.Add(this.lblDirector, 2, 0);
            this.tlpFilm.Controls.Add(this.lblBoxOffice, 2, 1);
            this.tlpFilm.Controls.Add(this.txtBoxOffice, 3, 1);
            this.tlpFilm.Controls.Add(this.pnlFilmButtons, 3, 2);
            this.tlpFilm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFilm.Location = new System.Drawing.Point(6, 16);
            this.tlpFilm.Margin = new System.Windows.Forms.Padding(2);
            this.tlpFilm.Name = "tlpFilm";
            this.tlpFilm.RowCount = 3;
            this.tlpFilm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpFilm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpFilm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpFilm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpFilm.Size = new System.Drawing.Size(829, 106);
            this.tlpFilm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(2, 11);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Название:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(77, 8);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(335, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(2, 46);
            this.lblYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(28, 13);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Год:";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYear.Location = new System.Drawing.Point(77, 43);
            this.txtYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(335, 20);
            this.txtYear.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(2, 81);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(39, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Жанр:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(77, 77);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(335, 21);
            this.cmbCategory.TabIndex = 7;
            // 
            // txtDirector
            // 
            this.txtDirector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirector.Location = new System.Drawing.Point(491, 8);
            this.txtDirector.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(336, 20);
            this.txtDirector.TabIndex = 5;
            // 
            // lblDirector
            // 
            this.lblDirector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(416, 11);
            this.lblDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(61, 13);
            this.lblDirector.TabIndex = 4;
            this.lblDirector.Text = "Режиссёр:";
            // 
            // lblBoxOffice
            // 
            this.lblBoxOffice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBoxOffice.AutoSize = true;
            this.lblBoxOffice.Location = new System.Drawing.Point(416, 46);
            this.lblBoxOffice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoxOffice.Name = "lblBoxOffice";
            this.lblBoxOffice.Size = new System.Drawing.Size(43, 13);
            this.lblBoxOffice.TabIndex = 8;
            this.lblBoxOffice.Text = "Сборы:";
            // 
            // txtBoxOffice
            // 
            this.txtBoxOffice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxOffice.Location = new System.Drawing.Point(491, 43);
            this.txtBoxOffice.Margin = new System.Windows.Forms.Padding(2);
            this.txtBoxOffice.Name = "txtBoxOffice";
            this.txtBoxOffice.Size = new System.Drawing.Size(336, 20);
            this.txtBoxOffice.TabIndex = 9;
            // 
            // pnlFilmButtons
            // 
            this.pnlFilmButtons.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlFilmButtons.AutoSize = true;
            this.pnlFilmButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlFilmButtons.Controls.Add(this.btnDelete);
            this.pnlFilmButtons.Controls.Add(this.btnUpdate);
            this.pnlFilmButtons.Controls.Add(this.btnAdd);
            this.pnlFilmButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlFilmButtons.Location = new System.Drawing.Point(491, 76);
            this.pnlFilmButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFilmButtons.Name = "pnlFilmButtons";
            this.pnlFilmButtons.Size = new System.Drawing.Size(207, 23);
            this.pnlFilmButtons.TabIndex = 10;
            this.pnlFilmButtons.WrapContents = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Location = new System.Drawing.Point(147, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Location = new System.Drawing.Point(75, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(68, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Location = new System.Drawing.Point(4, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.tlpSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 175);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(2);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.grpSearch.Size = new System.Drawing.Size(841, 104);
            this.grpSearch.TabIndex = 2;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Поиск, фильтр и сортировка";
            // 
            // tlpSearch
            // 
            this.tlpSearch.ColumnCount = 4;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearch.Controls.Add(this.lblSearch, 0, 0);
            this.tlpSearch.Controls.Add(this.txtSearch, 1, 0);
            this.tlpSearch.Controls.Add(this.lblFilterDirector, 2, 0);
            this.tlpSearch.Controls.Add(this.txtFilterDirector, 3, 0);
            this.tlpSearch.Controls.Add(this.lblFilterCategory, 0, 1);
            this.tlpSearch.Controls.Add(this.cmbFilterCategory, 1, 1);
            this.tlpSearch.Controls.Add(this.lblSort, 2, 1);
            this.tlpSearch.Controls.Add(this.cmbSort, 3, 1);
            this.tlpSearch.Controls.Add(this.pnlSearchButtons, 0, 2);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(6, 16);
            this.tlpSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 3;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpSearch.Size = new System.Drawing.Size(829, 82);
            this.tlpSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(2, 6);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(42, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(77, 3);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(335, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblFilterDirector
            // 
            this.lblFilterDirector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterDirector.AutoSize = true;
            this.lblFilterDirector.Location = new System.Drawing.Point(416, 6);
            this.lblFilterDirector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterDirector.Name = "lblFilterDirector";
            this.lblFilterDirector.Size = new System.Drawing.Size(61, 13);
            this.lblFilterDirector.TabIndex = 2;
            this.lblFilterDirector.Text = "Режиссёр:";
            // 
            // txtFilterDirector
            // 
            this.txtFilterDirector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDirector.Location = new System.Drawing.Point(491, 3);
            this.txtFilterDirector.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterDirector.Name = "txtFilterDirector";
            this.txtFilterDirector.Size = new System.Drawing.Size(336, 20);
            this.txtFilterDirector.TabIndex = 3;
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Location = new System.Drawing.Point(2, 32);
            this.lblFilterCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(39, 13);
            this.lblFilterCategory.TabIndex = 4;
            this.lblFilterCategory.Text = "Жанр:";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(77, 28);
            this.cmbFilterCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(335, 21);
            this.cmbFilterCategory.TabIndex = 5;
            // 
            // lblSort
            // 
            this.lblSort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(416, 32);
            this.lblSort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(70, 13);
            this.lblSort.TabIndex = 6;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(491, 28);
            this.cmbSort.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(336, 21);
            this.cmbSort.TabIndex = 7;
            // 
            // pnlSearchButtons
            // 
            this.pnlSearchButtons.AutoSize = true;
            this.pnlSearchButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpSearch.SetColumnSpan(this.pnlSearchButtons, 4);
            this.pnlSearchButtons.Controls.Add(this.btnReset);
            this.pnlSearchButtons.Controls.Add(this.btnApply);
            this.pnlSearchButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSearchButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlSearchButtons.Location = new System.Drawing.Point(2, 54);
            this.pnlSearchButtons.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchButtons.Name = "pnlSearchButtons";
            this.pnlSearchButtons.Size = new System.Drawing.Size(825, 28);
            this.pnlSearchButtons.TabIndex = 8;
            this.pnlSearchButtons.WrapContents = false;
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.Location = new System.Drawing.Point(777, 0);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(48, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnApply
            // 
            this.btnApply.AutoSize = true;
            this.btnApply.Location = new System.Drawing.Point(699, 0);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(74, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvMovies
            // 
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovies.Location = new System.Drawing.Point(0, 279);
            this.dgvMovies.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMovies.MultiSelect = false;
            this.dgvMovies.Name = "dgvMovies";
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.RowHeadersWidth = 51;
            this.dgvMovies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.Size = new System.Drawing.Size(841, 234);
            this.dgvMovies.TabIndex = 3;
            this.dgvMovies.SelectionChanged += new System.EventHandler(this.dgvMovies_SelectionChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 513);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(841, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 535);
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpFilm);
            this.Controls.Add(this.lblCurrentDb);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 495);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фестиваль фильмов — работа с БД";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.grpFilm.ResumeLayout(false);
            this.tlpFilm.ResumeLayout(false);
            this.tlpFilm.PerformLayout();
            this.pnlFilmButtons.ResumeLayout(false);
            this.pnlFilmButtons.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.tlpSearch.ResumeLayout(false);
            this.tlpSearch.PerformLayout();
            this.pnlSearchButtons.ResumeLayout(false);
            this.pnlSearchButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuCreateDb;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteDb;
        private System.Windows.Forms.ToolStripSeparator menuSep1;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDb;
        private System.Windows.Forms.ToolStripMenuItem menuLoadDb;
        private System.Windows.Forms.ToolStripSeparator menuSep2;
        private System.Windows.Forms.ToolStripMenuItem menuExportPdf;
        private System.Windows.Forms.ToolStripSeparator menuSep3;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label lblCurrentDb;
        private System.Windows.Forms.GroupBox grpFilm;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TableLayoutPanel tlpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterDirector;
        private System.Windows.Forms.TextBox txtFilterDirector;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.FlowLayoutPanel pnlSearchButtons;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvMovies;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tlpFilm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblBoxOffice;
        private System.Windows.Forms.TextBox txtBoxOffice;
        private System.Windows.Forms.FlowLayoutPanel pnlFilmButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
    }
}
