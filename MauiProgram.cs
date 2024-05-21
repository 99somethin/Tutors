using ExamBro.ViewModels.Startup;
using Microsoft.Extensions.Logging;
using TutorsBro.Services;
using TutorsBro.ViewModels.Dashboard;
using TutorsBro.ViewModels.Startup;
using TutorsBro.Views.Dashboard;
using TutorsBro.Views.Startup;

namespace TutorsBro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ILoginRepository,LoginService>();

            //views
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<DashboardPage>();
            builder.Services.AddSingleton<LoadingPage>();

            //views model
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<DashboardPageViewModel>();
            builder.Services.AddSingleton<LoadingPageViewModel>();

            return builder.Build();
        }
    }
}
