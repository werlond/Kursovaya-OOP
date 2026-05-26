using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using FestivalFilm.Core.Models;

namespace FestivalFilm.Data
{
    /// <summary>
    /// Класс-обёртка вокруг SQLite-файла для хранения записей о фильмах.
    /// Предоставляет методы создания/открытия файла и CRUD-операции.
    /// </summary>
    public class SqliteFilmDb
    {
        private readonly string _path;

        /// <summary>Полный путь к файлу базы данных.</summary>
        public string DatabasePath => _path;

        /// <summary>Имя файла базы данных (без пути).</summary>
        public string DatabaseFileName => Path.GetFileName(_path);

        private SqliteFilmDb(string databaseFilePath)
        {
            if (string.IsNullOrWhiteSpace(databaseFilePath))
            {
                throw new ArgumentException("Путь к базе данных не задан.");
            }

            _path = Path.GetFullPath(databaseFilePath);
        }

        /// <summary>
        /// Создать новый файл базы данных по указанному пути (перезапишет существующий).
        /// Возвращает объект SqliteFilmDb для работы с созданной базой.
        /// </summary>
        /// <param name="filePath">Путь к создаваемому файлу.</param>
        public static SqliteFilmDb CreateNewAt(string filePath)
        {
            var fullPath = NormalizeDbPath(filePath);
            var folder = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var db = new SqliteFilmDb(fullPath);
            db.CreateNewDatabase();
            return db;
        }

        /// <summary>
        /// Открыть существующую базу данных и вернуть обёртку для работы с ней.
        /// </summary>
        /// <param name="filePath">Путь к существующему файлу базы.</param>
        public static SqliteFilmDb OpenExisting(string filePath)
        {
            var fullPath = NormalizeDbPath(filePath);
            if (!File.Exists(fullPath))
                throw new FileNotFoundException("Файл базы данных не найден.", fullPath);

            var db = new SqliteFilmDb(fullPath);
            db.EnsureTable();
            return db;
        }

        /// <summary>
        /// Нормализовать путь к файлу базы: полнота пути и добавление расширения .db при отсутствии.
        /// </summary>
        public static string NormalizeDbPath(string filePath)
        {
            var path = Path.GetFullPath(filePath.Trim());
            if (!path.EndsWith(".db", StringComparison.OrdinalIgnoreCase) &&
                !path.EndsWith(".sqlite", StringComparison.OrdinalIgnoreCase) &&
                !path.EndsWith(".sqlite3", StringComparison.OrdinalIgnoreCase))
            {
                path += ".db";
            }

            return path;
        }

        /// <summary>
        /// Создать и вернуть новое подключение к SQLite по текущему пути файла.
        /// </summary>
        /// <returns>Новый экземпляр SqliteConnection (не открыт).</returns>
        private SqliteConnection CreateConnection()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = _path
            };
            return new SqliteConnection(builder.ConnectionString);
        }

        /// <summary>
        /// Убедиться, что таблица Films существует (создать при отсутствии).
        /// </summary>
        public void EnsureTable()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "CREATE TABLE IF NOT EXISTS Films (" +
                        "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "Title TEXT NOT NULL, " +
                        "Director TEXT NOT NULL, " +
                        "ReleaseYear INTEGER NOT NULL, " +
                        "Category INTEGER NOT NULL, " +
                        "BoxOfficeUsd REAL NOT NULL)";
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Создать новую базу данных: удалить старый файл и создать таблицу Films.
        /// </summary>
        public void CreateNewDatabase()
        {
            if (File.Exists(_path))
                File.Delete(_path);

            EnsureTable();
        }

        /// <summary>
        /// Удалить все записи из таблицы Films.
        /// </summary>
        public void DeleteAllRecords()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Films";
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Скопировать текущую базу в новый файл (перезапишет, если существует).
        /// </summary>
        /// <param name="filePath">Целевой путь файла копии.</param>
        public void SaveCopyTo(string filePath)
        {
            var target = NormalizeDbPath(filePath);
            var folder = Path.GetDirectoryName(target);
            if (!string.IsNullOrEmpty(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.Copy(_path, target, true);
        }

        /// <summary>
        /// Прочитать все записи из таблицы Films и вернуть их списком FilmRecord.
        /// </summary>
        /// <returns>Список всех записей.</returns>
        public List<FilmRecord> ReadAll()
        {
            var list = new List<FilmRecord>();

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "SELECT Id, Title, Director, ReleaseYear, Category, BoxOfficeUsd " +
                        "FROM Films ORDER BY Id";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new FilmRecord
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Director = reader.GetString(2),
                                ReleaseYear = reader.GetInt32(3),
                                Category = (FilmCategory)reader.GetInt32(4),
                                BoxOfficeUsd = Convert.ToDecimal(reader.GetDouble(5))
                            });
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Вставить новую запись о фильме и вернуть назначенный Id.
        /// </summary>
        /// <param name="film">Объект FilmRecord для вставки.</param>
        /// <returns>Id добавленной записи.</returns>
        public int Insert(FilmRecord film)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "INSERT INTO Films (Title, Director, ReleaseYear, Category, BoxOfficeUsd) " +
                        "VALUES (@title, @director, @year, @category, @boxOffice); " +
                        "SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@title", film.Title);
                    command.Parameters.AddWithValue("@director", film.Director);
                    command.Parameters.AddWithValue("@year", film.ReleaseYear);
                    command.Parameters.AddWithValue("@category", (int)film.Category);
                    command.Parameters.AddWithValue("@boxOffice", film.BoxOfficeUsd);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Обновить существующую запись фильма по Id.
        /// </summary>
        /// <param name="film">FilmRecord с заполненным Id и новыми значениями.</param>
        public void Update(FilmRecord film)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "UPDATE Films SET Title=@title, Director=@director, ReleaseYear=@year, " +
                        "Category=@category, BoxOfficeUsd=@boxOffice WHERE Id=@id";
                    command.Parameters.AddWithValue("@title", film.Title);
                    command.Parameters.AddWithValue("@director", film.Director);
                    command.Parameters.AddWithValue("@year", film.ReleaseYear);
                    command.Parameters.AddWithValue("@category", (int)film.Category);
                    command.Parameters.AddWithValue("@boxOffice", film.BoxOfficeUsd);
                    command.Parameters.AddWithValue("@id", film.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Удалить запись фильма по Id.
        /// </summary>
        /// <param name="id">Идентификатор записи для удаления.</param>
        public void Delete(int id)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Films WHERE Id=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    /// <summary>
    /// Формирует PDF-отчёт со списком фильмов фестиваля в табличном виде.
    /// </summary>
    public static class FilmPdfExporter
    {
        // Ширина колонок (левый край каждой):
        //   №       : 40   (ширина ~20)
        //   Название: 65   (ширина ~150, до ~215)
        //   Год     : 220  (ширина ~45)
        //   Режиссёр: 270  (ширина ~140, до ~410)
        //   Категория: 415 (ширина ~90, до ~505)
        //   Сборы   : 510  (до правого поля ~555)

        private const double ColNum       = 40;
        private const double ColTitle     = 65;
        private const double ColYear      = 220;
        private const double ColDirector  = 270;
        private const double ColCategory  = 415;
        private const double ColBoxOffice = 510;
        private const double RightMargin  = 555;

        /// <summary>
        /// Экспортировать список фильмов в PDF-файл.
        /// Создаёт простой табличный отчёт с номером, названием, годом, режиссёром, категорией и сборами.
        /// </summary>
        /// <param name="pdfFilePath">Путь к результирующему PDF-файлу.</param>
        /// <param name="databaseFileName">Имя файла базы данных, которое будет указано в шапке отчёта.</param>
        /// <param name="films">Коллекция записей FilmRecord для включения в отчёт.</param>
        public static void Export(string pdfFilePath, string databaseFileName, IEnumerable<FilmRecord> films)
        {
            var document = new PdfDocument();
            document.Info.Title  = "Фестиваль фильмов";
            document.Info.Author = "ИС «Фестиваль фильмов»";

            var page = document.AddPage();
            var gfx  = XGraphics.FromPdfPage(page);

            var fontTitle  = new XFont("Arial", 16, XFontStyle.Bold);
            var fontHeader = new XFont("Arial", 10, XFontStyle.Bold);
            var fontRow    = new XFont("Arial", 10, XFontStyle.Regular);

            double y = 40;

            // --- Шапка отчёта ---
            gfx.DrawString("Отчёт: Фестиваль фильмов", fontTitle, XBrushes.Black, ColNum, y); y += 28;
            gfx.DrawString("База данных: " + databaseFileName, fontRow, XBrushes.Black, ColNum, y); y += 18;
            gfx.DrawString("Дата формирования: " +
                DateTime.Now.ToString("dd.MM.yyyy HH:mm"), fontRow, XBrushes.Black, ColNum, y); y += 28;

            // --- Заголовки колонок ---
            DrawRow(gfx, fontHeader, y, "№", "Название", "Год", "Режиссёр", "Категория", "Сборы ($)");
            y += 4;
            // Разделительная линия под заголовком
            gfx.DrawLine(XPens.Black, ColNum, y, RightMargin, y);
            y += 16;

            // --- Строки данных ---
            int number = 1;
            foreach (var film in films)
            {
                // Новая страница, если не хватает места
                if (y > page.Height.Point - 50)
                {
                    page = document.AddPage();
                    gfx  = XGraphics.FromPdfPage(page);
                    y    = 40;
                }

                DrawRow(gfx, fontRow, y,
                    number.ToString(),
                    Truncate(film.Title    ?? string.Empty, 26),
                    film.ReleaseYear.ToString(),
                    Truncate(film.Director ?? string.Empty, 22),
                    Truncate(film.Category.ToString(), 14),
                    film.BoxOfficeUsd.ToString("N0"));

                y += 18;
                number++;
            }

            if (number == 1)
                gfx.DrawString("Записей в базе нет.", fontRow, XBrushes.Black, ColNum, y);

            document.Save(pdfFilePath);
        }

        /// <summary>Рисует одну строку таблицы по фиксированным колонкам.</summary>
        private static void DrawRow(
            XGraphics gfx, XFont font, double y,
            string num, string title, string year,
            string director, string category, string boxOffice)
        {
            gfx.DrawString(num,        font, XBrushes.Black, ColNum,       y);
            gfx.DrawString(title,      font, XBrushes.Black, ColTitle,     y);
            gfx.DrawString(year,       font, XBrushes.Black, ColYear,      y);
            gfx.DrawString(director,   font, XBrushes.Black, ColDirector,  y);
            gfx.DrawString(category,   font, XBrushes.Black, ColCategory,  y);
            gfx.DrawString(boxOffice,  font, XBrushes.Black, ColBoxOffice, y);
        }

        /// <summary>Обрезает строку до maxChars символов, добавляя «…» если она длиннее.</summary>
        private static string Truncate(string s, int maxChars) =>
            s.Length <= maxChars ? s : s.Substring(0, maxChars - 1) + "…";
    }
}
