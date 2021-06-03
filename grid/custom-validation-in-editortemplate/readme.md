# Remote (server, async) Validation upon Editing in Grid

The samples in this folder showcase how you can use custom (remote) validation in a Grid's `EditorTemplate` to prevent editing of items when they don't satisfy certain conditions. This is useful when validation conditions cannot be implemented through standard `DataAnnotation` validation.

## The General Concept

The grid provides the `OnUpdate` event where you receive the models the user altered, and you can send them out to your data service. This is also where you update the view-model with that updated data so the user actually sees it. You can read more about the general process of implementing the CUD operations in the grid in the <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/overview" target="_blank">Editing Overview</a> article.

In a real situation, server validation may fail for multiple reasons:

* invalid user input
* general server error
* server unavailable
* disconnected client
* failing HTTP requests to your WebAPI

In such cases, you should notify the user that the operation failed and suggest appropriate actions.

> To prevent the grid from leaving insert/edit mode when server validation fails, cancel the `OnUpdate` event by setting the `IsCancelled` flag of its event arguments to `true`.

Then, handle the errors and implement the view-model updates as appropriate for your application.

Of course, you may also want to use the model instance returned from the service to update the view-model in the case of a successful operation.

## Sample Details

In this sample, the WebAPI backend does not allow the user to leave the Name field empty and does not allow the word **Nameee** in the field.

The example shows how you can throw exceptions in the WebAPI backend with meaningful information, send instructions/errors to the client where they can bubble up and be shown to the user.

The core concept is to return a status code higher than 400 to indicate an error, and to ensure the messages are meaningful to the human that will read them.

In case of a successful operation, the data model is returned to the Blazor app so that the view-model can be updated with the actual database record (e.g., where an ID is assigned by the server, or other modifications are implemented).

You can read more about the general concepts of handling WebAPI errors in articles such as:

* <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1" target="_blank">MSDN: Handle WebAPI Errors</a>

* <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-3.1#server-validation" target="_blank">MSDN: Blazor Server Validation</a>

* <a href="https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api" target="_blank">Handling Errors in ASP.NET Core WebAPI by devtrends.co.uk</a>

Of course, a similar approach can be used in a server-side Blazor app. The example's purpose is to show one way to feed the grid with real data and to prevent data updates when errors occur.
