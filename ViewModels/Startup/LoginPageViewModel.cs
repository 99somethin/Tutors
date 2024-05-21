using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using TutorsBro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TutorsBro;
using TutorsBro.Models;
using TutorsBro.Views.Dashboard;
using TutorsBro.Services;


namespace ExamBro.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? _email;

        [ObservableProperty]
        private string? _password;

        private readonly ILoginRepository _loginRepository;

        public LoginPageViewModel(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [ICommand]
        async void Login()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
                {

                    User user = await _loginRepository.Authenticate(Email, Password);

                    var userDetails = new UserBasicInfo();
                    userDetails.Email = Email;
                    userDetails.FullName = user.FullName;

                    if (Email.ToLower().Contains("student"))
                    {
                        userDetails.RoleId = (int)RoleType.Student;
                        userDetails.Role = "Student role";
                    }
                    else if (Email.ToLower().Contains("teacher"))
                    {
                        userDetails.RoleId = (int)RoleType.Teacher;
                        userDetails.Role = "Teacher role";
                    }
                    else
                    {
                        userDetails.RoleId = (int)RoleType.Admin;
                        userDetails.Role = "Admin role";
                    }


                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }

                    string userDet = JsonConvert.SerializeObject(userDetails);

                    Preferences.Set(nameof(App.UserDetails), userDet);

                    App.UserDetails = userDetails;

                    await AppConstant.AddFlyoutMenusDetails();
                }
            }
            catch(Exception ex) 
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "ok");
                return;
            }
        }
    }
}
