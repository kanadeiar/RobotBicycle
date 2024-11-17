using System.Windows;
using RobotApp.Commands;
using System.Windows.Input;

namespace RobotApp.ViewModels;

public class MainWindowViewModel : Base.ViewModel
{
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title
    {
        get;
        set => Set(ref field, value);
    } = "Управление роботом";
    
    /// <summary>
    /// Закрыть приложение
    /// </summary>
    public ICommand CloseAppCommand => field ??=
        new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object? p) => true;
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }
}