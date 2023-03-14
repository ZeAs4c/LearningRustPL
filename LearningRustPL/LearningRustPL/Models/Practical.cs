using SQLite;


namespace LearningRustPL.Models
{
    /// <summary> Класс обьявления полей таблицы из Б.Д., которая нужна для хранения id практик </summary>
    [Table("Practical_part")]
    public class Practical
    {
        /// <value name="CodPractical"> Обьявление поля соответствующего полю из бд Cod_practical. </value>
        [PrimaryKey, AutoIncrement, Column("Cod_practical")]
        public int CodPractical { get; set; }
        /// <value name="Cod_lecture"> // Обьявление поля соответствующего полю из бд Cod_lecture. </value>
        public int Cod_lecture { get; set; }
        /// <value name="Practice_name"> Обьявление поля соответствующего полю из бд Practice_name. </value>
        public string Practice_name { get; set; }
        /// <value name="Complete_practice"> Обьявление поля соответствующего полю из бд Complete_practice. </value>
        public bool Complete_practice { get; set; }
        /// <value name="Cod_section"> Обьявление поля соответствующего полю из бд Cod_section. </value>
        public string Cod_section { get; set; }
    }
}
