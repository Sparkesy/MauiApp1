using MauiApp1.Core;

namespace MauiApp1;

public partial class McqPage : ContentPage
{
	public McqPage()
	{
		InitializeComponent();
        Lb1.Text = QuizSingleton.Instance.Score.ToString();
        Namelb.Text = QuizSingleton.Instance.Username.ToString();
        

    }

    private async void Retry_Clicked(object sender, EventArgs e)
    {
        QuizSingleton.Instance.Score = 0;
        await Navigation.PopAsync();
        
    }

    private async  void MainMenu_Clicked(object sender, EventArgs e)
    {
       await Navigation.PushAsync(new MainMenu());
    }
    //private void OnSubmitClicked(object sender, EventArgs e)
    ////{
    ////    int correctAnswers = 0;

    ////    if (Option1.IsChecked)
    ////    {
    ////        correctAnswers++;
    ////    }
    ////    if (Option4.IsChecked)
    ////    {
    ////        correctAnswers++;
    ////    }



    //    ResultLabel.Text = "You got " + correctAnswers + " out of 2 questions correct.";
    //}
}