# Telerik Blazor Components and WebAssembly Lazy Load of Assemblies

This sample project demonstrates how you can use the <a href="https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies" target="_blank">lazy assembly loading feature of Blazor</a> with the Telerik components.

## Requirements

There are a few key points and changes to a standard project with relation to the Telerik components:

1. Move the `<TelerikRootComponent>` to a layout that is used only on pages that have the Telerik assemblies loaded.

1. Mark the assemblies you want to lazy-load in the `.csproj` file of the WebAssembly project. This will prevent them from being loaded automatically initially.

    The following snippet from `LazyLoadTelerikComponents.Client.csproj` shows the Telerik assemblies for version `4.6.0`. Common assemblies (such as `System.*`) may already be loaded and in use, so you may want to remove them from the list.

    **LazyLoadTelerikComponents.Client.csproj**
    
        <ItemGroup>
            <!-- Components and data binding -->
            <BlazorWebAssemblyLazyLoad Include="Telerik.Blazor.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.DataSource.dll" />
            <BlazorWebAssemblyLazyLoad Include="System.Data.Common.dll" />
            <BlazorWebAssemblyLazyLoad Include="System.Linq.Queryable.dll" />
            <!-- Icons -->
            <BlazorWebAssemblyLazyLoad Include="Telerik.SvgIcons.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.FontIcons.dll" />
            <!-- PivotGrid -->
            <BlazorWebAssemblyLazyLoad Include="Telerik.Pivot.Core.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.Pivot.DataProviders.Xmla.dll" />
            <!-- Scheduler -->
            <BlazorWebAssemblyLazyLoad Include="Telerik.Recurrence.dll" />
            <!-- Excel export -->
            <BlazorWebAssemblyLazyLoad Include="Telerik.Documents.SpreadsheetStreaming.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.Zip.dll" />
        </ItemGroup>

1. They lazy loading of assemblies at the correct time is the app's responsibility. If an assembly is not loaded when required, the app will throw `System.IO.FileNotFoundException: Could not load file or assembly ...`. The loading code is in the `OnNavigateAsync` event handler of the `<Router>`. You can also define an optional loading screen inside the `<Router>` with `<Navigating>`. See `LazyLoadTelerikComponents/Client/App.razor`.

1. Remove the Telerik service registration from `Program.cs`.

1. If you are using <a href="https://docs.telerik.com/blazor-ui/globalization/localization" target="_blank">localization for the Telerik Blazor components</a>, move the localization service for the Telerik components from `Program.cs` to the `Localizer` parameter of the `<TelerikRootComponent>` (example available in the sample project). The key thing is to instantiate the variable locally - it cannot be injected or present in the `@code { }` block as that will throw runtime errors.

> The last two items are required because lazy loading of assemblies does not support dynamic service injection, you can read more about that framework limitation in <a href="https://github.com/dotnet/aspnetcore/issues/27331#issuecomment-718870305" target="_blank">this Microsoft GitHub Issue</a>. This means that you cannot `inject` services that depend on or inherit code that will be lazy-loaded, nor can you use them as fields in the view-model of a component.

## Notes

* You need at least .NET 5 and Telerik UI for Blazor version 2.19.0.

* You cannot use the same localization service that the Telerik components use internally (and that you pass to them) for your own localization (such as Grid command button texts). This limitation comes from the same limitation of injecting dynamic services described above.

    * This means you cannot inject it yourself, or add an extra cascading parameter for it - it will throw runtime errors when the blazor app initializes.
    
    * Localization of button texts is a part of the application (page), so it is up to the application to implement it. You can use the built-in string localizer from the framework on a per-page basis, like any other razor component. There is an example of this in the sample project (uses the `Microsoft.Extensions.Localization` package and local `.resx` files next to the page in question).
