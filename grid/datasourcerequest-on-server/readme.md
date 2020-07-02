# Use Telerik DataSourceRequest and DataSourceResult on the server

These sample projects showcase how you can send (serialize) the Telerik component state (such as the grid's `DataSourceRequet` object from the `OnRead` event) to the server, so you can retrieve and shape the data easily.

> The serialization for an HTTP request (needed for a WebAssembly project) is available as of the `2.11.0` release. The native Blazor `System.Text.Json` serializer is supported.

Review the individual projects, the comments in the code and their own readme files for details on each approach:

* for a purely server-side Blazor app where the data context (data source) is in the same app
* for a WebAssembly Blazor app - a WebApi controller in its server hosting project is used to fetch data
* for a server-side Blazor app - an example that calls another WebApi project through HTTP
* a sample of a custom serializer (Newtonsoft.Json) that you can use as base for using similar scenarios
 
> The application must make sure that serialization and deserialization of the information work properly on both the Blazor app and the server endpoint (all the data is present, correct, strongly typed, and there are no errors), as this is not something the Telerik components can influence.