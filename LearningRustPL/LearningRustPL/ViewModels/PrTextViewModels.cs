using LearningRustPL.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace LearningRustPL.ViewModels
{
    /// <summary> Класс для ассинхронной работы с таблицей текста практик Text_practical. </summary>
    public class PrTextViewModels
    {
        // Создание обьекта класса SQLiteAsyncConnection, необходимое для того
        // что бы использовать ассинхронные методы для работы с Б.Д.
        SQLiteAsyncConnection database;

        /// <summary> Метод для подключения к таблице. </summary>
        /// <param name="databasePath"> Путь к Б.Д. </param>
        public PrTextViewModels(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        /// <summary> Метод создания таблицы. </summary>
        public async Task CreateTable()
        {
            await database.CreateTableAsync<PracticText>();
        }

        /// <summary> Метод получения всех итемов таблицы из Б.Д. </summary>
        public async Task<List<PracticText>> GetItemsAsync()
        {
            return await database.Table<PracticText>().ToListAsync();
        }

        /// <summary> Метод получения нужного итема из Б.Д. по id. </summary>
        /// <param name="id"> Итем который нужно получить из Б.Д. </param>
        public async Task<PracticText> GetItemAsync(int id)
        {
            return await database.GetAsync<PracticText>(id);
        }

        /// <summary> Метод удаления нужного итема из Б.Д. </summary>
        /// <param name="item"> Итем который нужно удалить в Б.Д. </param>
        public async Task<int> DeleteItemAsync(PracticText item)
        {
            return await database.DeleteAsync(item);
        }

        /// <summary> Метод сохранения нужного итема в Б.Д. </summary>
        /// <param name="item"> Итем который сохраняется в Б.Д. </param>
        public async Task<int> SaveItemAsync(PracticText item)
        {
            // Если таблица не пустая то обноваляем значение, иначе вставляем.
            if (item.CodText != 0)
            {
                await database.UpdateAsync(item);
                return item.CodText;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}