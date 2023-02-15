using MauiApp1.Core;

namespace MauiApp1;

public partial class QuizPage : ContentPage
{
	public QuizPage()
	{
		InitializeComponent();
		QuizSingleton.Instance.QuizPageNavigation = this.Navigation;
	}
	private void QuizSubmitCommand(object sender, EventArgs e)
	{

	}
}