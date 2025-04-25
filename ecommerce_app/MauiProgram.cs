using CommunityToolkit.Maui;
using ecommerce_app.ViewModel;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;

namespace ecommerce_app;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseBottomSheet()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Metropolis-Regular.otf", "Metropolis Black");
                fonts.AddFont("Metropolis-Light.otf", "Metropolis Light");
                fonts.AddFont("Metropolis-Medium.otf", "Metropolis Medium");
                fonts.AddFont("Metropolis-Regular.otf", "Metropolis Regular");
            })
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler<Shell, Platforms.Android.Renderers.ShellHandlerEx>();
#endif
            });

        //builder.Services.AddSingleton<Ilogin, login>(); services
        //builder.Services.AddTransient<Iintroducao, introducao>(); services
        //builder.Services.AddTransient<IPricipal, Principal>(); services
        //builder.Services.AddTransient<ITrocarsenha, Trocarsenha>(); services
        //builder.Services.AddTransient<ICadastrar, Cadastrar>(); services

        builder.Services.AddTransient<Page_introducaoViewModel>();
        builder.Services.AddSingleton<Page_loginViewModel>();
        builder.Services.AddTransient<Page_cadastrarViewModel>();
        builder.Services.AddTransient<Page_verificar_cadastroViewModel>();
        //builder.Services.AddTransient<Page_principalViewModel>(); mvvm


#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
