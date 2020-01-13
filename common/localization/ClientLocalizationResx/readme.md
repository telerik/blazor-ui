# Localization in a Client (WASM) Project

At the time of writing, there does not seem to be a unified, recommended, or even a properly working approach for localizing client-side (WASM) Blazor apps. This example shows only a sample way of implementing a service to localize the Telerik components and not an entire application. You can use it as base for implementing such a service for your own project.

Key points of the implementation:

* Review the [Localization](https://docs.telerik.com/blazor-ui/globalization/localization) article for more information on how the process works.
* The `CurrentUICulture` is hardcoded in the `Client.Program.Main` method to `fr-FR` in this example. You can change it to `en-US` or `bg-BG` in this sample without implementing anything else.
* The translations are generated from `.resx` files through the [gulp-resx-convert node package](https://www.npmjs.com/package/gulp-resx-convert). These files are in the `Shared` project so it can act as a data source. This package can easily generate `json` files as well.
    * make sure to run `npm install` in the `Shared` project before you begin. If you do not want to use this generation, delete the `gulpfile.js` file and use the classes that are already committed.
    * The project namespaces are important for the class generation and for Reflection, make sure to retouch them for your project.
    * These localization classes are dynamically generated so Reflection is used to fetch the correct ones in this example. You can implement any other approach you prefer.
    * Make sure to update the resource (`.resx`) files regularly - as the component suite grows more resource keys will be added.
    * Set the `Build Action` of the `resx` files to `None`, otherwise the framework will fail to build the project - it seems to attempt to generate resource assemblies from those files, but throws exceptions that they are duplicated.
* The Telerik-specific bits are the custom localization service registered in the `Client` app in `Startup.cs` and the `.resx` files in `Shared` under `~/ResxSource`. Both of those are to be implemented by the application.
    * You can also see how to use those same resources for other texts in the `Index.razor` component where they are used to localize grid command buttons.
