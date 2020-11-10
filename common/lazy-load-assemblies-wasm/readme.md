# Telerik Blazor Components and WebAssembly Lazy Load of Assemblies

This sample project demonstrates how you can use the <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0" target="_blank">lazy assembly loading feature of Blazor</a> with the Telerik components.

## Requirements

There are a few key points and changes to a standard project with relation to the Telerik components:

1. Move the `<TelerikRootComponent>` to a layout that is used only on pages that have the Telerik assemblies loaded.

1. Mark the assemblies you want to lazy-load in the `.csproj` file of the web assembly project.

    The following snippet shows the assemblies that the Telerik components rely on at the time of the `2.19.0` release.
    
    Common assemblies (such as the `System.*` ones) may already be in use by your app and already load on the initial load, so you may want to remove them.

    This is the same list of assemblies you need to load when the page with the Telerik components is requested (the code for that is in the `App.razor` component).

    **CSPROJ**
    
        <ItemGroup>
            <BlazorWebAssemblyLazyLoad Include="Telerik.Blazor.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.DataSource.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.Recurrence.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.Documents.SpreadsheetStreaming.dll" />
            <BlazorWebAssemblyLazyLoad Include="Telerik.Zip.dll" />
            <BlazorWebAssemblyLazyLoad Include="System.Data.Common.dll" />
            <BlazorWebAssemblyLazyLoad Include="System.Linq.Queryable.dll" />
        </ItemGroup>

1. Remove the Telerik services registration from `Program.cs`.

1. If you are using <a href="https://docs.telerik.com/blazor-ui/globalization/localization" target="_blank">localization</a> for the Telerik components, move the localization service for the Telerik components from `Program.cs` to the `Localizer` parameter of the `<TelerikRootComponent>` (example available in the sample project). The key thing is to instantiate the variable locally, it cannot be injected or present in the `@code { }` block as that will throw runtime errors.

> The last two items are required because lazy loading of assemblies does not support dynamic service injection, you can read more about that framework limitation in <a href="https://github.com/dotnet/aspnetcore/issues/27331#issuecomment-718870305" target="_blank">this Microsoft GitHub Issue</a>. This means that you cannot `inject` services that depend on or inherit code that will be lazy-loaded, nor can you use them as fields in the view-model of a component.

## Notes

* You need to be on version 2.19.0 or later for this to work. This is the first version that supports .NET 5.

* You cannot use the same localization service that the Telerik components use internally (and that you pass to them) for your own localization (such as grid command button texts). This limitation comes from the same limitation of injecting dynamic services described above.

    * This means you cannot inject it yourself, or add an extra cascading parameter for it - it will throw runtime errors when the blazor app initializes.
    
    * Localization of button texts is a part of the application (page), so it is up to the application to implement it. You can use the built-in string localizer from the framework on a per-page basis, like any other razor component. There is an example of this in the sample project (uses the `Microsoft.Extensions.Localization` package and local `.resx` files next to the page in question).

