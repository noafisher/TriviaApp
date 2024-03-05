using Microsoft.Extensions.Logging;
using TriviaApp.Services;
using TriviaApp.View;
using TriviaApp.ViewModel;

namespace TriviaApp
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
                    fonts.AddFont("WinterDrink.ttf", "WinterDrink");
                });
            //builder
            //register services
            builder.Services.AddSingleton<TriviaAppService>();

            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<UserAdminPageViewModel>();
            builder.Services.AddTransient<UserQuestionsPageViewModel>();
            builder.Services.AddTransient<BestScoresPageViewModel>();
            builder.Services.AddTransient<ApproveQuestionsPageViewModel>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<UserAdminPage>();
            builder.Services.AddTransient<UserQuestionsPage>();
            builder.Services.AddTransient<BestScoresPage>();
            builder.Services.AddTransient<ApproveQuestionsPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}