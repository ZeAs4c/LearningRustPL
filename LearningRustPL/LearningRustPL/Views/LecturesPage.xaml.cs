using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты лекций в приложении. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LecturesPage : ContentPage
    {
        public LecturesPage()
        {
            InitializeComponent(); // Инициализация компонентов.
        }
    }
}