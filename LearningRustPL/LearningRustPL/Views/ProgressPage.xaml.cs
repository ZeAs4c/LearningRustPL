using LearningRustPL.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты "Прогресса" в приложении и реализуется логика прогресса пользователя. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressPage : ContentPage
    {
        List<Lectur> lecturList; // Объявление листа, который понадобится для хранения всех лекций.
        
        public ProgressPage()
        {
            InitializeComponent(); // Инициализация компонентов.
        }

        /// <summary> Переопределение этого метода позволяет настроить поведение приложения немедленно до того, как Page становится видимым. </summary>
        protected async override void OnAppearing()
        {
            lecturList = await App.Database.GetItemsAsync(); // Записываем все лекции в лист.
            double complete = 0; // Переменная, счетчик, которая увеличивается, в зависимости от выполненных лекций.

            // Проверка, какое количество выполненных лекций
            for (int i = 0; i < lecturList.Count; i++)
            {
                if (lecturList[i].Lecture_completion)
                { 
                    complete++; 
                }
            }

            // Тут высчитывается процент по формуле колличество выполненных заданий/всего заданий
            ProgBar.Progress = complete / Convert.ToDouble(lecturList.Count); 
            Proc.Text = Convert.ToString((100 * ProgBar.Progress).ToString("G3")); // G3 всегда выводит только 3 цифры.
        }
    }
}