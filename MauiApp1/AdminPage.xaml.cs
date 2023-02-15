using MauiApp1.Core;
using MauiApp1.Model;

namespace MauiApp1;

public partial class AdminPage : ContentPage
{
    private readonly List<Question> _questions = new List<Question>();
    public AdminPage()
    {
        InitializeComponent();
    }

    private void Add_Question(object sender, EventArgs e)
    {
        var question = questionEntry.Text;
        var choices = answerEntry.Text.Split(',');
        Answer[] answerChoices = new Answer[choices.Length];
        int i = 0;
        foreach (var answer in choices)
        {
            answerChoices[i] = new Answer { Choice= answer ,IsChecked = false};
            i++;
        }
        var correctAnswer = CorrectAnswer.Text;

        QuizSingleton.Instance.AddQuestion(question,answerChoices,correctAnswer);

        questionListView.ItemsSource = null;
        questionListView.ItemsSource = QuizSingleton.Instance.Questions;
    }
   

 
        


}
public class Question
{
   

    public Question(string question, Answer[] answerChoices, string correctanswer, string groupId)
    {
        QuestionText = question;
        AnswerChoices = answerChoices;
        CorrectAnswer = correctanswer;
        GroupId = groupId;
    }

    public string QuestionText { get; set; }

    public Answer[] AnswerChoices { get; set; }
    public string GroupId { get; set; }
   // public string[] AnswerChoices { get; set; }
    public  string  CorrectAnswer { get;  set; }
}

