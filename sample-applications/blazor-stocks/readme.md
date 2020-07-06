# Blazor PWA App - Stocks Portfolio 

This sample application demonstrates one way to implement a PWA ([Progressive Web Application](https://developers.google.com/web/progressive-web-apps)) functionality in a Blazor WASM app. It is live at https://demos.telerik.com/blazor-financial-portfolio.

You may want to review the MSDN article on using the PWA template and working with PWAs in general: https://docs.microsoft.com/en-us/aspnet/core/blazor/progressive-web-app.

To get the PWA functionality working while testing, you need a "valid" SSL certificate, and the first example from the following Microsoft article can help you generate one for your local machine name, so you can publish the app and test its behavior while developing: https://docs.microsoft.com/en-us/powershell/module/pkiclient/new-selfsignedcertificate?view=win10-ps#examples.

## In This App

The UI is built mostly with the [Telerik Blazor components](https://www.telerik.com/blazor-ui).

The SASS styles are built to CSS through the [WebCopmiler package by madskristensen ](https://github.com/madskristensen/WebCompiler), then a build task in the `csproj` file copies the output to the `wwwroot` folder. This requires that you build through Visual Studio, a command-line build may throw an exception like `Access to the path '7z.dll' is denied`, depending on the machine setup and permissions.

Most of the layout uses media queries and bootstrap to be responsive, some additional logic related to the viewport size is implemented through the [BlazorSize package by EdCharbeneau](https://github.com/EdCharbeneau/BlazorSize).

Data is generated in services for simplicity in this sample. They do not provide full offline capabilities (such as [offline detection](https://stackoverflow.com/questions/44756154/progressive-web-app-how-to-detect-and-handle-when-connection-is-up-again) and caching changes that can be synced later) as this is beyond the scope of this example.
