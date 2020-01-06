using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PopupControl.Controls.Popup
{
    public class PopupService
    {
        #region Variables

        public Stack<Popup> Popups { get; set; } = new Stack<Popup>();
        public event Action OnPopupsUpdated;

        #endregion

        #region Show / Close

        public Task<PopupResult> Show(Type componentType)
        {
            return Show(componentType, new PopupParameters());
        }

        public Task<PopupResult> Show(Type componentType, PopupParameters parameters)
        {
            // Build the popup 
            var popup = new Popup(componentType);
            foreach (var parameter in parameters)
            {
                popup.Parameters.Add(parameter.Key, parameter.Value);
            }

            // Add popup to the container
            this.Popups.Push(popup);

            // Prevents the container
            OnPopupsUpdated?.Invoke();

            // Wait for the popup to be closed
            return popup.Task;
        }

        public void Close(bool success)
        {
            Close(success, new PopupParameters());
        }

        public void Close(bool success, PopupParameters parameters)
        {
            var popup = this.Popups.Pop();
            popup.TaskSource.SetResult(new PopupResult(success, parameters));
            OnPopupsUpdated?.Invoke();
        }     

        #endregion
    }

    public class PopupParameters : Dictionary<string, object>
    {
        public PopupParameters()
        {
        }

        public new PopupParameters Add(string key, object value)
        {
            base.Add(key, value);

            // Returns dictionary to be able to call Add more than one time
            return this;
        }
    }

    public class PopupResult
    {
        internal PopupResult(bool success, PopupParameters returnParameters)
        {
            this.Success = success;
            this.ReturnParameters = returnParameters;
        }

        public bool Success { get; }
        public PopupParameters ReturnParameters { get; }
    }
}