using Microsoft.Extensions.Logging;
using GymNote.Services;
using GymNote.View;
using GymNote.ViewModel;

namespace GymNote;

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

		builder.Services.AddSingleton(sp =>
			sp.GetRequiredService<ILoggerFactory>().CreateLogger("App"));
		builder.Services.AddSingleton<IGlobalExceptionHandler, GlobalExceptionHandler>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<CreateProfile>();
		builder.Services.AddSingleton<CreateProfileViewModel>();

		return builder.Build();
	}
}
