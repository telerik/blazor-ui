# Dynamic Tabs

This example shows how to:

* Add and Remove tabs dynamically

* Get information about the currently active tab

* Set the content of the tabs dynamically

The core concept is to have a collection of descriptors for the tabs and to loop over it in order to create the necessary `TabStripTab` instances, and conditional statements in the markup can also help you set different content based on certain conditions.

You can then extract information about the tab by its index, or other identificator. Child components can be used to load data on demand through their lifecycle events (`OnParametersSetAsync`) and to also abstract away content that will be similar between tabs, but for different keys.

The `@key` is used on the tabs to ensure their child components will re-render fully. You may choose to remove it if you only have the same (repeated) content, and only need to change the key by which it is fetched.

Comments in the code offer more details.
