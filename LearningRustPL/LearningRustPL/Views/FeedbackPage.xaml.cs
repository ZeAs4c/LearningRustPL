using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты вкладки ,,Оставить отзыв" в приложении. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent(); // Инициализация компонентов.
        }

        /// <summary> Событие кнопки ,,Оставить отзыв". </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private async void GiveFeedback(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TablСontPage"); // Это еще не реализовано, так как нет прав разработчика в Google Play.
        }
    }
}