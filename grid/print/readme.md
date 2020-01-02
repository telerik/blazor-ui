# Print the Grid

This example shows how you can implement print button in the grid toolbar that can print the content of the current grid page. 

Key points of the implementation:

1. Create a media query that hides all your non grid content - such as `sidebar`, `header`, `footer` and so on. You can change them accroding to your project, layout and needs.
2. Hide all not needed components from the grid: in this example we hide the pager, filter row, toolbar, and we add some more customization rules to provide more suitable appearance. You can tweak them.
3. Create a [custom command button on the grid toolbar](https://docs.telerik.com/blazor-ui/components/grid/toolbar#custom-commands) that will invoke the printing. You can call it from anyweher else as well.
4. Call the browser `print()` JavaScript command through the JS Interop.
