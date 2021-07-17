# Blazor Components in an ASP.NET Core Razor Page or MVC View - Razor Components Scenario

These examples show how you can use Blazor components in Razor pages and MVC views.

Here are the key points (comments in the code offer more details):
* You must include a reference to Server-side Blazor packages. In this sample, they come as dependencies to the Telerik UI for Blazor package.
* You must add the Blazor services and hub to `Startup.cs`.
* You need to include the Blazor assets and start up the Blazor hub yourself (you can find them in the layout).
* **At the time of writing, there is a problem in the framework with passing parameters to components which results in errors**. For the time being, components need to get their own data. You should monitor the framework for fixes and updates in this regard. This may be related to [https://github.com/aspnet/AspNetCore/issues/14966](https://github.com/aspnet/AspNetCore/issues/14966) and [https://github.com/aspnet/AspNetCore/issues/14474](https://github.com/aspnet/AspNetCore/issues/14474) even though both issues are closed and expected to be fixed in .NET Core 3.1 Preview 2, which this sample uses.
* Keep in mind the following Telerik-specific considerations: [Telerik UI for Blazor in an ASP.NET Web Application](https://docs.telerik.com/blazor-ui/knowledge-base/blazor-in-asp-net).



## Notes

Note the usage of the `TelerikRootComponent` - it is required for popups (such as windows, dropdowns, alerts, notifications) and its placing is important for their correct positioning (read more about this in the <a href="https://docs.telerik.com/blazor-ui/troubleshooting/general-issues#wrong-popup-position" target="_blank">Wrong Popup Position</a> section).

With the razor components scenarios, it is impossible to have one such component at the root of the app, like you can have with a "standard" Blazor application. Each Razor Component in this scenario is its own standalone and isolated Blazor application and they can't share rendering and components.

This means that each such "app" must have its own `TelerikRootComponent` and so popups can be offset to wrong positions if the app's root element does not match the viewport (e.g., there is other MVC content around the Blazor section).

What **we have seen work well** to avoid issues around popups and the `TelerikRootComponent` is **migrating entire razor pages or MVC views towards Blazor at the same time**, so that the page be a full razor component instead of a mix between a view and Blazor. This lets you have the Telerik root component at the root of the page around the layout just like required in the docs, so that popups can position well. This also lets you prepare a foundation for migrating next pages  - you already have the layout made up in Blazor, with the root component, with the basic infrastructure for the Blazor app, and you can start building reusable components (such as editors, forms, grids, charts) that you use often so next pages are easier to migrate.