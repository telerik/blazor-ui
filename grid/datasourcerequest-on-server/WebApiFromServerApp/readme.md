# Use DataSourceRequest and DataSourceResult and WebAPI in a Server Blazor app

The Telerik `DataSourceRequest` must be serialized to the REST API endpoint, so you can use it to obtain the needed data as per its contents (needed page, page size, filter, sort, etc.).

You can obtain the data through extension methods provided by the `Telerik.DataSource` package - the `.ToDataSourceResult(dataSourceRequest)` and `.ToDataSourceResultAsync(dataSourceRequest)`. They can work with collections like `List<T>`, `IEnumerable<T>` and `IQueryable<T>`. You can use `IQueryable` collections coming from another service (such as EntityFramework) to perform optimized queries - the Telerik methods use LINQ expressions internally so that the framework can resolve them in the most efficient manner.

There are a few specifics to this scenario:

* The API project must reference the `Telerik.DataSource` package and you need the `using` statements to get the extension methods.

* The serialization and deserialization of the data must be handled by the app. The `DataSourceRequest` object can be serialized and deserialized through the built-in `System.Text.Json` serializer that comes with Blazor. The blazor app must send it as a string, and the controller must deserialize it from this string.
    * It is possible to let the framework deserialize it so you can receive the `DataSourceRequest` parameter directly. Note that third party serializers may alter this behavior and they are not supported.

* There is a data envelope class used in the project where we serialize the total count and the current page of data. This is necessary, because the framework cannot deserialize the `IEnumerable` object the Telerik `DataSourceResult` has - a typed collection is needed - `System.Text.Json` cannot successfully deserialize interface properties. Perhaps a future version of the framework will be able to perform this deserialization and will simplify the data return to only the `DataSourceResult` object.
    * A second field is used when there is grouping - the grouped data has a very specific shape that the grid usually abstracts away from you, but now you must handle yourself (serialization, deserialization, parsing, generation). This sample project provides examples of generating it through the `.ToDataSourceResult` Telerik extension method; and serialization and parsing through some helper methods.

* Due to the behaviors described above, it is important to specify the deserialization options in the blazor app service to ignore casing - the API returns, by default, the field names in camelCase, as opposed to the PascalCase expected in C#. This can break the deserialization of the list of the data.

In this sample, both apps start up immediately for brevity. It is expected that you see two browser tabs open when you run the solution and that the one calling the WebAPI will be empty - it does not have a Get action. If both projects don't start on their own, start the WebAPI project yourself so the Blazor app can call it. You can do this by right-clicking on the solution within the Solution Explorer, selecting _Properties_ and choose _Configure Startup Projects_. Enable _Multiple startup projects_ and set the _Action_ to _Start_ to both _SampleWebApi_ and _WebApiFromServerApp_ projects.
