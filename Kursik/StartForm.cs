using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FestivalFilm.Data;

namespace Kursik
{
    /// <summary>
    /// Стартовая форма приложения.
    /// Отображает заголовок и список недавно открытых баз данных.
    /// Обрабатывает создание и открытие баз и передаёт управление в основную форму.
    /// </summary>
    public partial class StartForm : Form
    {
        private const string DbFileFilter =
            "База SQLite (*.db)|*.db|SQLite (*.sqlite)|*.sqlite|Все файлы (*.*)|*.*";

        private List<string> _recentDbs;

        /// <summary>
        /// Создаёт стартовую форму, загружает список недавно открытых баз
        /// и регистрирует обработчики событий.
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            _recentDbs = RecentFiles.GetRecent();
            PopulateRecentListBox();

            using (var about = new AboutForm())
            {
                about.ShowDialog(this);
            }

            lblProgramTitle.DoubleClick += (s, e) =>
            {
                using (var about = new AboutForm())
                    about.ShowDialog(this);
            };

            lstRecent.DoubleClick += (s, e) =>
            {
                if (lstRecent.SelectedIndex < 0 || lstRecent.SelectedIndex >= _recentDbs.Count)
                    return;

                var path = _recentDbs[lstRecent.SelectedIndex];
                if (!File.Exists(path))
                {
                    MessageBox.Show("Файл не найден: " + path, "Файл не найден",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RecentFiles.Remove(path);
                    _recentDbs = RecentFiles.GetRecent();
                    PopulateRecentListBox();
                    return;
                }

                try
                {
                    var db = SqliteFilmDb.OpenExisting(path);
                    RecentFiles.Add(path);
                    _recentDbs = RecentFiles.GetRecent();
                    PopulateRecentListBox();
                    OpenWorkForm(db);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось открыть базу данных.", ex);
                }
            };
        }

        private void StartForm_Shown(object sender, EventArgs e) { }

        /// <summary>
        /// Создать новую базу данных: отображает SaveFileDialog, создаёт файл и открывает рабочую форму.
        /// Также добавляет путь в список последних файлов.
        /// </summary>
        private void btnCreateDb_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = DbFileFilter;
                dialog.Title = "Создать базу данных";
                dialog.FileName = "festival.db";
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    if (File.Exists(dialog.FileName) &&
                        MessageBox.Show(
                            "Файл уже существует. Перезаписать?",
                            "Создание БД",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var db = SqliteFilmDb.CreateNewAt(dialog.FileName);
                    RecentFiles.Add(dialog.FileName);
                    _recentDbs = RecentFiles.GetRecent();
                    PopulateRecentListBox();
                    OpenWorkForm(db);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось создать базу данных.", ex);
                }
            }
        }

        /// <summary>
        /// Открыть существующую базу данных: отображает OpenFileDialog и открывает выбранный файл.
        /// </summary>
        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = DbFileFilter;
                dialog.Title = "Открыть базу данных";
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    var db = SqliteFilmDb.OpenExisting(dialog.FileName);
                    RecentFiles.Add(dialog.FileName);
                    _recentDbs = RecentFiles.GetRecent();
                    PopulateRecentListBox();
                    OpenWorkForm(db);
                }
                catch (Exception ex)
                {
                    ShowError("Не удалось открыть базу данных.", ex);
                }
            }
        }

        /// <summary>
        /// Заполнить ListBox значениями из списка недавних баз.
        /// </summary>
        private void PopulateRecentListBox()
        {
            try
            {
                lstRecent.Items.Clear();
                foreach (var p in _recentDbs)
                    lstRecent.Items.Add(Path.GetFileName(p) + " - " + p);

                if (lstRecent.Items.Count == 0)
                    lstRecent.Items.Add("(пусто)");
            }
            catch { }
        }

        /// <summary>
        /// Очистить список недавно открытых баз данных.
        /// </summary>
        private void lnkClearRecent_LinkClicked(object sender, EventArgs e)
        {
            RecentFiles.Clear();
            _recentDbs = RecentFiles.GetRecent();
            PopulateRecentListBox();
        }

        /// <summary>Завершить приложение.</summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Скрыть стартовую форму и открыть основную рабочую форму для указанной базы.
        /// После закрытия рабочей формы показать стартовую форму снова.
        /// </summary>
        private void OpenWorkForm(SqliteFilmDb db)
        {
            Hide();
            using (var workForm = new Form1(db))
                workForm.ShowDialog();

            if (!IsDisposed)
            {
                _recentDbs = RecentFiles.GetRecent();
                PopulateRecentListBox();
                Show();
            }
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

    /// <summary>
    /// Вспомогательный класс для работы со списком недавно открытых файлов БД.
    /// Хранит список в текстовом файле recent.txt.
    /// </summary>
    internal static class RecentFiles
    {
        private static string RecentPath => Path.Combine(Application.UserAppDataPath, "recent.txt");

        /// <summary>Получить текущий список недавно открытых файлов.</summary>
        public static List<string> GetRecent()
        {
            try
            {
                var path = RecentPath;
                if (!File.Exists(path)) return new List<string>();
                return File.ReadAllLines(path).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            }
            catch
            {
                return new List<string>();
            }
        }

        /// <summary>Полностью очистить список недавних файлов (удаляет recent.txt).</summary>
        public static void Clear()
        {
            try
            {
                var path = RecentPath;
                if (File.Exists(path)) File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось очистить список недавних файлов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>Удалить путь из списка недавних файлов.</summary>
        public static void Remove(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;
            try
            {
                var list = GetRecent();
                if (list.RemoveAll(p => string.Equals(p, filePath, StringComparison.OrdinalIgnoreCase)) == 0)
                    return;
                var dir = Path.GetDirectoryName(RecentPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllLines(RecentPath, list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось обновить список недавних файлов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>Добавить путь в начало списка, убрав дубликаты. Максимум 10 записей.</summary>
        public static void Add(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return;
            try
            {
                var list = GetRecent();
                list.RemoveAll(p => string.Equals(p, filePath, StringComparison.OrdinalIgnoreCase));
                list.Insert(0, filePath);
                if (list.Count > 10) list = list.Take(10).ToList();
                var dir = Path.GetDirectoryName(RecentPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
                File.WriteAllLines(RecentPath, list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить список недавних файлов: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
