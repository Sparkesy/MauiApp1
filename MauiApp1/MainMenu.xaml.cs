using MauiApp1.Core;

namespace MauiApp1;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
        scl.ItemsSource =QuizSingleton.Instance.ScoreList;
    }

    private async  void Button_Clicked(object sender, EventArgs e)
    {
          await Navigation.PopToRootAsync();
        //Application.Current.MainPage = new MainPage();
    }
}