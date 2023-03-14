using System;
using Xamarin.Forms;
using LearningRustPL.ViewModels;
using System.Reflection;
using System.IO;


namespace LearningRustPL
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent(); // Инициализация компонентов.
            MainPage = new AppShell(); // Указываем, что в качестве MainPage у нас будет выступать AppShell.
        }

        public const string DATABASE_NAME = "BDRustLearning.db3"; // Задаем имя базы данных.

        public static LectureAsyncMethod database; // Объект класса работы с таблицей "Лекции" из Б.Д.

        /// <summary> Метод помогающий в работе с таблицей "Лекции" из Б.Д. </summary>
        public static LectureAsyncMethod Database
        {
            get
            {
                if (database == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppShell)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"LearningRustPL.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database = new LectureAsyncMethod(dbPath);
                }
                return database;
            }

        }

        public static PracticalAsyncMethod database2; // Объект класса работы с таблицей "Практики" из Б.Д.

        /// <summary> Метод помогающий в работе с таблицей "Практики" из Б.Д. </summary>
        public static PracticalAsyncMethod Database2
        {
            get
            {
                if (database2 == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppShell)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"LearningRustPL.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database2 = new PracticalAsyncMethod(dbPath);
                }
                return database2;
            }

        }

        public static AnswerTViewModel database3; // Объект класса работы с таблицей "Ответы" из Б.Д.

        /// <summary> Метод помогающий в работе с таблицей "Ответы" из Б.Д. </summary>
        public static AnswerTViewModel Database3
        {
            get
            {
                if (database3 == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppShell)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"LearningRustPL.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database3 = new AnswerTViewModel(dbPath);
                    
                }
                return database3;
            }

        }

        public static PrTextViewModels database4; // Объект класса работы с таблицей "Текст практики" из Б.Д.

        /// <summary> Метод помогающий в работе с таблицей "Текст практики" из Б.Д. </summary>
        public static PrTextViewModels Database4
        {
            get
            {
                if (database4 == null)
                {
                    // путь, по которому будет находиться база данных
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
                    // если база данных не существует (еще не скопирована)
                    if (!File.Exists(dbPath))
                    {
                        // получаем текущую сборку
                        var assembly = IntrospectionExtensions.GetTypeInfo(typeof(AppShell)).Assembly;
                        // берем из нее ресурс базы данных и создаем из него поток
                        using (Stream stream = assembly.GetManifestResourceStream($"LearningRustPL.{DATABASE_NAME}"))
                        {
                            using (FileStream fs = new FileStream(dbPath, FileMode.OpenOrCreate))
                            {
                                stream.CopyTo(fs);  // копируем файл базы данных в нужное нам место
                                fs.Flush();
                            }
                        }
                    }
                    database4 = new PrTextViewModels(dbPath);

                }
                return database4;
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
