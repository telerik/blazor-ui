# Localization in a Client (WASM) Project

This sample project demonstrates a sample implementation of a service that provides localization for the Telerik UI for Blazor components from `.resx` files. You can use it as base for implementing a service for your own project.

Key points of the implementation:

* Review the [Localization](https://docs.telerik.com/blazor-ui/globalization/localization) article for more information on how the process works.
* Make sure to update the resource (`.resx`) files regularly - as the component suite grows more resource keys will be added.
* The `CultureChooser` component uses the standard approaches for changing the culture. You can find them in its corresponding `js` file, and in the `Program.cs` file of the `Client` app. These depend on the framework and the application. You can change it to `en-US`, `fr-FR` or `bg-BG` in this sample without implementing anything else.
* The Telerik-specific bits are the custom localization service registered in the `Client` app in `Program.cs` and the `.resx` files - both are in the `Shared` project under the `~/Services` and `~/Resources` folders respectively. Both of those are to be implemented by the application.
    * You can also see how to use those same resources for other texts in the `Index.razor` component where they are used to localize grid command buttons.
    
    * To ensure the needed resource class is generated, open the `resx` file in Visual Studio and set its `Access Modifier` to `Public`. This will generate an entry in your `csproj` file similar to the following, but in my tests adding the entry to the proj file manually does not always generate the `designer` file for the resource:

        **csproj**
        
                <ItemGroup>
                  <EmbeddedResource Update="Resources\TelerikMessages.resx">
                    <Generator>PublicResXFileCodeGenerator</Generator>
                    <LastGenOutput>TelerikMessages.Designer.cs</LastGenOutput>
                  </EmbeddedResource>
                </ItemGroup>
