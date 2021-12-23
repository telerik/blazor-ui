# Tooltips for grid columns with load-on-demand

This sample project contains two examples of the `Tooltip` usage in `Grid`. You can navigate through them from the nav menu on the left side.

The result from both examples is the same, but there is a difference in the implementation. 

* The first example uses one instance of the `Tooltip` for all cells. With this approach, the performance is improved. 

* The second example uses a separate instance of the `Tooltip` for every cell. This approach gives a lot of extra flexibility if needed.

Both examples show how you can add tooltips for elements in a grid column, and have those tooltips fetch their content on demand when they show up.

Key points:
* one model describes the grid rows, another the data shown in the tooltips
* a service returns data generated on demand so you can replace with your actual service
* a component in the tooltip content implements the data loading, you can read more about this in the [Tooltip Template](https://docs.telerik.com/blazor-ui/components/tooltip/template) article