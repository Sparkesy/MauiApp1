using MauiApp1.Core;
using Microsoft.Maui.Storage;



namespace MauiApp1;


public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
		InitializeComponent();
      

    }

    private async  void Button_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushAsync(new McqPage());
    }
    private  async void Start_Quiz(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuizPage());
    }

}