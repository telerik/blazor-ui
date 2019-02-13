# Telerik UI for Blazor demos

This repository contains Telerik UI for Blazor preview examples. We use it to present the initially shipped components along with their functionalities. The repo will be continuously updated to cover the latest version of Blazor.

## Prerequisites

Since the ASP.NET Preview's are moving at a rapid place, it's best to update your bits. Make sure you're on the current version of Razor Components (server-side) and Blazor (client-side). Detailed installation instructions for both frameworks can be found on the [Blazor getting started page](https://docs.microsoft.com/en-us/aspnet/core/razor-components/get-started?view=aspnetcore-3.0&tabs=visual-studio)

Also be sure that you have enabled the [Telerik UI for Blazor free early preview](https://www.telerik.com/download-trial-file/v2-b/ui-for-blazor). Even if you have previously enrolled in the preview you may need to revisit this page for the latest version to appear in your feed. With this free account you'll be able to add the [Telerik NuGet Package Source](https://docs.telerik.com/aspnet-mvc/getting-started/nuget-install#set-up-nuget-package-source).

## DataBase setup

The Grid sample uses a Northwind DB Entity Model

1. Right click on the .Server application, and select [**Manage User Secrets**](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows) from the context menu
2. Replace the contents of the `secrets.json` with the following connection string where you should set the `<path-to-DB>` to the location of your database

```
{
  "ConnectionStrings": {
    "NorthwindDB": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=<path-to-DB>\\Northwind.MDF;Integrated Security=True;Connect Timeout=30"
  }
}
```

For configuring the Northwind database: [Microsoft Sql-Server Samples](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)
