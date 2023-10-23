# Blazor PWA App - Stocks Portfolio 

This sample application demonstrates one way to implement a PWA ([Progressive Web Application](https://developers.google.com/web/progressive-web-apps)) functionality in a Blazor WASM app. It is live at https://demos.telerik.com/blazor-financial-portfolio.

You may want to review the MSDN article on using the PWA template and working with PWAs in general: https://docs.microsoft.com/en-us/aspnet/core/blazor/progressive-web-app.

To get the PWA functionality working while testing, you need a "valid" SSL certificate, and the first example from the following Microsoft article can help you generate one for your local machine name, so you can publish the app and test its behavior while developing: https://docs.microsoft.com/en-us/powershell/module/pkiclient/new-selfsignedcertificate?view=win10-ps#examples.

You need to have .NET 8 installed to run the app. You can download it from [here](https://dotnet.microsoft.com/download).

## Running the Application

1. Open you CLI and go to `/Client`, then run `npm install`
    * This restores the needed packages that are later used to create the themes.
1. Run `npm run build` command
    * This will compile a custom theme for the project.

## In This App

The UI is built mostly with the [Telerik Blazor components](https://www.telerik.com/blazor-ui).

Most of the layout uses media queries and bootstrap to be responsive, some additional logic related to the viewport size is implemented through the [BlazorSize package by EdCharbeneau](https://github.com/EdCharbeneau/BlazorSize).

Data is generated in services for simplicity in this sample. They do not provide full offline capabilities (such as [offline detection](https://stackoverflow.com/questions/44756154/progressive-web-app-how-to-detect-and-handle-when-connection-is-up-again) and caching changes that can be synced later) as this is beyond the scope of this example.
