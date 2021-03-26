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

* For popup components (such as the Window or Tooltip, or the dropdowns), look for their content inside the `TelerikRootComponent`, not in the place of declaration.

>Note: bUnit renders the components with C# alone and does not execute JS Interop calls. Thus, components that use JS to implement certain functionality (which is sometimes required for complex things, especially those that don't have "native" Blazor API) cannot show such functionality in that "server" rendering you can test with C# through the RenderTree. For such components, you can unit test their in-memory instances through their parameters. To test their DOM, you should use e2e testing. One such example is provided here with the textbox component, and comments in the test code offer more details on what you can unit test and how.

### bUnit and Telerik JustMock

You can find a sample project that uses `bUnit` and <a href="https://www.telerik.com/products/mocking.aspx" target="_blank">`Telerik JustMock`</a> in the [bUnit-justmock](bUnit-justmock) folder.


## e2e

For end-to-end testing (e2e) that lets you simulate user actions such as clicks, input and so on, you can consider tools like <a href="https://docs.telerik.com/blazor-ui/integrations/e2e-testing-with-test-studio">Telerik Test Studio</a> that integrates with Blazor and even has translators for the Telerik UI for Blazor components.

