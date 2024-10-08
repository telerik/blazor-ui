# Localization Examples

These samples show how to implement a custom [service that localizes the Telerik UI for Blazor components](https://docs.telerik.com/blazor-ui/globalization/localization). The two apps are based on the following Microsoft Blazor project templates:

* **Blazor Web App** with interactive **Server** render mode and **Global** interactivity location
* **Blazor WebAssembly Standalone App**

Make sure to perform these actions:

* Read the [Blazor localization documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/globalization-localization). The sample apps in this folder step on top of the Microsoft guidelines.
* Read the [Localization article in the Telerik UI for Blazor documentation](https://docs.telerik.com/blazor-ui/globalization/localization).
* Update the resource files with each Telerik UI for Blazor version upgrade. [Download the offline version](https://www.telerik.com/account/my-downloads) of the Telerik UI for Blazor [demo solution](http://demos.telerik.com/blazor-ui/) for the latest version of the `TelerikMessages.resx` file. The demo site also contains a sample implementation of a localization service. All `resx` files are located in the `Resources` folder of the demo site.
* Review the Telerik-specific localization service in `SampleResxLocalizer.cs` and how it's registered in `Program.cs`.
* Review the Telerik localization mechanism in action in `Home.razor`.

You can find translations provided by the community, and contribute your own, in the following repository: [UI for Blazor: Translation of Messages](https://github.com/telerik/blazor-ui-messages).
