namespace BlazorHealthcareApp.Models;

public class PopupCoordinator
{
    public event Action? OnLayoutPopupOpened;
    public event Action? OnPagePopupOpened;

    public void NotifyLayoutPopupOpened() => OnLayoutPopupOpened?.Invoke();
    public void NotifyPagePopupOpened() => OnPagePopupOpened?.Invoke();
}
