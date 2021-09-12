# Select a Row and Scroll the Grid to it

In some cases, you want to select a row programmatically based on some program logic and conditions, and you want the user to see it, so you want to scroll the grid to it.

To do that with **regular paging**:
1. Ensure the grid is on the same page as the record (not part of this example).
    * Implement if/as necessary for your project.
1. Make sure the grid has rendered after the selection operation (usually a rendering frame delay is enough).
1. Use a bit of JavaScript to make the browser scroll the first selected row into view.
    * Tweak this logic as necessary for your case.


To do that with **virtual scrolling**, you must set the `Skip` of the grid state to the desired item index. The example offers comments in the code on the tricky points of this, because there is no guarantee on which "page" of data this item is.