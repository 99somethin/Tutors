using ExamBro.ViewModels.Startup;

namespace TutorsBro.Views.Startup;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
			
		this.BindingContext = viewModel;
	}

    public void ClearEntries()
    {
		entryUsername.Text = string.Empty;
        entryPassword.Text = string.Empty;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignUpPage");
    }
}