using MauiApp1.Core;
using System;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private const int V = 0;

    public MainPage()
	{
        
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        QuizSingleton.Instance.Score = V;
       await QuizSingleton.Instance.ClearPreviousAnswers();
    }


    private async void Button_Clicked(object sender, EventArgs e)
    {
		if(txtusername.Text=="Admin" && txtpassword.Text=="123")
		{
           
			await Navigation.PushAsync(new AdminPage());	
		}
		else
		{
			await DisplayAlert("Ops", "Username or password is incorrect","OK");
		}


    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {

        if ( txtpassword.Text == "456")
        {
           QuizSingleton.Instance.Username= txtusername.Text;
           await Navigation.PushAsync(new StudentPage());
        }
        else
        {
           await DisplayAlert("Ops", "Username or password is incorrect", "OK");
        }
    }
}


