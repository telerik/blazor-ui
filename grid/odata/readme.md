This example shows how you can consume OData services to feed data to the Telerik Blazor Grid.

You can perform the actual requests for the OData service in any way suitable to your app, the Telerik Grid needs the data for the current page and the total count, and provides you with an easy serialization method of its state.

The approaches for requesting a remote services are different in a server-side and in a client-side project, but the key points are the same:

* You need a Telerik UI for Blazor version `>=2.3.0` or later to get the OData formatting of the grid state (its `ToODataString()` extension method is in the `Telerik.Blazor.ExtensionMethods` namespace).
* To get the grid state and to provide the data to the grid, you must use the [manual operations](https://docs.telerik.com/blazor-ui/components/grid/manual-operations) of the grid.
* You need a model for the grid data and an envelope for the response object. The response model (envelope) must have `System.Text.Json.Serialization.JsonPropertyName` attributes set to point to the OData fields in the response.