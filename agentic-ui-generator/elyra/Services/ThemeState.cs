namespace elyra.Services;

public sealed class ThemeState
{
    private bool _isDarkMode = true;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode == value) return;
            _isDarkMode = value;
            OnChange?.Invoke();
        }
    }

    public event Action? OnChange;
}
