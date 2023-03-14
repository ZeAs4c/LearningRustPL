using SQLite;


namespace LearningRustPL.Models
{
    /// <summary> Класс обьявления полей таблицы из Б.Д., которая нужна для хранения лекций </summary>
    [Table("Lectures")]
    public class Lectur
    {
        /// <value name="Cod"> Обьявление поля соответствующего полю из бд Cod_lecture. </value>
        [PrimaryKey, AutoIncrement, Column("Cod_lecture")]
        public int Cod { get; set; }
        /// <value name="Lecture_title"> Обьявление поля соответствующего полю из бд Lecture_title. </value>
        public string Lecture_title { get; set; }
        /// <value name="Lecture_text"> Обьявление поля соответствующего полю из бд Lecture_text. </value>
        public string Lecture_text { get; set; }
        /// <value name="Lecture_completion"> Обьявление поля соответствующего полю из бд Lecture_completion. </value>
        public bool Lecture_completion { get; set; }
        /// <value name="Lecture_completion"> Обьявление поля соответствующего полю из бд Cod_section. </value>
        public string Cod_section { get; set; }
    }
}
