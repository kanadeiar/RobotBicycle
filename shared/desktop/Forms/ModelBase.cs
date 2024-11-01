namespace Kanadeiar.Desktop.Forms;

/// <summary>
/// Форма, которая может быть наблюдаемой
/// </summary>
public abstract class ModelBase : IFormObservable
{
    private List<IFormObserver> _observers = new();

    public void AddObserver(IFormObserver formObserver)
    {
        _observers.Add(formObserver);
    }

    public void RemoveObserver(IFormObserver formObserver)
    {
        _observers.Remove(formObserver);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(this, null);
    }

    /// <summary>
    /// Установить новое значение, уведомив наблюдателей
    /// </summary>
    /// <typeparam name="T">Тип поля</typeparam>
    /// <param name="field">Изменяемое поле</param>
    /// <param name="value">Новое значение</param>
    /// <returns>Было установлено новое значение</returns>
    protected bool Set<T>(ref T field, T value)
    {
        if (value is null || value.Equals(field)) return false;

        field = value;
        NotifyObservers();
        return true;
    }
}