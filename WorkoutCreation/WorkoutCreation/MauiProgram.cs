using Microsoft.Extensions.Logging;
using WorkoutCreation.MVVM.Views;
using WorkoutCreation.MVVM.Data;
using WorkoutCreation.MVVM.ViewModels;

namespace WorkoutCreation
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

#if DEBUG
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<WorkoutViewModel>();
            builder.Services.AddSingleton<AddExercisePage>();

            //builder.Services.AddTransient<WorkoutCreatePage>();


            return builder.Build();
        }
    }
}