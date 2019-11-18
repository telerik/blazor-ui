# Localization in a Server Project

This sample project demonstrates a sample implementation of a service that provides localization for the Telerik UI for Blazor components from `.resx` files. You can use it as base for implementing a service for your own project.

Key points of interest:

* Review the [Localization](https://docs.telerik.com/blazor-ui/globalization/localization) article for more information on how the process works.
* Make sure to update the resource (`.resx`) files regularly - as the component suite grows more resource keys will be added.
* The Telerik-specific bits are the custom localization service registered in `Startup.cs` and the `.resx` files under `~/Resources`. Both of those are to be implemented by the application.
    * You can also see how to use those same resources for other texts in the `Index.razor` component where they are used to localize grid command buttons.
