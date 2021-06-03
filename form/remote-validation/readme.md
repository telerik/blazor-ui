# Remote (server, async) Validation upon Input in Form

The samples in this folder showcase how to use remote validation on the server to prevent invalid user input. This is useful when validation conditions cannot be implemented through standard `DataAnnotation` validation.

## The General Concept

In a real situation, server validation may fail for multiple reasons:

* invalid user input
* general server error
* server unavailable
* disconnected client
* failing HTTP requests to your WebAPI

In such cases, you should notify the user that the operation failed and suggest appropriate actions.

Handling the errors as appropriate for your application.

## Sample Details

In this sample, the WebAPI backend does not allow the user to leave the Description field empty if **Defense** classification is selected. In the other cases, the Description field is not required.

The example shows how you can throw exceptions in the WebAPI backend with meaningful information, send those meaningful instructions/errors to the client where they can bubble up and be shown to the user.

The core concept is to return a status code higher than 400 to indicate an error, and to ensure the messages are meaningful to the human that will read them.

You can read more about the general concepts of handling WebAPI errors in articles like the following ones:

* <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1" target="_blank">MSDN: Handle WebAPI Errors</a>

* <a href="https://docs.microsoft.com/en-us/aspnet/core/blazor/forms-validation?view=aspnetcore-3.1#server-validation" target="_blank">MSDN: Blazor Server Validation</a>

* <a href="https://www.devtrends.co.uk/blog/handling-errors-in-asp.net-core-web-api" target="_blank">Handling Errors in ASP.NET Core WebAPI by devtrends.co.uk</a>

Of course, a similar approach can be used in a server-side Blazor app. The example's purpose is to show one way to fill the input in the form with real data and to prevent data submission when errors occur.
