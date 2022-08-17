# Window As a Service

This demo project shows how to use the `<TelerikWindow>` as a service in your application. You can `[Inject]` it in the desired pages and easily reuse it.

## To use the `<TelerikWindow>` as a service

* Create a service that creates a window instance. You can see an example of such a service fro the **Services** folder in this demo application and the `WindowService.cs` file. 
    * Register that service as a `Singleton` to ensure that the same instance of the `TelerikWindow` will be used across the entire application (`builder.Services.AddSingleton<WindowService>();`).
* Create a custom component that builds the `<TelerikWindow>` instances. You can see an example of such a service fro the **Components** folder in this demo application and the `WindowBuilder.razor` file. 
* Add the custom window builder component as a child of the `<TelerikRootComponent>` in the `TelerikLayout.razor` file and `[Inject]` the service that creates the window instances. Make sure to store the `@ref` of the custom window builder component.

## To use the demo application

* Run the demo application and navigate to the `Index.razor` page.
* Input the desired title and content of the window in the `<TelerikTextBox>` components. 
* Click the `Open New Window` button.

## Notes

* In the application we are removing the reference of the last added Window in the `OnAfterRender` lifecycle hook. This is just one way to make sure that you do not store unnecessary Window references and you can implement your own method to remove these references. 