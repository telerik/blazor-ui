# Hybrid Blazor Apps

With .NET 6 Previews an exciting new feature became available - `WebView` for native apps that is dedicated to running Blazor Web applications.

The samples in this project showcase Telerik UI for Blazor web components running in this hybrid scenarios inside native WPF and WinForms apps.

## Key Points

Comments in the code offer some more insights, the key points pertaining to the Telerik components are:
* The native app project needs to reference the Telerik UI for Blazor package.
* You add the Telerik static assets in the `index.html` file as usual.
* The `TelerikRootComponent` should be added as a top-level component in the Blazor app. Since layouts are not supported yet, in this sample we add it to the `Main.razor` component.
    * Make sure that the Telerik root component matches the webview viewport. In this sample, we need to remove the default margin and padding from the body to ensure the content matches the viewport. An extra element in the layout provides paddings.
    * It is expected that layouts should be supported in the future so you would be able to set this up in the same way as with regular Blazor web apps.

These sample apps contain just a few commonly used Telerik components such as a grid, chart, button, date picker to showcase things work.

## How to run

1. Install [.NET 6.0 Preview 4](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-4/).
    * Note: It requires <a href="http://visualstudio.com/preview" target="_blank">Visual Studio Preview for Windows</a> or <a href="https://docs.microsoft.com/visualstudio/releasenotes/vs2019-mac-preview-relnotes" target="_blank">for Mac</a>.
2. Install [WebView](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-6-preview-3/#blazorwebview-controls-for-wpf-windows-forms).
3. Make sure you have WinForms/WPF/etc. installed.
    * Note: they usually come as workloads through the Visual Studio installer, if you have not activated them previously go to the VS Installer and add them.
4. Make sure you have the latest Telerik UI for Blazor version (2.24.0) in [your nuget feed](https://docs.telerik.com/blazor-ui/installation/nuget).
5. Run an app - either the WinForms, or WPF one.

