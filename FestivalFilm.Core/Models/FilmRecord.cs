using System;

namespace FestivalFilm.Core.Models
{
    /// <summary>Перечисление — сложный тип данных для категории участника фестиваля.</summary>
    public enum FilmCategory
    {
        Художественный = 0,
        Документальный = 1,
        Короткометражный = 2,
        Анимация = 3,
        Биографический = 4,
        Комедия = 5,
        Фантастика = 6
    }

    /// <summary>
    /// Представление записи о фильме, используемое в коллекциях и при сохранении в базе.
    /// </summary>
    public class FilmRecord
    {
        /// <summary>Идентификатор записи (ключ в БД).</summary>
        public int Id { get; set; }

        /// <summary>Название фильма.</summary>
        public string Title { get; set; }

        /// <summary>Режиссёр фильма.</summary>
        public string Director { get; set; }

        /// <summary>Год выпуска .</summary>
        public int ReleaseYear { get; set; }

        /// <summary>Категория фильма (художественный, документальный и т.д.).</summary>
        public FilmCategory Category { get; set; }

        /// <summary>Сборы в долларах США (если применимо).</summary>
        public decimal BoxOfficeUsd { get; set; }
    }
}
