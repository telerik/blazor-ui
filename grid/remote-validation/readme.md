# Remote (server, async) Validation upon Insert or Update in Grid

The samples in this folder showcase how you can use remote validation on the server to prevent updates or inserts of items when then don't satisfy certain conditions that cannot be implemented through the standard `DataAnnotation` validation.

## The General Concept

The grid provides the `OnCreate` and `OnUpdate` events where you receive the models the user altered, and you can send them out to your data service. This is also where you update the view-model with that updated data so the user actually sees it. You can read more about the general process of implementing the CUD operations in the grid in the <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/overview" target="_blank">Editing Overview</a> article.

The example in the documentation assumes that the operations are always successful and directly updates the view-model. In a real situation this may not always be the case - server validation may fail, the server may have a general error, be unavailable, or the client may be disconnected and HTTP requests to your WebAPI may fail. In such cases, you should notify the user that the operation failed, and avoid updating the view-model, and you may also want to keep the grid in edit/insert mode so that the user can either try again, or fix the input so that it passes.

> To prevent the grid from leaving insert/edit mode when server validation fails, cancel the `OnCreate` or `OnUpdate` event by setting the `IsCancelled` flag of its event arguments to `true`.

Then, handle the errors and implement the view-model updates as appropriate for your application.

Of course, you may also want to use the model instance returned from the service to update the view-model in the case of a successful operation.

## Sample Details

In this sample, the WebAPI backend checks for duplicate records (does not allow inserting a new record for a date that already has a forecast), and does not allow the letter "a" in the Summary of updated items.

The exmample shows how you can throw exceptions in the WebAPI backend with meaningful information, send those meaningful instructions/errors to the client where they can bubble up through the service and be shown to the user.

The core concept is to return a status code higher than 400 to indicate an error, and to ensure the messages are meaningful to the human that will read them. This sample shows only how to cancel the grid operation and view-model update upon an error, and does not implement capturing of other unexpected errors, logging, translation and so on.

In case of a successful operation, the data model is returned to the Blazor app so that the view-model can be updated with the actual database record (e.g., where an ID is assigned by the server, or other modifications are implemented).

You can read more about the general concepts of handling WebAPI errors in articles like the following ones:

* <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1" target="_blank">MSDN: Handle WebAPI Errors</a>

* <a href="https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api" target="_blank">Handling Errors in ASP.NET Core WebAPI by devtrends.co.uk</a>

Of course, a similar approach can be used in a server-side Blazor app, as well as with or without WebAPI - the core concept is bubbling exceptions. There can also be many other ways to handle such errors, and this example is by no means exhaustive or definitive, its purpose is to show one way to feed the grid with real data and to prevent data updates when errors occur.

