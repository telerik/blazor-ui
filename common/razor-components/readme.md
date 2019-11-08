This example shows how you can use Blazor components in a Razor page.

Here are the key points (comments in the code offer more details):
* You must include a reference to Server-side Blazor packages. In this sample, they come as dependencies to the Telerik UI for Blazor package.
* You must add the Blazor services and hub to `Startup.cs`.
* You need to include the Blazor assets and start up the Blazor hub yourself (you can find them in the layout).
* At the time of writing, there is a problem in the framework with passing parameters to components which results in errors. For the time being, components need to get their own data, monitor the framework for fixes and updates in this regard.
* Keep in mind the following Telerik-specific considerations: [Telerik UI for Blazor in an ASP.NET Web Application](https://docs.telerik.com/blazor-ui/knowledge-base/blazor-in-asp-net).