# Item Selection in ListView

The <a href="https://docs.telerik.com/blazor-ui/components/listview/overview" target="_blank">Telerik listview</a> lets you control the item rendering entirely, which means that implementing selection is up to the application logic. The listview cannot know when and how an action should be treated as selection because it does not own the rendering. Moreover, since it does not control the rendering, it cannot attach the appropriate event handlers.

Implementation details in this sample:

* An `onclick` handler is used on the item wrapper to toggle selection. You can replace this with UX of your choice (such as a checkbox, a button or another event).

* The model contains a `Selected` field to allow selection.

* The model contains an `Id` field to uniquely identify records.

* A CSS class is added to the listview item based on its selected state

* Sample CSS is added to showcase selected items that you can replace with your actual styles.

Depending on your scenario, you may want to consider the following:

* Move the logic that pre-selects items from the data service to a separate location.

* Store the record IDs that are to be selected and apply the selection only in the view-model, not in the main data store (e.g., keep a per-user store of selected item IDs somewhere else).

* Add logic in the event handler that toggles selection that can load further data on demand, or implement other logic (like limiting the number of selected items or showing other information to the user).