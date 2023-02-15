using MauiApp1.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace MauiApp1.ViewModels
{
    public class QuizViewModel:ObservableObject
    {
        private ObservableCollection<Question> _questions = new ObservableCollection<Question>();

        public ObservableCollection<Question> Questions
        {
            get
            {
                return _questions;
            }
            set
            {
                _questions = value;
                RaisePropertyChanged(nameof(Questions));
            }

        }

        public Command QuizSubmitCommand { get; set; }

        public QuizViewModel()
        {
            QuizSubmitCommand = new Command(async () =>
            {
                if (_questions != null)
                {
                    foreach (Question question in _questions)
                    {
                        var a = question.AnswerChoices.Where(item => item.IsChecked.Equals(true)).ToList();
                        if (a.FirstOrDefault().Choice.Equals(question.CorrectAnswer)) QuizSingleton.Instance.Score++;
                    }
                    System.Diagnostics.Debug.WriteLine($"Score : {QuizSingleton.Instance.Score} ..");
                    QuizSingleton.Instance.AddScore();
                    await QuizSingleton.Instance.QuizPageNavigation.PushAsync(new McqPage());
                }
            });
            FetchDataInUI();
           
        }
        private async Task FetchDataInUI()
        {
            await Task.Run(() =>
            {
                foreach (Question question in QuizSingleton.Instance.Questions)
                {
                    _questions.Add(question);
                }
            });
            
        }
    }

}
