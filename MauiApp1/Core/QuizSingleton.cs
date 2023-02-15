using MauiApp1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Core
{
    public class QuizSingleton
    {
        
        private static QuizSingleton _instance;
        public static QuizSingleton Instance
        {
            get
            {
                if (_instance == null)
                { _instance = new QuizSingleton(); }
                return _instance;
            }
        }

        private List<Question> _questions = new List<Question>();
        public List<Question> Questions
        {
            get 
            { if(_questions == null)
                {
                    _questions = new List<Question>();
                }
                return _questions; 
            }
            set 
            {
                _questions = value;
            }
        }

        private List<ScoreModel> _scoreList = new List<ScoreModel>();
        public List<ScoreModel> ScoreList
        {
            get
            {
                if (_scoreList == null)
                {
                    _scoreList = new List<ScoreModel>();
                }
                return _scoreList;
            }
            set
            {
                _scoreList = value;
            }
        }
        public INavigation QuizPageNavigation { get; set; }
        public int Score { get; set; } = 0;

        private int GroupId { get; set; } = 0;
        public string Username { get; set; }

        QuizSingleton()
        {
            //Username = Preferences.Get("UserName", "");
        }
        public List<Question> GetQuestions()
        {
            return _questions;
        }



        public void AddQuestion(string question, Answer[] answerChoices,string correctAnswer)
        {
            if(_questions == null) _questions = new List<Question>();
            string groupId = (GroupId++).ToString();
            _questions.Add(new Question(question, answerChoices,correctAnswer,groupId));

        }

        public void AddScore()
        {
            _scoreList.Add(new ScoreModel { UserName = Username ,Score = Score.ToString()});
        }
        public async Task ClearPreviousAnswers()
        {
            await Task.Run(() =>
            {
                foreach (Question question in _questions)
                {
                    for (int i = 0; i < question.AnswerChoices.Length; i++)
                    {
                        question.AnswerChoices[i].IsChecked = false;
                    }
                }
            });
          
        }


    }
}
