namespace Kanadeiar.Desktop.Forms;

/// <summary>
/// Наблюдаемая форма
/// </summary>
public interface IFormObservable
{
    /// <summary>
    /// Добавить наблюдателя
    /// </summary>
    /// <param name="formObserver">Наблюдатель</param>
    void AddObserver(IFormObserver formObserver);

    /// <summary>
    /// Удалить наблюдателя
    /// </summary>
    /// <param name="formObserver">Наблюдатель</param>
    void RemoveObserver(IFormObserver formObserver);

    /// <summary>
    /// Уведомить наблюдателей
    /// </summary>
    void NotifyObservers();
}