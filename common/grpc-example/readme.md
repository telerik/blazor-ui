# Consume gRPC Services in Blazor

This is a basic example of how you can consume gRPC services in a Blazor app, so that you can use the data to feed components (such as the Telerik Grid for Blazor).

There are 4 projects in this example:
* `GrpcUsers` - the gRPC server where the data comes from. This is also where the `proto` file resides. This is also where the code generation for the `User` class comes from - this is the class used in the UI as well.
    * Make sure to run this project first, so the gRPC server is running. Error handling is not implemented in this sample solution.
* `GrpcClientUsers` - a sample class library that is the actual gRPC client - it consumes the Users service defined in the `GrpcUsers` project. It also references the `proto` file from the server to ensure it is up to date.
    * In my local tests, the async version of the service call never returns from this library. It may be a limitation of the tooling, because it works in a console app.
* `GrpcInBlazor` - this is the Blazor project where the gRPC service is consumed. This is done through a standard .NET Core service in the Blazor project itself in order to promote code reusability - the general idea is that the class library that actually consumes the gRPC service should be UI independent and can be referenced from other projects as needed.
* `ConsoleApp1` - a simple test app that you can use to test the gRPC server. It works with the async version of the service, even though it does not seem to work in the class library above.

In summary - using gRPC in Blazor is not different from using it in any other application.

Getting started with gRPC from MSDN:

* [Introduction to gRPC on .NET Core](https://docs.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-3.0)
* [Tutorial: Create a gRPC client and server in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/grpc/grpc-start?view=aspnetcore-3.0&tabs=visual-studio)
* [gRPC services with C#](https://docs.microsoft.com/en-us/aspnet/core/grpc/basics?view=aspnetcore-3.0)
* [gRPC services with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/grpc/aspnetcore?view=aspnetcore-3.0&tabs=visual-studio)
* [Call gRPC services with the .NET client](https://docs.microsoft.com/en-us/aspnet/core/grpc/client?view=aspnetcore-3.0)

>For WebAssembly applications, see this blog post dated 15 Jan 2020: [https://blog.stevensanderson.com/2020/01/15/2020-01-15-grpc-web-in-blazor-webassembly/](https://blog.stevensanderson.com/2020/01/15/2020-01-15-grpc-web-in-blazor-webassembly/). It is a starting point with some workarounds that will probably become part of the standard tooling.
