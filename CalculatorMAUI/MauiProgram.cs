namespace CalculatorMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        // Register the MainViewModel and MainPage for dependency injection

        // Add the MainViewModel to the service collection
        builder.Services.AddSingleton<MainViewModel>();

        // Add the MainPage to the service collection
        builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
