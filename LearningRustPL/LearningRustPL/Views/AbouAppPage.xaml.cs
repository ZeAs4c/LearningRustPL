using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты вкладки ,,О приложении" в приложении. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbouAppPage : ContentPage
    {
        public AbouAppPage()
        {
            InitializeComponent(); // Инициализация компонентов.
        }
    }
}