using System;

namespace MessageBoxControl.Controls.MessageBox
{
    public class MessageBoxService
    {
        public static event Action<string, string, MessageBoxButtonTypeEnum, Action<MessageBoxResultEnum>> OnShowMessageBox;

        public void Show(string title, string message, MessageBoxButtonTypeEnum buttonType, Action<MessageBoxResultEnum> actionToInvoke)
        {
            OnShowMessageBox.Invoke(title, message, buttonType, actionToInvoke);
        }
    }

    public enum MessageBoxButtonTypeEnum
    {
        OK = 1,
        OKCancel = 2,
        YesNo = 3,
        YesNoCancel = 4
    }

    public enum MessageBoxResultEnum
    {
        OK = 1,
        Cancel = 2,
        Yes = 3,
        No = 4
    }
}