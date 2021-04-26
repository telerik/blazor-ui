# Unit Testing Blazor Apps with Telerik UI for Blazor

This folder contains a few sample projects that illustrate the basics of writing unit tests for a Blazor application that also has the Telerik UI for Blazor components in it.

In this collection of sample projects, the application under test is in the `testing-sample-app` folder.

## bUnit

<a href="https://bunit.egilhansen.com" target="_blank">bUnit</a> is a popular unit testing framework for Blazor. To test Telerik Blazor components with bUnit, you need to:

* Ensure there is an `IJSRuntime` service available so that the components can initialize properly.

* Add the Telerik service (call `context.Services.AddTelerikBlazor();` like in a regular app, and mock the needed services such as localization).

* Add a `TelerikRootComponent` (read more about it <a href="https://docs.telerik.com/blazor-ui/getting-started/what-you-need#project-configuration" target="_blank">here</a>).

In the code of your tests:

* Initialize the Telerik components as described above. In these sample projects, that scaffolding is done in `TelerikTestContext` - this is a class your test classes can inherit from which takes care of setting up the services and the root component.

    * This class inherits the standard `TestContext` of the `bUnit` framework and overrides its rendering methods to ensure there is a Telerik root component first. Its constructor initializes the services. If you don't inherit such a class, you need  to do that scaffolding yourself before starting a test, and you need to add components under test to the Telerik Root Component.

* Add components under test to the standard render tree as with other components you test.

* For popup components (such as the Window or Tooltip, or the dropdowns), look for their content inside the `TelerikRootComponent`, not in the place of declaration. In this sample, the field is called `RootComponent` and comes from the base class (`TelerikTestContext`).

    * Such popups render their DOM elements only when they are shown because that optimizes the performance of the Blazor app. Opening them and interacting with the new DOM that is created may require an e2e test rather than a unit test (see below).

>Note: bUnit renders the components with C# alone and does not execute JS Interop calls. Thus, components that use JS to implement certain functionality (which is sometimes required for complex things, especially those that don't have "native" Blazor API) cannot show such functionality in that "server" rendering you can test with C# through the RenderTree. For such components, you can unit test their in-memory instances through their parameters. To test their DOM, you should use e2e testing. One such example is provided here with the textbox component, and comments in the test code offer more details on what you can unit test and how.

### bUnit and Telerik JustMock

You can find a sample project that uses `bUnit` and <a href="https://www.telerik.com/products/mocking.aspx" target="_blank">`Telerik JustMock`</a> in the [bUnit-justmock](bUnit-justmock) folder.


## e2e

For end-to-end testing (e2e) that lets you simulate user actions such as clicks, input and so on, you can consider tools like <a href="https://docs.telerik.com/blazor-ui/integrations/e2e-testing-with-test-studio">Telerik Test Studio</a> that integrates with Blazor and even has translators for the Telerik UI for Blazor components.

### Selenium

Selenium WebDriver is also a valid option for creating tests.

When working with popup elements (especially dropdowns), you need to take into account a couple of factors:

* By default, there may be an animation when they show up, so the tests need to wait a little between opening the popup and looking for its elements.
* Popup elements are not rendered in the place of declaration of the component, so you need to use appropriate selectors. Often times looking for a `.k-popup` element could help, or you could even assign the `PopupClass` of dropdowns to more easily find particular ones.

Here is a sample test that waits for the popups to render before looking for elements of theirs:

```
[TestMethod]
public void TestMethod1()
{
    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
    // one sample selector to find a dropdownlist arrow element
    IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#Id > span > span.k-select > span")));
    // click the arrow so the dropdown opens
    element.Click();
    // look for a popup element
    element = wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("k-popup")));
    // Popup has `transition-duration: 300ms` so we must wait a bit before we can interact
    Thread.Sleep(500);
    // interract with the popup element
    element.FindElement(By.XPath("//li[contains(@class, 'k-item')]")).Click();
    // You may want/need to add such a wait time to ensure visually that the item is selected
    // Thread.Sleep(2000);
}
```
