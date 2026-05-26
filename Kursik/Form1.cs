using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FestivalFilm.Core.Collections;
using FestivalFilm.Core.Models;
using FestivalFilm.Data;

namespace Kursik
{
    /// <summary>
    /// Основная форма для работы с базой фильмов: просмотр, добавление, редактирование и удаление записей.
    /// </summary>
    public partial class Form1 : Form
    {
        private const string DbFileFilter =
            "База SQLite (*.db)|*.db|SQLite (*.sqlite)|*.sqlite|Все файлы (*.*)|*.*";

        private SqliteFilmDb _db;
        private readonly FilmDatabase _database = new FilmDatabase();
        private bool _isEditing;
        private FilmRecord _editingRecord;

        /// <summary>
        /// Создаёт форму и инициализирует работу с переданной базой.
        /// </summary>
        /// <param name="db">Экземпляр SqliteFilmDb, представляющий открытую базу.</param>
        public Form1(SqliteFilmDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));

            InitializeComponent();
            InitCombos();
            UpdateDatabaseInfo();
            ReloadFromDb();
        }

        /// <summary>
        /// Инициализировать выпадающие списки (combobox): категории, фильтры и сортировка.
        /// Устанавливает значения по умолчанию и список опций.
        /// </summary>
        private void InitCombos()
        {
            var categories = Enum.GetValues(typeof(FilmCategory)).Cast<FilmCategory>().ToArray();
            cmbCategory.DataSource = categories.ToList();
            cmbCategory.SelectedIndex = 0;

            var filterCategories = new List<string> { "Все" };
            filterCategories.AddRange(categories.Select(c => c.ToString()));
            cmbFilterCategory.DataSource = filterCategories;
            cmbFilterCategory.SelectedIndex = 0;

            cmbSort.DataSource = new List<string>
            {
                "Без сортировки",
                "По названию (А-Я)",
                "По году (убывание)"
            };
            cmbSort.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновляет заголовок формы и метку с именем текущей базы данных.
        /// </summary>
        private void UpdateDatabaseInfo()
        {
            lblCurrentDb.Text = "Текущая база: " + _db.DatabaseFileName;
            Text = "Фестиваль фильмов — " + _db.DatabaseFileName;
        }

        /// <summary>
        /// Перезагрузить данные из базы в память и обновить отображение таблицы.
        /// </summary>
        private void ReloadFromDb()
        {
            _database.LoadFrom(_db.ReadAll());
            ShowAllRecords();
        }

        /// <summary>
        /// Показать все записи (без фильтров) в DataGridView и обновить статус.
        /// </summary>
        private void ShowAllRecords()
        {
            BindGrid(_database.Records);
            UpdateStatus();
        }

        /// <summary>
        /// Обработчик меню "Создать базу". Открывает SaveFileDialog, создаёт новую базу и переключается на неё.
        /// </summary>
        private void menuCreateDb_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = DbFileFilter;
                dialog.Title = "Создать новую базу данных";
                dialog.FileName = "festival.db";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    if (System.IO.File.Exists(dialog.FileName) &&
                        MessageBox.Show(
                            "Файл уже существует. Перезаписать?",
                            "Создание БД",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    var newDb = SqliteFilmDb.CreateNewAt(dialog.FileName);
                    SwitchDatabase(newDb);
                    ClearInputs();
                    MessageBox.Show(
                        "Создана пустая база данных." + Environment.NewLine + _db.DatabasePath,
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось создать базу данных.", ex);
                }
            }
        }

        /// <summary>
        /// Обработчик меню "Удалить все записи" — спрашивает подтверждение и удаляет все записи из текущей базы.
        /// </summary>
        private void menuDeleteDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "Удалить все записи из текущей базы?",
                    "Очистка",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            _db.DeleteAllRecords();
            ClearInputs();
            ReloadFromDb();
        }

        /// <summary>
        /// Обработчик меню "Сохранить копию" — предлагает путь и сохраняет копию файла базы.
        /// </summary>
        private void menuSaveDb_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = DbFileFilter;
                dialog.FileName = _db.DatabaseFileName;
                dialog.Title = "Сохранить копию базы данных";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    _db.SaveCopyTo(dialog.FileName);
                    MessageBox.Show(
                        "Копия сохранена:" + Environment.NewLine + dialog.FileName,
                        "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось сохранить копию.", ex);
                }
            }
        }

        /// <summary>
        /// Обработчик меню "Открыть базу" — открывает существующий файл базы и переключается на него.
        /// </summary>
        private void menuLoadDb_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = DbFileFilter;
                dialog.Title = "Открыть базу данных";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    var opened = SqliteFilmDb.OpenExisting(dialog.FileName);
                    SwitchDatabase(opened);
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось открыть базу данных.", ex);
                }
            }
        }

        /// <summary>
        /// Обработчик экспорта в PDF: открывает SaveFileDialog и вызывает FilmPdfExporter для генерации отчёта.
        /// </summary>
        private void menuExportPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "PDF (*.pdf)|*.pdf";
                dialog.FileName = Path.GetFileNameWithoutExtension(_db.DatabaseFileName) + "_report.pdf";
                dialog.Title = "Сохранить отчёт в PDF";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    FilmPdfExporter.Export(dialog.FileName, _db.DatabaseFileName, _database.Records);
                    MessageBox.Show(
                        "PDF-отчёт сохранён:" + Environment.NewLine + dialog.FileName,
                        "Экспорт",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось создать PDF.", ex);
                }
            }
        }

        /// <summary>
        /// Переключить используемую базу данных (вызывается при открытии/создании новой БД).
        /// Обновляет отображение и загружает записи.
        /// </summary>
        /// <param name="newDatabase">Новый экземпляр SqliteFilmDb.</param>
        private void SwitchDatabase(SqliteFilmDb newDatabase)
        {
            _db = newDatabase;
            // Store full path in recent list (use DatabasePath, not DatabaseFileName)
            RecentFiles.Add(newDatabase.DatabasePath);
            UpdateDatabaseInfo();
            ReloadFromDb();
        }

        /// <summary>
        /// Обработчик кнопки "Выход" на рабочей форме — закрывает текущую форму.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик кнопки "Добавить" — считывает поля формы, вставляет новую запись в БД и обновляет отображение.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryReadInputs(out var film))
            {
                return;
            }

            _db.Insert(film);
            ReloadFromDb();
            ClearInputs();
        }

        /// <summary>
        /// Обработчик кнопки "Изменить/Сохранить" — если не в режиме редактирования, входит в режим редактирования выбранной записи;
        /// если уже в режиме редактирования — сохраняет изменения в БД.
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selected = GetSelected();
            if (!_isEditing)
            {
                // Enter edit mode for selected record
                if (selected == null)
                {
                    MessageBox.Show("Выберите фильм в таблице.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                EnterEditMode(selected);
                return;
            }

            // If already editing, act as Save
            if (_editingRecord == null)
            {
                return;
            }

            if (!TryReadInputs(out var film))
            {
                return;
            }

            film.Id = _editingRecord.Id;
            _db.Update(film);
            ExitEditMode();
            ReloadFromDb();
            ClearInputs();
        }

        /// <summary>
        /// Обработчик кнопки "Удалить" — удаляет выбранную запись из БД и обновляет таблицу.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                MessageBox.Show("Выберите фильм в таблице.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Удалить фильм «" + selected.Title + "»?",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            _db.Delete(selected.Id);
            ReloadFromDb();
            ClearInputs();
        }

        /// <summary>
        /// Обработчик применения фильтров и сортировки: собирает введённые условия, фильтрует и сортирует список и отображает результат.
        /// </summary>
        private void btnApply_Click(object sender, EventArgs e)
        {
            _database.LoadFrom(_db.ReadAll());
            var list = _database.SearchByTitle(txtSearch.Text);

            if (!string.IsNullOrWhiteSpace(txtFilterDirector.Text))
            {
                var directorKey = txtFilterDirector.Text.Trim();
                list = list
                    .Where(f => f.Director != null && f.Director.IndexOf(directorKey, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            if (cmbFilterCategory.SelectedIndex > 0)
            {
                var category = (FilmCategory)(cmbFilterCategory.SelectedIndex - 1);
                list = list.Where(f => f.Category == category).ToList();
            }

            var tempDb = new FilmDatabase();
            tempDb.LoadFrom(list);

            if (cmbSort.SelectedIndex == 1)
            {
                list = tempDb.SortByTitle();
            }
            else if (cmbSort.SelectedIndex == 2)
            {
                list = tempDb.SortByYearDesc();
            }

            BindGrid(list);
        }

        /// <summary>
        /// Сбросить поля фильтрации/поиска к значениям по умолчанию и показать все записи.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtFilterDirector.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            ShowAllRecords();
        }

        /// <summary>
        /// Обработчик изменения выделения в таблице. В текущей реализации поля не заполняются автоматически при выделении.
        /// </summary>
        private void dgvMovies_SelectionChanged(object sender, EventArgs e)
        {
            // Do not auto-populate fields on selection. Fields are filled only when entering edit mode.
            return;
        }

        /// <summary>
        /// Получить выбранную строку как объект FilmRecord или null, если выделения нет.
        /// </summary>
        /// <returns>Выбранная запись или null.</returns>
        private FilmRecord GetSelected()
        {
            return dgvMovies.CurrentRow?.DataBoundItem as FilmRecord;
        }

        /// <summary>
        /// Попытаться прочитать введённые пользователем поля и создать FilmRecord. Возвращает false при ошибке ввода.
        /// </summary>
        /// <param name="film">Созданный объект FilmRecord при успешном чтении.</param>
        /// <returns>True, если ввод корректен; иначе false.</returns>
        private bool TryReadInputs(out FilmRecord film)
        {
            film = null;
            var title = txtTitle.Text.Trim();
            var director = txtDirector.Text.Trim();
            var yearText = txtYear.Text.Trim();
            var boxOfficeText = txtBoxOffice.Text.Trim();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(director))
            {
                MessageBox.Show("Заполните название и режиссёра.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(yearText, out var year) || year < 1888 || year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Укажите корректный год.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(boxOfficeText, out var boxOffice) || boxOffice < 0)
            {
                MessageBox.Show("Укажите корректные кассовые сборы.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!(cmbCategory.SelectedItem is FilmCategory category))
            {
                MessageBox.Show("Выберите категорию.", "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            film = new FilmRecord
            {
                Title = title,
                Director = director,
                ReleaseYear = year,
                Category = category,
                BoxOfficeUsd = boxOffice
            };
            return true;
        }

        /// <summary>
        /// Привязать список записей к DataGridView и настроить заголовки столбцов.
        /// </summary>
        /// <param name="data">Коллекция FilmRecord для отображения.</param>
        private void BindGrid(IEnumerable<FilmRecord> data)
        {
            dgvMovies.DataSource = null;
            dgvMovies.DataSource = data.ToList();

            SetHeader("Title", "Название");
            SetHeader("ReleaseYear", "Год");
            SetHeader("Director", "Режиссёр");
            SetHeader("Category", "Категория");
            SetHeader("BoxOfficeUsd", "Сборы ($)");

            if (dgvMovies.Columns["Id"] != null)
            {
                dgvMovies.Columns["Id"].Visible = false;
            }
        }

        /// <summary>
        /// Установить текст заголовка для столбца DataGridView, если столбец присутствует.
        /// </summary>
        /// <param name="name">Имя свойства/столбца.</param>
        /// <param name="text">Текст заголовка.</param>
        private void SetHeader(string name, string text)
        {
            if (dgvMovies.Columns[name] != null)
            {
                dgvMovies.Columns[name].HeaderText = text;
            }
        }

        /// <summary>
        /// Обновить статусную строку количеством записей в текущей выборке/базе.
        /// </summary>
        private void UpdateStatus()
        {
            lblStatus.Text = "Записей: " + _database.Count;
        }

        /// <summary>
        /// Очистить поля ввода формы и выйти из режима редактирования.
        /// </summary>
        private void ClearInputs()
        {
            txtTitle.Clear();
            txtYear.Clear();
            txtDirector.Clear();
            txtBoxOffice.Clear();
            if (cmbCategory.Items.Count > 0)
            {
                cmbCategory.SelectedIndex = 0;
            }
            // Exiting edit mode when clearing inputs
            ExitEditMode();
        }

        /// <summary>
        /// Войти в режим редактирования: заполнить поля выбранной записью и подготовить интерфейс для сохранения.
        /// </summary>
        /// <param name="selected">Запись для редактирования.</param>
        private void EnterEditMode(FilmRecord selected)
        {
            _isEditing = true;
            _editingRecord = selected;

            // Populate fields with selected record
            txtTitle.Text = selected.Title;
            txtYear.Text = selected.ReleaseYear.ToString();
            txtDirector.Text = selected.Director;
            txtBoxOffice.Text = selected.BoxOfficeUsd.ToString();
            cmbCategory.SelectedItem = selected.Category;

            // Disable Add/Delete while editing, disable Update (start) and show Confirm
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            // Change Update button into Save
            btnUpdate.Enabled = true;
            btnUpdate.Text = "Сохранить";
        }

        /// <summary>
        /// Выйти из режима редактирования, сбросив состояние и доступность кнопок.
        /// </summary>
        private void ExitEditMode()
        {
            _isEditing = false;
            _editingRecord = null;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnUpdate.Text = "Изменить";
        }

        /// <summary>Показывает диалог с сообщением об ошибке.</summary>
        private static void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                message + Environment.NewLine + Environment.NewLine + ex.Message,
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
