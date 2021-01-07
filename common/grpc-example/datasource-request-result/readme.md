# Use DataSourceRequest and DataSourceResult and gRPC in a WebAssembly Blazor app

This sample project shows one way that you can prepare the `proto` files so they can generate the data models, and so they can also describe the Telerik `DataSourceRequest` and `DataSourceResult` classes.

The key points are:

* The `DataSourceRequest` is serialized to JSON through the built-in `System.Text.Json` serializer that is the only supported serialization option out-of-the-box. It does not contain much data so it will not be a significant performance hit when sent to the server.

    * See the `DataSourceProtoRequest` class in the `Shared` project for the implementation. This is used to send the data when the service is called from the WASM app, and the service uses it to construct the actual object.

* The data service itself is in the `Server` project, see `Services/TestDataService.cs`. Both the server and the client projects reference the `Shared` project where the `proto` files, data models and additional code are, so they can be shared between the server and the client.

    * Review the code in the service for a sample implementation of grouping - since grouping changes the data from flat to nested hierarchical group descriptors, it requires some code that is also reflected in the `proto` file descriptors.

* The `DataSourceResult` is described in the `Shared` project - see the `TestData` folder. The code in the service needs the model type, however, and so the `proto` file needs to describe that as well. Thus, the `proto` file and the data service are not generic and you need to tweak them to each service and model you have.

* There is also a sample of using JSON in this project so you can compare the usage and related code againt the gRPC approach. See the `TestGridJSON` component (page) and the corresponding `TestGridJSONController` on the server. For more details, see <a href="https://github.com/telerik/blazor-ui/tree/master/grid/datasourcerequest-on-server" target="_blank">here</a>.

    * The front-end portions (the WASM project, the grid setup and the service there) are nearly identical, the additional steps for the gRPC service are mostly in the `Shared` project so that the necessary classes can be described and created, and in the `Server` project service where nested grouping needs to be configured.

## Notes

The Telerik components cannot influence the serialization and deserialization process and transferring data between the endpoints is up to the application. Telerik supports serialization of the `DataSourceRequest` object to JSON through the native Blazor `System.Text.Json` serializer only. Sending and receiving the data to/from a gRPC service is beyond the scope of the Telerik components. Thus, such an integration is not supported by Telerik.

The data savings of gRPC vs JSON are usually around 30% in this sample and when you work with smaller page sizes (this sample uses 100, while 20-30 are more common values), the savings will be less pronounced. In a more common case you may want to reduce the page size of the grid to improve the ease of use and the UX (and also the client-side performance).

This sample does not implement Aggregates and their serialization back to the client.

This sample also adds a partial class to add data annotation attributes to allow validation. They cannot be created from the `proto` file and so a partial class with the same name is written in the app itself. If you choose such an approach, you must remember which fields to use in the backend and front-end, and tie them properly to the database.

## Attribution

This sample was created by **Beat Ludi** from Peacock Bros, and is posted in this repo as a sample learning resource with their explicit consent.