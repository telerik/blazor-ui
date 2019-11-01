This example shows how to make the Telerik Chart component respond to a change in the browser size and re-render with the new dimensions.

The key points are:

* When the chart container size changes, you must call its `Refresh()` method.
* Other useful information is denoted with comments in the code.
* In this example, a static class is used to dispatch an "event" that comes from the JS Interop (it's perhaps the easiest way to call a C# method from JS).
* In your actual project you would need to change the JS Interop file to match your namespace.
* You can use a similar approach to reach to changes in dimensions coming from other sources, not just JS Interop and browser events.