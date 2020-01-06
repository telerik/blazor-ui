using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PopupControl.Controls.Popup
{
    public class Popup
    {
        public Type ComponentType { get; set; }
        public PopupParameters Parameters { get; set; } = new PopupParameters();
        public RenderFragment Content
        {
            get
            {
                return new RenderFragment(x =>
                {
                    x.OpenComponent(1, this.ComponentType);

                    int i = 2;
                    foreach (var parameter in this.Parameters)
                    {
                        x.AddAttribute(i, parameter.Key, parameter.Value);
                        i++;
                    }
                    x.CloseComponent();
                });
            }
        }

        #region PopupService.Show as await

        internal TaskCompletionSource<PopupResult> TaskSource { get; }
        public Task<PopupResult> Task { get { return this.TaskSource.Task; } }

        #endregion

        public Popup(Type componentType)
        {
            this.ComponentType = componentType;
            this.TaskSource = new TaskCompletionSource<PopupResult>();
        }
    }  
}
