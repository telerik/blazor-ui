# gRPC Services in Blazor

This folder contains two examples that show ways you can consume gRPC services in Blazor apps. If you are not familiar with gRPC, we recommend you start by reviewing the MSDN resources, for example from this article: <a href="https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-5.0" target="_blank">https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-5.0</a>

The two examples here are:

* [basic](basic) - a very simple gRPC service in a dedicated app, consumed by a server-side Blazor app
* [grid](datasource-request-result) - a WebAssembly project that shows one way to define models and descriptors in the `proto` files that can match the `DataSourceRequest` and `DataSourceResult` objects the Telerik Grid component uses.