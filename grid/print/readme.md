# Print the Grid

This example shows how you can implement print button in the grid toolbar that can print the content of the current grid page. 

In this project you will find two examples:

* How to print the whole rendered Grid
* How to print only certain columns of the Grid (for example print the Grid without the Command column)

Key points of the implementation:

1. Create a media query that hides all your non grid content - such as `sidebar`, `header`, `footer` and so on. You can change them accroding to your project, layout and needs.
2. Hide all not needed components from the grid: in this example we hide the pager, filter row, toolbar, and we add some more customization rules to provide more suitable appearance. You can tweak them.
   * In case you want to print only certain columns, use a bool flag and the `Visible` parameter of the columns to define which of them will not be visible in print mode.
3. Create a [custom command button on the grid toolbar](https://docs.telerik.com/blazor-ui/components/grid/toolbar#custom-commands) that will invoke the printing. You can call it from anyweher else as well.
4. Call the browser `print()` JavaScript command through the JS Interop.