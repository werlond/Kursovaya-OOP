using System;
using System.Collections.Generic;
using System.Linq;
using FestivalFilm.Core.Models;

namespace FestivalFilm.Core.Collections
{
    /// <summary>
    /// База данных на основе коллекции List&lt;FilmRecord&gt;.
    /// Предоставляет простые операции загрузки, поиска, фильтрации и сортировки в памяти.
    /// Используется как промежуточная модель между слоем данных и UI.
    /// </summary>
    public class FilmDatabase
    {
        private readonly List<FilmRecord> _records = new List<FilmRecord>();

        /// <summary>Количество записей в текущей коллекции.</summary>
        public int Count => _records.Count;

        /// <summary>Текущий список записей в виде ReadOnly списка (чтобы защитить внутреннюю коллекцию).</summary>
        public IReadOnlyList<FilmRecord> Records => _records;

        /// <summary>
        /// Загрузить записи из внешней коллекции в эту базу (заменяет текущее содержимое).
        /// </summary>
        /// <param name="items">Коллекция FilmRecord для загрузки. Если null, коллекция очищается.</param>
        public void LoadFrom(IEnumerable<FilmRecord> items)
        {
            _records.Clear();
            if (items != null)
            {
                _records.AddRange(items);
            }
        }

        /// <summary>
        /// Поиск записей по совпадению в названии (регистронезависимо).
        /// </summary>
        /// <param name="text">Текст для поиска. Если пустой, возвращаются все записи.</param>
        /// <returns>Список совпадающих записей.</returns>
        public List<FilmRecord> SearchByTitle(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return _records.ToList();
            }

            var key = text.Trim();
            return _records
                .Where(r => r.Title != null && r.Title.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        /// <summary>Отсортировать записи по названию (по возрастанию).</summary>
        public List<FilmRecord> SortByTitle()
        {
            return _records.OrderBy(r => r.Title).ToList();
        }

        /// <summary>Отсортировать записи по году выпуска по убыванию.</summary>
        public List<FilmRecord> SortByYearDesc()
        {
            return _records.OrderByDescending(r => r.ReleaseYear).ToList();
        }

    }
}
