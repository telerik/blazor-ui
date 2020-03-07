# Tooltips for grid columns with load-on-demand

This example shows how you can add tooltips for elements in a grid column, and have those tooltips fetch their content on demand when they show up.

Key points:
* one model describes the grid rows, another the data shown in the tooltips
* a service returns data generated on demand so you can replace with your actual service
* a component in the tooltip content implements the data loading, you can read more about this in the [Tooltip Template](https://docs.telerik.com/blazor-ui/components/tooltip/template) article