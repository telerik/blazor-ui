# Unit Testing Blazor Apps with Telerik UI for Blazor

This folder contains a few sample projects that illustrate the basics of writing unit tests for a Blazor application that also has the Telerik UI for Blazor components in it.

## bUnit

<a href="https://bunit.egilhansen.com" target="_blank">bUnit</a> is a popular unit testing framework for Blazor. To test Telerik Blazor components with bUnit, you need to:

* Ensure there is an `IJSRuntime` service available so that the components can initialize properly.

* Add the Telerik service and a `TelerikRootComponent`.

    * In tests, add the Telerik components in that root component (read more about this <a href="https://docs.telerik.com/blazor-ui/getting-started/what-you-need#project-configuration" target="_blank">here</a>)

    * For popup components (such as the Window or Tooltip), look for their content inside the `TelerikRootComponent`, not in the place of declaration.


### bUnit and Moq

You can find a sample project that uses `bUnit`, and `Moq` in the [bUnit-moq](bUnit-moq) sample project.

The scaffolding of the root component and the JS Interop is done in `TestContextExtensions` - the extension method `AddTelerikBlazor` is added to the test context and you should call that before the actual test code.

### bUnit and Telerik JustMock



