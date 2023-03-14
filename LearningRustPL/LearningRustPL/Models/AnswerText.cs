using SQLite;


namespace LearningRustPL.Models
{
    /// <summary> Класс обьявления полей таблицы из Б.Д. Answers_text, которая нужна для хранения ответов к тестам. </summary>
    [Table("Answers_text")]
    public class AnswerText
    {   
        /// <value name="CodAns"> Обьявление поля соответствующего полю из бд Cod_answer. </value>
        [PrimaryKey, AutoIncrement, Column("Cod_answer")]
        public int CodAns { get; set; } 
        /// <value name="Possible_answer" >Обьявление поля соответствующего полю из бд Possible_answer. </value>
        public string Possible_answer { get; set; } 
        /// <value name="Correct_answer"> Обьявление поля соответствующего полю из бд Correct_answer. </value>
        public bool Correct_answer { get; set; }
        /// <value name="Cod_practical"> Обьявление поля соответствующего полю из бд Cod_practical.  </value>
        public int Cod_practical { get; set; }
        /// <value name="Cod_Text"> Обьявление поля соответствующего полю из бд Cod_Text.  </value>
        public int Cod_Text { get; set; }
    }
}
