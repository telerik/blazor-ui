# Store Grid State in ASP.NET Core Protected Browser Storage

The <a href="https://docs.telerik.com/blazor-ui/components/grid/state" target="_blank">Telerik Grid State feature</a> lets you get and set the grid state with code. It also lets you store that state for your users so they can get back where they left off (filters, page index, sorting, and so on).

The Grid provides you with a `GridState<T>` object with the state information, so the application can choose where to store it. Common choices are a database or the browser's local storage. Both of these options require a string value, so the object from the grid must be serialized. The `System.Text.Json` serializer that comes with the framework is supported.

This sample project shows how to use the `Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage` to store the Grid state in the browser in an encrypted format (the framework does the encryption). You can read more about this framework service in the following documentation page: <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/state-management" target="_blank">https://docs.microsoft.com/en-us/aspnet/core/blazor/state-management</a>.

There are two pages in the project:

- `Index.razor` uses the framework service directly and lets it serialize the data.
- `ExplicitSerialization.razor` serializes the data explicitly to a string before passing it to the framework service. This can be useful for debugging purposes in case you face issues, or the built-in serialization approach in the service changes/breaks.


## Notes


At the time of writing, there are two caveats with this service:

* The framework service needs to be injected into every Razor component that uses it. The official Microsoft documentation suggests reusing the service via a cascading parameter from a parent component. My attempt to inject it into another service was not successful.
* There is no documentation in the WebAssembly section of the article on how to use this service, and whether there are differences from the server-side flavor. I have not attempted to use it in a WebAssembly project. If you get it running, feel free to open a Pull Request with that sample.