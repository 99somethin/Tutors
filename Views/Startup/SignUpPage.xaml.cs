using TutorsBro.Models;
using TutorsBro.Services;

namespace TutorsBro.Views.Startup;

public partial class SignUpPage : ContentPage
{

    private readonly UserRegistration _UserRegistration;

    public SignUpPage()
	{
		InitializeComponent();

        _UserRegistration = new UserRegistration();

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync("//LoginPage");
    }


    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var user = new User
        {
            FullName = entryFullName.Text,
            Email = entryEmail.Text,
            Password = entryPassword.Text
        };

        try
        {
            var registeredUser = await _UserRegistration.RegisterUser(user);
            // Обработка успешной регистрации
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            // Обработка ошибки регистрации
            await DisplayAlert("Error", "Registration failed: " + ex.Message, "OK");
        }
    }
}