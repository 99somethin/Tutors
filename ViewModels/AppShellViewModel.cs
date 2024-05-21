using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Views.Startup;

namespace TutorsBro.ViewModels
{
    public partial class AppShellViewModel
    {
        [ICommand]
        async void SignOut()
        {
            if (Preferences.ContainsKey(nameof(App.UserDetails)))
            {
                Preferences.Remove(nameof(App.UserDetails));
            }
           

            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

            if (Shell.Current.CurrentPage is LoginPage loginPage)
            {
                loginPage.ClearEntries();
            }
        }
    }
}
