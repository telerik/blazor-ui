# Load data on demand with a Heirarchy Grid

This example shows how to load data on demand when you have a Hierarchy Grid.

Key points of implementation:
1. Setup a Grid with DetailTemplate
1. In another file, set a component that you want to be nested inside the DetailTemplate and pass a `[Parameter]`. Pass that parameter to the service which loads the data for the component in the `OnParametersSet` lifecycle method.
1. On the main page (in this projects case `Index.razor`) use the context of the DetailTemplate to pass a value to the nested component's parameter. 
