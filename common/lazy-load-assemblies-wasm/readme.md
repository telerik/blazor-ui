# Telerik Blazor Components and WebAssembly Lazy Load of Assemblies

This sample project demonstrates how you can use the <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0" target="_blank">lazy assembly loading feature of Blazor</a> with the Telerik components.

There are a few key points and changes to a standard project with relation to the Telerik components:

* Move the `<TelerikRootComponent>` to a layout that is used only on pages that have the Telerik assemblies loaded.

* Remove the Telerik services registration from `Program.cs`.

* Move the localization service for the Telerik components from `Program.cs` to the `<TelerikRootComponent>`.

The last two items are required because lazy loading of assemblies does not support dynamic service injection, you can read more about that framework limitation in <a href="https://github.com/dotnet/aspnetcore/issues/27331#issuecomment-718870305" target="_blank">this Microsoft GitHub Issue</a>.

> You need to be on version 2.19.0 or later for this to work. This is the first version that supports .NET 5.
