using Microsoft.Extensions.DependencyInjection;

namespace RobotApp.ViewModels;

public class ViewModelLocator
{
    public static MainWindowViewModel MainWindowViewModel => App.Provider.GetRequiredService<MainWindowViewModel>();
}