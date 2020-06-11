# Use DataSourceRequest and DataSourceResult and WebAPI in a WebAssembly Blazor app with custom serialization

Telerik supports serialization of the `DataSourceRequest` object through the native Blazor `System.Text.Json` serializer only. In your app you may be using different serialization techniques, with `Newtonsoft.Json` being a common tool used to serialize data.

For such specific scenarios, you must ensure that the serialization and deserialization processes work as expected - all the data is present, correct, strongly typed, and there are no errors. This applies to both the controller action, and the Blazor app itself.

The Telerik components cannot influence the serialization and deserialization process and transferring data between the endpoints is up to the application.

This example shows a sample of a custom converter that lets Newtonsoft handle the filter interface present in the `DataSourceRequest` object. You can use it as base for further implementation of other similar scenarios and more cases.

The custom converter is in the `Converters` folder of the `Server` project, and is provided to the `Newtonsoft` service in the `Startup.cs` file of the `Server` project.