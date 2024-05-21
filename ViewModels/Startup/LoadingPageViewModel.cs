using TutorsBro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Views.Dashboard;
using TutorsBro.Views.Startup;
using Newtonsoft.Json;
using TutorsBro.Models;

namespace TutorsBro.ViewModels.Startup
{
    public partial class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
            string userDetailsStr = Preferences.Get(nameof(App.UserDetails), "");

            if (string.IsNullOrWhiteSpace(userDetailsStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var userinfo = JsonConvert.DeserializeObject<UserBasicInfo>(userDetailsStr);

                App.UserDetails = userinfo;

                await AppConstant.AddFlyoutMenusDetails();
            }
        }

    }
}
