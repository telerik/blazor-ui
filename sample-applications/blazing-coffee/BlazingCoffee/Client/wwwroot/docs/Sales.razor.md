# Features you'll find here include

This page showcases operations using the <a href="https://demos.telerik.com/blazor-ui/grid/overview" target="_blank">Telerik Data Grid</a> and <a href="https://demos.telerik.com/blazor-ui/chart/overview" target="_blank">Telerik Chart</a> working in sync.

## Telerik Date Range Picker

- Scoped to a MM/YYYY calendar view
- Start / End Value <a href="https://docs.telerik.com/blazor-ui/components/daterangepicker/events" target="_blank">change events</a>
- Invokes custom <a href="https://docs.telerik.com/blazor-ui/components/grid/filter/overview" target="_blank">filtering</a> on the Telerik Grid

## Telerik Grid

- Remote Sort, Filter, and Paging using the Telerik Grid, DataSourceRequest, and DataEnvelope<T>. See also: BlazingCoffee.Server/Controllers/ProductsController.cs and <a href="https://github.com/telerik/blazor-ui/tree/master/grid/datasourcerequest-on-server" target="_blank">these sample projects</a>
- Custom filtering via Telerik Date Range Picker and FilterDescriptor through the <a href="https://docs.telerik.com/blazor-ui/components/grid/state" target="_blank">grid state</a>

## Telerik Chart (multi-series column)

- SalesByDateChart contains a configured Telerik Chart component
- Chart keeps in sync with Grid using the same date parameters - the page filters its data and passes it to the chart for visualization