# Using v4 SVG Icons with New Telerik UI for Blazor Versions

Telerik UI for Blazor **15.2.0** and older versions depend on `Telerik.SvgIcons` **4.x**. Telerik UI for Blazor **16.0.0** and newer versions depends on `Telerik.SvgIcons` **5.x**.

The icons in versions 4 and 5 use different styling. This sample app shows how to continue using old legacy Telerik SVG icons with new Telerik UI for Blazor versions.

## Application Structure

The application is based on the [Use Legacy v4 SVG Icons with New Telerik UI for Blazor Versions](https://www.telerik.com/blazor-ui/documentation/knowledge-base/icons-use-legacy-v4-svg-icons-with-new-telerik-ui-for-blazor-versions) knowledge base article.

The solution consists of two projects:

* `TelerikSvgIcons4`&mdash;a modified version of the [`Telerik.SvgIcons`](https://github.com/telerik/kendo-icons/tree/develop/packages/svg-icons/src-cs/Telerik.SvgIcons) project that is used to release the [`Telerik.SvgIcons`  NuGet package](https://www.nuget.org/packages/Telerik.SvgIcons).
* `LegacyTelerikIcons`&mdash;a Blazor web app that [consumes](#legacytelerikicons-project-file) the `TelerikSvgIcons4` project or NuGet package.

### LegacyTelerikIcons Project File

`LegacyTelerikIcons.csproj` allows you to choose whether to use the `TelerikSvgIcons4` project or the prebuilt NuGet package that is also included in the solution folder. By default, the app uses the [local NuGet package](#nugetconfig):

```XML
<PackageReference Include="TelerikSvgIcons4" VersionOverride="4.12.0" />
<!-- <ProjectReference Include="../TelerikSvgIcons4/TelerikSvgIcons4.csproj" /> -->
```

### NuGet.Config

The solution folder contains a `NuGet.Config` file that defines a local NuGet feed for the `TelerikSvgIcons4` NuGet package. The configuration file uses `<clear />` to disable any other package sources except `nuget.org` and the local one.

### Central Package Management

The `blazor-ui` repo uses central package management. This sample app overrides that with `VersionOverride` in both project files.
