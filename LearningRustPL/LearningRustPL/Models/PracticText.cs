using SQLite;


namespace LearningRustPL.Models
{
    /// <summary> Класс обьявления полей таблицы из Б.Д., которая нужна для хранения текста практик </summary>
    [Table("Text_practical")]
    public class PracticText
    {
        /// <value name="CodText"> Обьявление поля соответствующего полю из бд Cod_Text. </value>
        [PrimaryKey, AutoIncrement, Column("Cod_Text")]
        public int CodText { get; set; }
        /// <value name="Cod_practical"> Обьявление поля соответствующего полю из бд Cod_practical. </value>
        public int Cod_practical { get; set; }
        /// <value name="Text_pr"> Обьявление поля соответствующего полю из бд Text_pr. </value>
        public string Text_pr { get; set; }
    }
}
