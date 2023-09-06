using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MultiPlatform.Services.Models;
using MultiPlatform.Services.Models.Abstractions;
using System.Reflection;

namespace MultiPlatform;

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

        var assembly = Assembly
            .GetExecutingAssembly();
        using var stream = assembly
            .GetManifestResourceStream("MultiPlatform.appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        builder
            .Configuration
            .AddConfiguration(config);

#if DEBUG && (ANDROID || IOS)
        HttpsClientHandlerService handler = new HttpsClientHandlerService();
        HttpClient client = new HttpClient(handler.GetPlatformMessageHandler());
#else
        HttpClient client = new HttpClient();
#endif
        var host = config.GetSection("Api:HttpHost").Value;
#if ANDROID
        host = host.Replace("localhost", "10.0.2.2");
#endif
        client.BaseAddress = new Uri(host);

        builder.Services.AddSingleton<HttpClient>(client);
        builder.Services.AddTransient<IListModelsService, ListModelsService>();
		builder.Services.AddTransient<IGetModelService, GetModelService>();

        return builder.Build();
	}
}
