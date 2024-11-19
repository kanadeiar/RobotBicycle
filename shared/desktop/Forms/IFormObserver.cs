namespace Kanadeiar.Desktop.Forms;

/// <summary>
/// Наблюдатель
/// </summary>
public interface IFormObserver
{
    /// <summary>
    /// Информирование наблюдателя
    /// </summary>
    /// <param name="observed">Наблюдаемый</param>
    /// <param name="arg">Параметры наблюдения</param>
    void Update(IFormObservable observed, object? arg);
}