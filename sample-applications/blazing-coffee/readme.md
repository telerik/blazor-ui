# Blazing Coffee Roasters

This is a demo showing how a full-stack .NET application can be built with ASP.NET Core, Blazor Wasm, and Telerik UI for Blazor.

## Requirements

- .NET 6
- Telerik UI for Blazor (Trial or Commercial)
- npm (node package manager, for sass themes)

## Running the Application

1. Open you CLI and go to `/BlazingCoffee/Client`, then run `npm install`
    * This restores the needed packages that are later used to create the themes.
1. Run `npm run build` command
    * This will compile a custom theme for the project.

## Telerik UI for Blazor Commercial

If you are using a commercial version of Telerik UI for Blazor.

- In `BlazingCoffee.Client.csproj` remove `.Trial` from the package name. You should have:

    ```
    <PackageReference Include="Telerik.UI.for.Blazor" Version="2.x.x" />
    ```

- In `BlazingCoffee.Client/wwwroot.index.html`, remove `.Trial` from the package name in the script path. You should have

    ```
    <script src="_content/Telerik.UI.for.Blazor/js/telerik-blazor.js"></script>
    ```

- In `BlazingCoffee.Server.csproj`, remove `.Trial` from all Telerik.* package paths. You should have

    ```
    <PackageReference Include="Telerik.Documents.Core" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Fixed" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Flow" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Flow.FormatProviders.Pdf" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Spreadsheet" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Spreadsheet.FormatProviders.OpenXml" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.Spreadsheet.FormatProviders.Pdf" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Documents.SpreadsheetStreaming" Version="2021.x.xxxx" />
    <PackageReference Include="Telerik.Zip" Version="2021.x.xxxx" />
    ```

- In `BlazingCoffee.Shared.csproj` remove `.Trial` from the package name. You should have:

    ```
    <PackageReference Include="Telerik.UI.for.Blazor" Version="2.x.x" />
    ```



# Demo Features

- Globalization / Localization
- Full Stack .NET
    - Blazor Client
    - Web API Server
    - Entity Framework Core
    - Shared logic and resources
- Authentication / Authorization through an in-app database with accounts you can create on the fly. You can read more on authentication and authorization in Blazor at [MSDN: ASP.NET Core Blazor authentication and authorization](https://docs.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-5.0).
- Themeability 
    - Light/Dark themes
    - Automatic theme detection based on device theme
    - SASS architecture
    - compatible with Telerik Theme Builder
- CRUD operations
    - Integrated Grid Popup editor
    - Round trip CRUD with EF Core
- File Upload
    - Upload from Blazor to server
    - Automated conversion from DOCX > PDF with Telerik Document Processing
    - Restricted file input (DOCX or PDF)
- Telerik Components
    - Drawer
    - Grid
    - Drop Down
    - Date Range Picker
    - Chart
    - File Upload
    - Numeric Input
    - Icon
    - Window
    - Tool Tip
    - Card*
    - Rating*
    - DrawerNavLink*

`*` Unofficial/Experimental: These are experimental components that are not officially included with Telerik UI for Blazor. Use at your own risk, there is no support for these items.
