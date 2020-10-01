# ListView Validation

This example showcases a few scenarios of adding validation to the listview Edit and Insert operations.

The general way to do that is to:

1. Add the desired validation (forms, some async logic from a data service, whatever suits the project needs).
1. Cancel the ListView event when validation fails (set the `IsCancelled` flag of the event arguments to `true`) to keep it in edit/insert mode.

In this sample project, you will find the following examples:

* [synchronous validation](ValidationExamples/Pages/BasicFormValidation.razor) - one way to add an `EditForm` and instantiate an `EditContext` to use for validation

* [async methods](ValidationExamples/Pages/AsyncMethods.razor) - one way to use the edit form (or other remote validation) when the methods are `async`.

* [custom edit form](ValidationExamples/Pages/CustomForm.razor) - an example of implementing all the editing/inserting logic with your own code without having to take into account any built-in ListView logic and capabilities - this provides you with full control over the rendering, logic, async operations and so on.

You may also find useful articles like the following ones on handling server-side validation:

* <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1" target="_blank">MSDN: Handle WebAPI Errors</a>

* <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-3.1#server-validation" target="_blank">MSDN: Blazor Server Validation</a>

* <a href="https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api" target="_blank">Handling Errors in ASP.NET Core WebAPI by devtrends.co.uk</a>
