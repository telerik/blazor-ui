# Use DataSourceRequest and DataSourceResult in a Server Blazor app

The Telerik `DataSourceRequest` can be passed by reference directly to the service, so you can use it to obtain the needed data as per its contents (needed page, page size, filter, sort, etc.).

The Telerik `DataSourceResult` object is something that you can use to return such data easily - it is an envelope that contains the needed information.

You can obtain the data through extension methods provided by the `Telerik.DataSource` package - the `.ToDataSourceResult(dataSourceRequest)` and `.ToDataSourceResultAsync(dataSourceRequest)`. They can work with collections like `List<T>`, `IEnumerable<T>` and `IQueriable<T>`. You can use `IQueriable` collections coming from another service (such as EntityFramework) to perform optimized queries - the Telerik methods use LINQ expressions internally so that the framework can resolve them in the most efficient manner.