using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using LearningRustPL.Models;


namespace LearningRustPL.ViewModels
{
    /// <summary> Класс для ассинхронной работы с таблицей id практик Practical_part. </summary>
    public class PracticalAsyncMethod
    {
        // Создание обьекта класса SQLiteAsyncConnection, необходимое для того
        // что бы использовать ассинхронные методы для работы с Б.Д.
        SQLiteAsyncConnection database;

        /// <summary> Метод для подключения к таблице. </summary>
        /// <param name="databasePath"> Путь к Б.Д. </param>
        public PracticalAsyncMethod(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        /// <summary> Метод создания таблицы. </summary>
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Practical>();
        }

        /// <summary> Метод получения всех итемов таблицы из Б.Д. </summary>
        public async Task<List<Practical>> GetItemsAsync()
        {
            return await database.Table<Practical>().ToListAsync();
        }

        /// <summary> Метод получения нужного итема из Б.Д. по id. </summary>
        /// <param name="id"> Итем который нужно получить из Б.Д. </param>
        public async Task<Practical> GetItemAsync(int id)
        {
            return await database.GetAsync<Practical>(id);
        }

        /// <summary> Метод удаления нужного итема из Б.Д. </summary>
        /// <param name="item"> Итем который нужно удалить в Б.Д. </param>
        public async Task<int> DeleteItemAsync(Practical item)
        {
            return await database.DeleteAsync(item);
        }

        /// <summary> Метод сохранения нужного итема в Б.Д. </summary>
        /// <param name="item"> Итем который сохраняется в Б.Д. </param>
        public async Task<int> SaveItemAsync(Practical item)
        {
            // Если таблица не пустая то обноваляем значение, иначе вставляем.
            if (item.CodPractical != 0)
            {
                await database.UpdateAsync(item);
                return item.CodPractical;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
