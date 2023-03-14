using System.Collections.Generic;
using SQLite;
using LearningRustPL.Models;
using System.Threading.Tasks;


namespace LearningRustPL.ViewModels
{
    /// <summary> Класс для ассинхронной работы с таблицей лекций Lectures. </summary>
    public class LectureAsyncMethod
    {
        // Создание обьекта класса SQLiteAsyncConnection, необходимое для того
        // что бы использовать ассинхронные методы для работы с Б.Д.
        SQLiteAsyncConnection database;

        /// <summary> Метод для подключения к таблице. </summary>
        /// <param name="databasePath"> Путь к Б.Д. </param>
        public LectureAsyncMethod(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        /// <summary> Метод создания таблицы. </summary>
        public async Task CreateTable()
        {
            await database.CreateTableAsync<Lectur>();
        }

        /// <summary> Метод получения всех итемов таблицы из Б.Д. </summary>
        public async Task<List<Lectur>> GetItemsAsync()
        {
            return await database.Table<Lectur>().ToListAsync();

        }

        /// <summary> Метод получения нужного итема из Б.Д. по id. </summary>
        /// <param name="id"> Итем который нужно получить из Б.Д. </param>
        public async Task<Lectur> GetItemAsync(int id)
        {
            return await database.GetAsync<Lectur>(id);
        }

        /// <summary> Метод удаления нужного итема из Б.Д. </summary>
        /// <param name="item"> Итем который нужно удалить в Б.Д. </param>
        public async Task<int> DeleteItemAsync(Lectur item)
        {
            return await database.DeleteAsync(item);
        }

        /// <summary> Метод сохранения нужного итема в Б.Д. </summary>
        /// <param name="item"> Итем который сохраняется в Б.Д. </param>
        public async Task<int> SaveItemAsync(Lectur item)
        {
            // Если таблица не пустая то обноваляем значение, иначе вставляем.
            if (item.Cod != 0)
            {
                await database.UpdateAsync(item);
                return item.Cod;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
