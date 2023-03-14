using LearningRustPL.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты "Оглавления" и реализуется логика работы "Оглавления". </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablСontPage : ContentPage
    {
        public TablСontPage()
        {
            InitializeComponent(); // Инициализация компонентов.
        }

        /// <summary> Переопределение этого метода позволяет настроить поведение приложения немедленно до того, как Page становится видимым. </summary>
        protected override async void OnAppearing()
        {
            // создание таблицы, если ее нет
            await App.Database.CreateTable();
            await App.Database3.CreateTable();
            // привязка данных
            LecturList.ItemsSource = await App.Database.GetItemsAsync();
            PracticalList.ItemsSource = await App.Database2.GetItemsAsync();

            base.OnAppearing();
        }

        /// <summary> Отвечает за работу лекций на странице "Оглавление". Чтобы при переходе на нужную лекцию, та открывалась. </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Lectur selectedLecture = (Lectur)e.SelectedItem; // Берем нужную лекцию по индексу при нажатии.
            LecturesPage lecturePage = new LecturesPage(); // Создаем шаблон страницы лекций.
            lecturePage.BindingContext = selectedLecture; // Задаем странице контекст.
            await Navigation.PushAsync(lecturePage); // Пушим страницу в навигацию.
        }

        /// <summary> Отвечает за работу практик на странице "Оглавление". Чтобы при переходе на нужную практику, та открывалась. </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private async void OnItemSelected2(object sender, SelectedItemChangedEventArgs e)
        {    
            Practical selectedPractical = (Practical)e.SelectedItem; // Берем нужную практику по индексу при нажатии.   
            PracticalPage PracticePage = new PracticalPage(); // Создаем шаблон страницы практик.
            PracticePage.BindingContext = selectedPractical; // Задаем странице контекст. 
            await Navigation.PushAsync(PracticePage); // Пушим страницу в навигацию.
        }
    }
}