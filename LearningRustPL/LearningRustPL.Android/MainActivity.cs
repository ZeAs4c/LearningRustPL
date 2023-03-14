using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;


namespace LearningRustPL.Droid
{   
    // Файл MainActivity.cs, с которого собственно начинается выполнение проекта на Android.
    [Activity(Label = "LearningRustPL", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Здесь производится инициализация платформ Xamarin.Essentials и Xamarin.Forms.
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //экземпляр класса App передается в метод LoadApplication(), происходит запуск приложения Xamarin Forms.
            LoadApplication(new App());
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(19, 19, 19)); // Задание цвета статус бара.
        }

        /// <summary> Для обработки разрешений среды выполнения на Android, Xamarin.Essentials должен получить любой результат onRequestPermissionsResult. </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}