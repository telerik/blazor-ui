# Blazor Demo Project using Telerik UI for Blazor Components

This is the repository of the Blazor Coffee Warehouse sample project which contains a ready-to-run Blazor WASM project with some of the most popular Telerik UI for Blazor components.The sample project demonstrates how to use the [UI for Blazor components](https://https://www.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) and is available for browsing at https://demos.telerik.com/blazor-coffee/. 

## In This Article

* [Used UI for Blazor Components](#used-ui-for-blazor-components)
* [Blazor Demo Features](#blazor-demo-features)
* [Requirements](#requirements)
* [Running the sample Blazor project](#running-the-sample-blazor-project)
* [Troubleshooting](#troubleshooting)
* [Licensing](#licensing)
* [Setup with Telerik UI for Blazor Commercial](#setup-with-telerik-ui-for-blazor-commercial)
* [Where can I find help?](#where-can-i-find-help)
* [Contribution](#contribution)
* [Useful Links](#useful-links)

## Used UI for Blazor Components

In the sample project, you can explore the usage of the following Blazor UI Components:
- [Blazor Data Grid UI component](https://demos.telerik.com/blazor-ui/grid/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Form UI component](https://demos.telerik.com/blazor-ui/form/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Card UI component](https://demos.telerik.com/blazor-ui/card/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Charts UI component](https://demos.telerik.com/blazor-ui/chart/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
- [Blazor Line Chart UI component](https://demos.telerik.com/blazor-ui/chart/line-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
- [Blazor Column Bar Chart UI component](https://demos.telerik.com/blazor-ui/chart/column-chart?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
- [Blazor Floating Label UI component](https://demos.telerik.com/blazor-ui/floatinglabel/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
- [Blazor Drawer UI component](https://demos.telerik.com/blazor-ui/drawer/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
- [Blazor DateInput UI component](https://demos.telerik.com/blazor-ui/dateinput/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor DateRangePicker UI component](https://demos.telerik.com/blazor-ui/daterangepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor DateTimePicker UI component](https://demos.telerik.com/blazor-ui/datetimepicker/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor DropDownList UI component](https://demos.telerik.com/blazor-ui/dropdownlist/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Editor UI component]( https://demos.telerik.com/blazor-ui/editor/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Button UI component](https://demos.telerik.com/blazor-ui/button/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor ButtonGroup UI component](https://demos.telerik.com/blazor-ui/buttongroup/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor TextBox UI component](https://demos.telerik.com/blazor-ui/textbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor TextArea UI component](https://demos.telerik.com/blazor-ui/textarea/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor MaskedTextBox UI component](https://demos.telerik.com/blazor-ui/maskedtextbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Checkbox UI component]( https://demos.telerik.com/blazor-ui/checkbox/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
- [Blazor Tooltip UI component](https://demos.telerik.com/blazor-ui/tooltip/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)

## Blazor Demo Features

The current demo app includes examples of the following features in the Blazor WASM application:
- Globalization / Localization
- Full Stack .NET
    - Blazor Client
    - Web API Server
    - Entity Framework Core
    - Shared logic and resources
- Theming
   - [Three built-in themes: Default Theme, Material and Bootstrap](https://docs.telerik.com/blazor-ui/styling-and-themes/overview?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) 
   - SASS architecture
   - Compatible with [Telerik Theme Builder](https://themebuilder.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)

## Requirements

- [.NET 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Telerik UI for Blazor](https://www.telerik.com/blazor-ui) (Trial or Commercial)
- [npm](https://www.npmjs.com/) (node package manager, for sass themes)

## Running the sample Blazor project

* Open the solution file in VS 2022 and, if not already, set the `BlazingCoffee.Server` project as a Startup project.
* Hit Ctrl + F5.

## Troubleshooting

If you see a never-ending loader on the home screen, check the browser console for errors. You may see a 404 error about a missing `/_framework/blazor-hotreload.js`. In this case, disable Hot Reload in the Visual Studio settings:

* **Debugging** > **General** and also in
* **Debugging** > **.NET**.

Another option is to run the app through the **Kestrel** web server instead of **IIS Express** by selecting the `BlazingCoffee.Server` launch profile. This works even with enabled hot reload:

<img width="495" alt="Use the BlazingCoffee.Server launch profile to use the Kestrel web server" src="https://github.com/user-attachments/assets/2d7bd2f5-2145-435d-b57b-a8a1e26fd157">

## Licensing

Telerik UI for Blazor is a commercial UI library. To use the components, you need to either register for a free trial or purchase a license.

The 30-day free trial can be obtained from [Telerik UI for Blazor product page](https://www.telerik.com/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) and gives you access to all Telerik UI for Blazor components and their full functionality. For more infromation regarding the available license and budnle options you can review the [product pricing page](https://www.telerik.com/purchase/blazor-ui?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
).

For both active trialist and license holders you get access to our legendary technical support provided directly by the UI for Blazor dev team!

## Setup with Telerik UI for Blazor Commercial

If you are using a commercial version of Telerik UI for Blazor.

- In `BlazingCoffee.Client.csproj` remove `.Trial` from the package name. You should have:

    ```
    <PackageReference Include="Telerik.UI.for.Blazor" Version="x.x.x" />
    ```

- In `BlazingCoffee/Client/Host.razor`, remove `.Trial` from the package name in the script path. You should have

    ```
    <script src="_content/Telerik.UI.for.Blazor/js/telerik-blazor.js"></script>
    ```

- In `BlazingCoffee.Shared.csproj` remove `.Trial` from the package name. You should have:

    ```
    <PackageReference Include="Telerik.UI.for.Blazor" Version="x.x.x" />
    ```
## Where can I find help?

1. For community support, we recommend asking questions on Stack Overflow using the [telerik-blazor tag](http://stackoverflow.com/questions/tagged/telerik-blazor).
2. If you have an active trial or license, you can use the official [support channel](https://www.telerik.com/account/support-tickets) for questions, technical assistance, bug reports or problem resolutions. 

## Contribution

**Issues and Pull Requests are welcome.** 

To submit a pull request, you should **first [fork](https://docs.github.com/en/free-pro-team@latest/github/getting-started-with-github/fork-a-repo) the repo**.

## Useful Links

* Browse all [UI for Blazor component demos live](https://demos.telerik.com/blazor-ui)
* Browse [the Telerik UI for Blazor documentation](https://docs.telerik.com/blazor-ui/introduction?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
* Follow this link to [report bugs and add feature requests](https://feedback.telerik.com/blazor?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
* Browse or contribute to [localization texts](https://github.com/telerik/blazor-ui-messages?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
) used in the samples
* Create, run, share and test Blazor code snippets directly in the browser in our [Blazor REPL code runner](https://blazorrepl.telerik.com/?utm_medium=referral&utm_source=github&utm_campaign=blazor-awareness-bc-demo-app
)
