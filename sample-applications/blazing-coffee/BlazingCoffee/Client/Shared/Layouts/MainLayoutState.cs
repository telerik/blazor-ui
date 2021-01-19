using System;

namespace BlazingCoffee.Client.Shared.Layouts
{
    public class MainLayoutState
    {
        private string docsPath;

        public string DocsPath
        {
            get => docsPath;
            set
            {
                docsPath = value;
                LayoutStateChange?.Invoke();
            }
        }

        public Action LayoutStateChange { get; set; }

        public bool HasDocs => !string.IsNullOrEmpty(DocsPath);

        public string DocsTitle { get; set; }
    }
}
