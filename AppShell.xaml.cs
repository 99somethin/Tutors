using TutorsBro.Models;
using TutorsBro.ViewModels;
using TutorsBro.Views.Dashboard;
using TutorsBro.Views.Startup;

namespace TutorsBro
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            this.BindingContext = new AppShellViewModel();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}
