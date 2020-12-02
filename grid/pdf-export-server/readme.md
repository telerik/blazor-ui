# Export Grid to PDF on the Server

This set of sample projects showcases how you can build a custom PDF export on the server for the current grid data.

The key concepts are:

* A shared project is responsible for generating the PDF file through the Telerik Document Processing libraries based on provided data and grid state. The RadSpreadProcessing approach may perform better with large data sets.

* This project returns the file as a byte array for both the server and WebAssembly flavors (for the WASM case, this is a performance improvement because such operations are slow in the browser at this point mostly due to the lack of <a href="https://github.com/dotnet/aspnetcore/issues/17730" target="_blank">multithreading</a> and <a href="https://github.com/dotnet/aspnetcore/issues/5466" target="_blank">AoT for Blazor</a>, and <a href="https://github.com/mono/mono/issues/10222" target="_blank">Full AoT for Mono</a>, and because exporting all the data would be a serious performance hit for serialization).

* You can choose which Blazor project to run by marking it as a Startup project (The `ServerSideSample` or the `ServerPdfExport.Server` for the WASM flavor).

* The current grid filters and paging are obtained through the OnRead event and sent to the server for processing and generation. You can read more about this general performance optimization technique in the <a href="https://github.com/telerik/blazor-ui/tree/master/grid/datasourcerequest-on-server" target="_blank">Use Telerik DataSourceRequest and DataSourceResult on the server</a> sample project.

In this example, reflection and generic methods are used to get the data. In your case you could change this to match your needs. Some ideas you can consider are:

* Provide a list of the fields you want to export on your own. Getting them with reflection does not guarantee a certain order.

* Using a strongly typed service can avoid the usage of reflection and thus improve performance.

* Consider sending the state of the grid columns to the service to use only designated fields and a particular column order/size (see how to get that in the <a href="https://docs.telerik.com/blazor-ui/components/grid/state#get-current-columns-visibility-order-field" target="_blank">Get Current Columns Visibility, Order, Field</a> section of the docs).

