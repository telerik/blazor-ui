# Merge Grid Cells or Rows

To control the table cell and row rendering, you must use the <a href="https://docs.telerik.com/blazor-ui/components/grid/templates/row" target="_blank">Row Template</a> of the grid.

Then, you can set the `rowspan` and `colspan` attributes of the `<td>` elements as necessary to merge them.

Make sure to provide valid HTML - if you make one cell larger, you must not render the appropriate number of adjacent cells. For example, if you set `rowspan=2`, the next row must not render that cell.