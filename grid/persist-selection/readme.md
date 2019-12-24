# Persist Selection Across Pages

This example shows how you can keep the selected rows across different pages, so that the user can select multiple items from different pages without losing previous selection:

1. Set the `SelectedItems` to a list that will keep all selected items across all pages.
1. Set variables for the page size and current page (the current page needs two-way binding).
1. Handle the `SelectedItemsChanged` event of the grid.
1. In the event handler, implement logic that adds newly selected items and removes deselected items from the persistent collection.
1. Do NOT use two-way binding of the selected items.

This project demonstrates one way to implement such logic, feel free to improve it for performance and open a pull request.