using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты вкладки ,,Курс" в приложении. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        public CoursePage()
        {
            InitializeComponent();  // Инициализация компонентов.
        }

        /// <summary> Событие кнопки ,,Изучать курс". </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private async void TableOfContents(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TablСontPage"); // По этому пути при нажатии на кнопку открывается вкладка с оглавлением.
        }
    }
}