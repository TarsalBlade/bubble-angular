using Microsoft.Extensions.Logging;
using SAMS.Mobile.Services;
using SAMS.Mobile.ViewModels;
using SAMS.Mobile.Views;

namespace SAMS.Mobile;

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

        builder.Services.AddSingleton<SupabaseService>();
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<AttendanceService>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<StudentHomeViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<StudentHomePage>();
        builder.Services.AddTransient<AttendanceHistoryPage>();

        return builder.Build();
    }
}
