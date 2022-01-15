# Get Telerik Grid Data from an OData v4 Service

This example shows how you can consume OData services to feed data to the Telerik Blazor Grid.

You can perform the actual requests for the OData service in any way suitable to your app, the Telerik Grid needs the data for the current page and the total count, and provides you with an easy serialization method of its state.

In this example application, the OData query contains all the available data. This configuration is intentional in order to cover different scenarios. For example, columns can be conditional, some may be calculated, and we don't know what else that data might be used for in the specific case, some logic may even rely on fields that are not shown in the grid.

That being said, you can get the OData string we provide and modify it as needed to match the application needs (for example, amend the [`$select`](https://www.odata.org/getting-started/basic-tutorial/#select) parameter to get only certain fields from the query and not all the data).

The approaches for requesting a remote services are different in a server-side and in a client-side project, but the key points are the same:

* You need a Telerik UI for Blazor version `>=2.3.0` or later to get the OData formatting of the grid state (its `ToODataString()` extension method is in the `Telerik.Blazor.Extensions` namespace).
* To get the grid state and to provide the data to the grid, you must use the [manual operations](https://docs.telerik.com/blazor-ui/components/grid/manual-operations) of the grid.
* You need a model for the grid data and an envelope for the response object. The response model (envelope) must have `System.Text.Json.Serialization.JsonPropertyName` attributes set to point to the OData fields in the response.

> Tip: if you will be using nested models, you may need to add an `$expand` to your base URL and properly deserialize and expand them in the service handler.

These samples use the [Kendo OData backend service](https://github.com/telerik/kendo-ui-demos-service), but you can replace it with any OData v4 compatible service.
