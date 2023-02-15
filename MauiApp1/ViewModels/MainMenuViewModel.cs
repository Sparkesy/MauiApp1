using MauiApp1.Core;
using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class MainMenuViewModel:ObservableObject
    {
      private ObservableCollection<ScoreModel> _scoresList = new ObservableCollection<ScoreModel>();
       public ObservableCollection<ScoreModel> ScoreList { get { return _scoresList; } set { _scoresList = value; RaisePropertyChanged(nameof(ScoreList)); } }

        public MainMenuViewModel() 
        { 
            foreach(var Score in QuizSingleton.Instance.ScoreList)
            {
               _scoresList.Add(Score);
            }
        }
    }
}
