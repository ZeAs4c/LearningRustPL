using LearningRustPL.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningRustPL.ViewModels
{
    /// <summary> Класс для ассинхронной работы с таблицей ответов Answers_text. </summary>
    public class AnswerTViewModel
    {
        // Создание обьекта класса SQLiteAsyncConnection, необходимое для того
        // что бы использовать ассинхронные методы для работы с Б.Д.
        SQLiteAsyncConnection database;

        /// <summary> Метод для подключения к таблице. </summary>
        /// <param name="databasePath"> Путь к Б.Д. </param>
        public AnswerTViewModel(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }
        
        /// <summary> Метод создания таблицы. </summary>
        public async Task CreateTable()
        {
            await database.CreateTableAsync<AnswerText>();
        }
        
        /// <summary> Метод получения всех итемов таблицы из Б.Д. </summary>
        public async Task<List<AnswerText>> GetItemsAsync()
        {
            return await database.Table<AnswerText>().ToListAsync();
        }

        /// <summary> Метод получения нужного итема из Б.Д. по id. </summary>
        /// <param name="id"> Итем который нужно получить из Б.Д. </param>
        public async Task<AnswerText> GetItemAsync(int id)
        {
            return await database.GetAsync<AnswerText>(id);
        }

        /// <summary> Метод удаления нужного итема из Б.Д. </summary>
        /// <param name="item"> Итем который нужно удалить в Б.Д. </param>
        public async Task<int> DeleteItemAsync(AnswerText item)
        {
            return await database.DeleteAsync(item);
        }

        /// <summary> Метод сохранения нужного итема в Б.Д. </summary>
        /// <param name="item"> Итем который сохраняется в Б.Д. </param>
        public async Task<int> SaveItemAsync(AnswerText item)
        {
            // Если таблица не пустая то обноваляем значение, иначе вставляем.
            if (item.CodAns != 0)
            {
                await database.UpdateAsync(item);
                return item.CodAns;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}