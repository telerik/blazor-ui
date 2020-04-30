# Use DataSourceRequest and DataSourceResult and WebAPI in a Server Blazor app

The Telerik `DataSourceRequest` must be serialized to the REST API endpoint, so you can use it to obtain the needed data as per its contents (needed page, page size, filter, sort, etc.).

You can obtain the data through extension methods provided by the `Telerik.DataSource` package - the `.ToDataSourceResult(dataSourceRequest)` and `.ToDataSourceResultAsync(dataSourceRequest)`. They can work with collections like `List<T>`, `IEnumerable<T>` and `IQueriable<T>`. You can use `IQueriable` collections coming from another service (such as EntityFramework) to perform optimized queries - the Telerik methods use LINQ expressions internally so that the framework can resolve them in the most efficient manner.

There are a few specifics to this scenario:

* The API project must reference the `Telerik.DataSource` package and you need the `using` statements to get the extension methods.

* The serialization and deserialization of the data must be handled by the app. The `DataSourceRequest` object can be serialized and deserialized through the built-in `System.Text.Json` serializer that comes with Blazor. The blazor app must send it as a string, and the controller must deserialize it from this string.
    * It is possible to let the framework deserialize it so you can receive the `DataSourceRequest` parameter directly. Note that third party serializers may alter this behavior and they are not supported.

* There is a data envelope class used in the project where we serialize the total count and the current page of data. This is necessary, because the framework cannot deserialize the `IEnumerable` object the Telerik `DataSourceResult` has - a typed collection is needed - `System.Text.Json` cannot successfully deserialize interface properties. Perhaps a future version of the framework will be able to perform this deserialization and will simplify the data return to only the `DataSourceResult` object.

* Due to the behaviors described above, it is important to specify the deserialization options in the blazor app service to ignore casing - the API returns, by default, the field names in camelCase, as opposed to the PascalCase expected in C#. This can break the deserialization of the list of the data.

In this sample, both apps start up immediately for brevity. It is expected that you see two browser tabs open when you run the solution and that the one calling the WebAPI will be empty - it does not have a Get action.