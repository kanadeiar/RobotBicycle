using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using RobotApp.ViewModels;

namespace RobotApp;

public partial class App : Application
{
    private static IServiceProvider? _provider;
    
    public static IServiceProvider Provider => _provider ??= getServices()
        .BuildServiceProvider();

    private static IServiceCollection getServices()
    {
        var services = new ServiceCollection();
        initServices(services);
        return services;
    }

    private static void initServices(IServiceCollection services)
    {
        services.AddScoped<MainWindowViewModel>();


    }
}