using TutorsBro.Models;


namespace TutorsBro
{
    public partial class App : Application
    {
        public static UserBasicInfo? UserDetails;
        public App()
        {
            InitializeComponent();
          
            MainPage = new AppShell();
        }
    }
}
