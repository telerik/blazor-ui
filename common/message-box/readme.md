# Message Box

This example shows how you can implement a message box type of service in Blazor.

Key points of interset:

* A service (make sure it is scoped so it does not affect more than one user) exposes a method that shows a predefined dialog according to some options it can take.
* The service method exposes a callback that is invoked when the user confirms the action so you can finish up work (like update UI, load data, etc.).
* The service requires a component to be present at the root of the app (just inside the `TelerikRootComponent`).
* The `Index` page shows a confirm dialog that shows an alert dialog when the user presses Yes. The `FetchData` page shows how you can confirm the deletion of a record in a grid through a custom command button.

Thanks to [sylvainonweb](https://github.com/sylvainonweb) for sharing this example.

You can also find a component approach that implements similar logic in the [Confirm Button](https://github.com/telerik/blazor-ui/tree/master/common/confirm-button) example.
