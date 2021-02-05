# Unit Testing Blazor Apps with Telerik UI for Blazor

This folder contains a few sample projects that illustrate the basics of writing unit tests for a Blazor application that also has the Telerik UI for Blazor components in it.

In this collection of sample projects, the application under test is in the `testing-sample-app` folder.

## bUnit

<a href="https://bunit.egilhansen.com" target="_blank">bUnit</a> is a popular unit testing framework for Blazor. To test Telerik Blazor components with bUnit, you need to:

* Ensure there is an `IJSRuntime` service available so that the components can initialize properly.

* Add the Telerik service (call `context.Services.AddTelerikBlazor();` like in a regular app, and mock the needed services such as localization).

* Add a `TelerikRootComponent` (read more about it <a href="https://docs.telerik.com/blazor-ui/getting-started/what-you-need#project-configuration" target="_blank">here</a>).

In the code of your tests:

* Initialize the Telerik components as described above. In these sample projects, that scaffolding is done in `TestContextExtensions` - the extension method `AddTelerikBlazor` is added to the test context and you should call that before the actual test code.

* Add the Telerik components in that root component.

* For popup components (such as the Window or Tooltip), look for their content inside the `TelerikRootComponent`, not in the place of declaration.



### bUnit and Moq

You can find a sample project that uses `bUnit`, and <a href="https://github.com/moq/moq4" target="_blank">`Moq`</a> in the [bUnit-moq](bUnit-moq) folder.


### bUnit and Telerik JustMock

You can find a sample project that uses `bUnit` and <a href="https://www.telerik.com/products/mocking.aspx" target="_blank">`Telerik JustMock`</a> in the [bUnit-justmock](bUnit-justmock) folder.

