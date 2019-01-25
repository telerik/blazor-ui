# Telerik UI for Blazor demos

This repository contains Telerik UI for Blazor preview examples. We use it to present the initially shipped components along with their functionalities. The repo will be continuously updated to cover the latest version of Blazor.

## DataBase setup

The Grid sample uses a Northwind DB Entity Model

1. Right click on the application, and select [**Manage User Secrets**](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-2.2&tabs=windows) from the context menu
2. Replace the contents of the `secrets.json` with the following connection string where you should set the `<path-to-DB>` to the location of your database

```
{
  "ConnectionStrings": {
    "NorthwindDB": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=<path-to-DB>\\Northwind.MDF;Integrated Security=True;Connect Timeout=30"
  }
}
```

For configuring the Northwind database: [Microsoft Sql-Server Samples](https://github.com/Microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs)
