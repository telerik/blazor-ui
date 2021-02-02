# Dynamic Tabs

#### The example under the `Index` page shows how to:

* Add and Remove tabs dynamically

* Get information about the currently active tab

* Set the content of the tabs dynamically

The core concept is to have a collection of descriptors for the tabs and to loop over it in order to create the necessary `TabStripTab` instances, and conditional statements in the markup can also help you set different content based on certain conditions.

You can then extract information about the tab by its index, or other identificator. Child components can be used to load data on demand through their lifecycle events (`OnParametersSetAsync`) and to also abstract away content that will be similar between tabs, but for different keys.

The `@key` is used on the tabs to ensure their child components will re-render fully. You may choose to remove it if you only have the same (repeated) content, and only need to change the key by which it is fetched.

Comments in the code offer more details.

#### The example under the `Counter` page shows how to:

* Get the underlying model from the active tab

* Add tabs dynamically

You can dynamically create `TabStripTab` instances by looping through a collection of descriptors. To extract the underlying model from the currently active tab you can:

1. Create a collection of all Visible tabs
    * This example shows how to do that by using the `Visible` property from the `TabDescriptor` as a condition.
1. Use the `ActiveTabIndex` and `ActiveTabIndexChanged`
    * In the handler for the `ActiveTabIndexChanged` event you can get the model from the collection of visible tabs based on the index received as an argument in the event.
1. Create a deep copy of the model and store it in a property. This would ensure that the model would not be change unintentionally. 

