# ListView Validation

This example showcases a few scenarios of adding validation to the listview Edit and Insert operations.

The general way to do that is to:

1. Add the desired validation (forms, some async logic from a data service, whatever suits the project needs).
1. Cancel the ListView event when validation fails (set the `IsCancelled` flag of the event arguments to `true`) to keep it in edit/insert mode.

In this sample project, you will find the following examples:

* [synchronous validation](ValidationExamples/Pages/BasicFormValidation.razor) - one way to add an `EditForm` and instantiate an `EditContext` to use for validation

* [async methods](ValidationExamples/Pages/AsyncMethods.razor) - one way to use the edit form (or other remote validation) when the methods are `async`.

* [custom edit form](ValidationExamples/Pages/CustomForm.razor) - an example of implementing all the editing/inserting logic with your own code without having to take into account any built-in ListView logic and capabilities - this provides you with full control over the rendering, logic, async operations and so on.
