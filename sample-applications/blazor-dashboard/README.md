# Blazor Dashboard App

This sample application showcases how easy it is to plug the Telerik Blazor components in your layout, data and models. It is insipred by other similar dashboard apps for [Vue.js](https://github.com/telerik/vue-dashboard) and [Angular](https://github.com/telerik/ng2-dashboard).

## What's Inside

* `Bootstrap` for the layouts
* the [Telerik Blazor components](https://www.telerik.com/blazor-ui) for the UI elements
* dummy data, because, at the time of writing, the [Octokit.NET](https://github.com/octokit/octokit.net) package does not work under Blazor due to [issues with async requests](https://github.com/aspnet/AspNetCore/issues/9125)

## How to Run Locally

To run this app locally, you need:

* to be able to run the latest Telerik UI for Blazor version (more details [here](https://docs.telerik.com/blazor-ui/getting-started/what-you-need))
* .NET 8 installed - you can download it from [here](https://dotnet.microsoft.com/download)

If you don't have a commercial license for UI for Blazor, [start a trial](https://www.telerik.com/download-trial-file/v2-b/ui-for-blazor) and replace the package reference with `Telerik.UI.for.Blazor.Trial`.

1. open the `sln` file with VS 2022
1. press `F5`
