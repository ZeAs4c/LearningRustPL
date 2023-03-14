using SQLite;


namespace LearningRustPL.Models
{
    /// <summary> Класс обьявления полей таблицы из Б.Д., которая нужна для хранения глав </summary>
    [Table("Sections")]
    public class Section
    {
        /// <value name="CodSection"> Обьявление поля соответствующего полю из бд Cod_section. </value>
        [PrimaryKey, AutoIncrement, Column("Cod_section")]
        public int CodSection { get; set; }
        /// <value name="Title_sections"> Обьявление поля соответствующего полю из бд Title_sections. </value>
        public string Title_sections { get; set; }
        /// <value name="Section_passed"> Обьявление поля соответствующего полю из бд Section_passed. </value>
        public bool Section_passed { get; set; }
    }
}
