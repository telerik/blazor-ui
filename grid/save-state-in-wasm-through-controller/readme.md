# Saving Grid State in a Blazor WebAssembly project

This example shows how you can save the state of the Grid in a WASM project through a **Controller** and custom service that calls the **browser's LocalStorage**. 

Using a controller, we store the state in a property for the demo. In a real case, the state should be stored in a **database**. The state won't be persisted after **refresh** on the first page with the controller example since the property value will be disposed of.

Storing the state from the browser's LocalStorage lets you persist the state even after page **refresh**.