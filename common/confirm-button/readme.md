# Confirm Button Click

This project demonstrates how you can implement a confirmation dialog for the click of a button.

Points of interest:

* The components that encapsulate this are in the `Shared` folder.
* The first example (`Counter`) is a simple button component that raises its click event only when the user confirms the dialog. 
    * Note that it will still trigger forms validation, for forms consider using the `OnValidSubmit` and `OnInvalidSubmit` events of the form itself.
* The second example (`FetchData`) shows also confirmation window component that you can use in other cases, like to confirm the deletion of a record in a grid.
    * The provided example shows two ways to integrate this - one requires less code but needs a column in the grid (the one where the confirmable button component is used), and one where the built-in Delete button is used (which requires a few more lines of code and uses a separate confirm window component).
* You can further refactor this sample as needed. For example, use only one component and put the window inside the button component if you only need one case; or add more parameters and business logic; or implement a `Show()` method and references instead of parameter binding; or change the simple strings to `RenderFragment` or use a `MarkupString` instance so you can put more complex content in the dialog.
* 
Thanks to [sylvainonweb](https://github.com/sylvainonweb), you can also find a [MessageBox service example](https://github.com/telerik/blazor-ui/tree/master/common/message-box).