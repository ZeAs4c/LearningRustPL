using LearningRustPL.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace LearningRustPL.Views
{
    /// <summary> Класс, в котором инициализируются компоненты лекций в приложении и реализуется логика прохождения курса. </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PracticalPage : ContentPage
    {
        // Объявление листа, которой понадобиться для хранения всех ответов к курсу.
        List<AnswerText> answerList;
        // Объявление листа, которой понадобиться для хранения текстов к конкретным практическим заданиям.
        List<PracticText> prTextList;
        // Объявление листа, которой понадобиться для хранения конкретных ответов к курсу, которые относятся к конкретной практике.
        List<AnswerText>listRadio;
        // Объявление и присваивание нуля переменной, котороя понадобиться для реализации логики прохождения конкретных тестов.
        int ind = 0;
        // Объявление обьекта класса лекций, которые нужны для того, что бы обозначать пройденность лекции после пройденности практики.
        Lectur lectur;
        // Лист радио-баттонов, который является элементом тестов (осуществляет выбор ответа из множества вопросов). 
        List<RadioButton> mRB;
        // Лист булевских значений, благодаря которым проверяется, на сколько конкретно пользователь вопросов ответил правильно в тесте.
        List<bool> check;

        public PracticalPage()
        {
            InitializeComponent(); // Инициализация компонентов.  
        }

        /// <summary> Переопределение этого метода позволяет настроить поведение приложения немедленно до того, как Page становится видимым. </summary>
        protected override async void OnAppearing()
        {
            // Создание таблицы, если ее нет
            await App.Database3.CreateTable(); 

            // Привязка данных
            answerList = await App.Database3.GetItemsAsync();
            prTextList = await App.Database4.GetItemsAsync();

            listRadio = new List<AnswerText>();
            mRB = new List<RadioButton>();
            check = new List<bool>();

            // Заполнение листа listRadio конкретными ответами по конкретному тесту.
            for (int i = 0; i < answerList.Count; i++)
            {
                if (answerList[i].Cod_practical == Convert.ToInt32(CP.Text))
                {
                    listRadio.Add(answerList[i]);
                }
            }

            // Заполнение листа mRB конкретным колличеством радио - баттонов, и заполнения их текстами конкретных ответов.
            for (int i = 0; i< listRadio.Count; i++)
            {
                mRB.Add(new RadioButton
                {
                    Content = listRadio[i].Possible_answer,
                    GroupName = "_" + listRadio[i].Cod_Text
                });
            }
            
            var pract = (Practical)BindingContext; // Записываем в переменную конкретное значение Practical исходя их контекста.

            // Выводим конкретное колличество текстов заданий и конкретные текста заданий, исходя из того, какой тест открыт.
            for (int j = 0; j < prTextList.Count; j++)
            {
                if (prTextList[j].Cod_practical == pract.CodPractical)
                {
                    StackL.Children.Add(new Label
                    {
                        Text = prTextList[j].Text_pr
                    });
                }
                // Выводим конкретное колличество радио - баттонов, исходя из того, какой текст задания и подписываем их на событие отвечающее за реагирование.
                for (int i = 0; i < listRadio.Count; i++)
                {
                    if (listRadio[i].Cod_Text == prTextList[j].CodText)
                    { 
                        StackL.Children.Add(mRB[i]);
                        mRB[i].CheckedChanged += CheckBat;
                    }
                } 
            }

            // Заполняем лист false, исходя из того, сколько заданий в тесте.
            for (int i = 0; i < prTextList.Count; i++)
            {
                if (prTextList[i].Cod_practical == pract.CodPractical)
                {
                    check.Add(false);
                }
            }

            // Привязка данных.
            lectur = await App.Database.GetItemAsync(pract.Cod_lecture);

            // Если пользователь прошел задание и значение в Б.Д. Complete_practice истина, то выводится текст "ТЕСТ ПРОЙДЕН".
            if (pract.Complete_practice == true)
            {
                StackL.Children.Add(new Label
                {
                    Text = "ТЕСТ ПРОЙДЕН",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    TextColor = Color.Orange,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 40,
                    IsVisible = true
                });
                
                ind = 0; // Обнуление переменной, котороя понадобиться для реализации логики прохождения конкретных тестов.
            }
            
            base.OnAppearing();
        }

        /// <summary> Проверка на то какой радио - баттон нажат, исходя из этого листу check по индексу присваивается либо true, если пользователь правильно ответил, либо false. </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private void CheckBat(object sender, CheckedChangedEventArgs e)
        { 
            for (int i = 0; i<mRB.Count;i++)
            {
                        RadioButton rbb = sender as RadioButton;
                        // Проверяем нажатие, равен ли текст радио баттона тексту нужному из бд, и смотрим правильность ответа, который расположен в Б.Д.
                        if ((rbb.IsChecked == true) && ((string)rbb.Content == listRadio[i].Possible_answer) && (listRadio[i].Correct_answer == true))
                        {   
                            // Если переменная больше или равна размеру листа check, то она уменьшается, иначе увеличивается, это нужно для того, чтобы не было переполнения стека.
                            if(ind>= check.Count)
                            {
                                ind -= 1;
                                check[ind] = true;
                            }
                            else 
                            {
                                check[ind] = true;
                                ind += 1;
                            }
                        }
                        else if((rbb.IsChecked == true) && ((string)rbb.Content == listRadio[i].Possible_answer) && (listRadio[i].Correct_answer == false))
                        {
                            if(ind >= check.Count)
                            {
                                ind -= 1;
                                check[ind] = false;
                            }
                            else 
                            {
                                check[ind] = false; 
                            }
                        }
            }
        }

        /// <summary> Событие, которое обрабатывает нажатие кнопки "Отправить", и результат ее нажатия. </summary>
        /// <param name="sender"> Объект вызвавший событие</param>
        /// <param name="e"> Аргемент события </param>
        private async void To_SendClicked(object sender, EventArgs e)
        {
            int countt = 0; // Переменная, которая нужна для того, чтобы проверить, на сколько вопросов правильно ответил пользователь.
            var pract = (Practical)BindingContext; // Записываем в переменную конкретное значение Practical исходя их контекста.

            // Проверка на сколько вопросов правильно ответил пользователь.
            for (int i =0;i<check.Count;i++)
            {
                if (check[i] == true)
                {
                    countt+=1;
                }
            }

            // Сравниваем колличество верных ответов, и колличество вопросов, исходя из этого записываем результат в Б.Д.
            if (countt == check.Count)
            {   
                ind = 0;

                pract.Complete_practice = true;
                await App.Database2.SaveItemAsync(pract);

                lectur.Lecture_completion = true;  
                await App.Database.SaveItemAsync(lectur);
            }
            else
            {   
                ind = 0;

                pract.Complete_practice = false;
                lectur.Lecture_completion = false;

                await App.Database.SaveItemAsync(lectur);
                await App.Database2.SaveItemAsync(pract);
            }
        }
    }
}