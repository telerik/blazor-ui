# Load data on demand in a Hierarchy Grid

This example shows how to load data on demand when you have a Hierarchy Grid - the `DetailTemplate` contents will be loaded every time the corresponding template is expanded.

Key points of implementation:

1. Setup a Grid with [DetailTemplate](https://docs.telerik.com/blazor-ui/components/grid/hierarchy).

1. In another file, create a component that you want to be nested inside the `DetailTemplate`. It will contain the desired components (like the nested grid, or any other data representation you need).

1. Use the context of the grid `DetailTemplate` to pass a `[Parameter]` to the child component that identifies the parent record.

1. In the `OnParametersSetAsync` lifecycle method of the child component, pass that ID to the service which loads the data for the component.


