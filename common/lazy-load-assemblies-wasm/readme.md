# Telerik Blazor Components and WebAssembly Lazy Load of Assemblies

This sample project demonstrates how you can use the <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-lazy-load-assemblies?view=aspnetcore-5.0" target="_blank">lazy assembly loading feature of Blazor</a> with the Telerik components.

## Requirements

There are a few key points and changes to a standard project with relation to the Telerik components:

* Move the `<TelerikRootComponent>` to a layout that is used only on pages that have the Telerik assemblies loaded.

* Mark the required assemblies as lazy-loaded in the `.csproj` file of the web assembly project - the following snippet shows the assemblies that the Telerik components rely on at the time of writing.

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

* Remove the Telerik services registration from `Program.cs`.

* Move the localization service for the Telerik components from `Program.cs` to the `<TelerikRootComponent>` and its `Localizer` parameter (example available in the sample project).

The last two items are required because lazy loading of assemblies does not support dynamic service injection, you can read more about that framework limitation in <a href="https://github.com/dotnet/aspnetcore/issues/27331#issuecomment-718870305" target="_blank">this Microsoft GitHub Issue</a>. This means that you cannot `inject` services that depend on or inherit code that will be lazy-loaded.

## Notes

* You need to be on version 2.19.0 or later for this to work. This is the first version that supports .NET 5.

* You cannot use the same localization service that the Telerik components use internally (and that you pass to them) for your own localization (such as grid command button texts). This limitation comes from the same limitation of injecting dynamic services described above.

    * Localization of button texts is a part of the application (page), so it is up to the application to implement it. You can use the built-in string localizer from the framework on a per-page basis, like any other razor component. There is an example of this in the sample project.

