using System.Windows;
using RobotApp.Commands;
using System.Windows.Input;

namespace RobotApp.ViewModels;

public class MainWindowViewModel : Base.ViewModel
{
    private string _title = "Управление роботом";
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    public MainWindowViewModel()
    {
        
    }

    private ICommand? _closeAppCommand;
    /// <summary>
    /// Закрыть приложение
    /// </summary>
    public ICommand CloseAppCommand => _closeAppCommand ??=
        new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
    private bool CanCloseAppCommandExecute(object? p) => true;
    private void OnCloseAppCommandExecuted(object? p)
    {
        Application.Current.Shutdown();
    }
}