# Message Box

This example shows how you can implement a message box type of service in Blazor.

Key points of interest:

* There are two implementations with generally similar results - one uses a service that exposes a callback that you chain when showing the popup, the other creates popups dynamically and provides a result in a variable.
* A service (make sure it is scoped so it does not affect more than one user) exposes a method that shows a predefined dialog according to some options it can take.
* The service method exposes a callback that is invoked when the user confirms the action so you can finish up work (like update UI, load data, etc.).
* The service requires a component to be present at the root of the app (just inside the `TelerikRootComponent`).
* In the callback example, the `Index` page shows a confirm dialog that shows an alert dialog when the user presses Yes. The `FetchData` page shows how you can confirm the deletion of a record in a grid through a custom command button.
* In the dynamic creation example, the `FetchData` page shows how you can extract the insertion and editing of a record in a grid through a custom command button.

Thanks to [sylvainonweb](https://github.com/sylvainonweb) for sharing this example.

You can also find a component approach that implements similar logic in the [Confirm Button](https://github.com/telerik/blazor-ui/tree/master/common/confirm-button) example.
