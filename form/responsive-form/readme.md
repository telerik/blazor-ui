# Responsive Form

This example shows how to make the Telerik Form component respond to a change in the browser size and re-render with the new dimensions.

The key points are:

* To capture the browser size and some predefined media brakpoints this project uses the ready-made package [Blazor Size by Ed Charbeneau](https://github.com/EdCharbeneau/BlazorSize)
* Other useful information is denoted with comments in the code.
* In this example, the number of [columns](https://docs.telerik.com/blazor-ui/components/form/colums) and the [Orientation](https://docs.telerik.com/blazor-ui/components/form/orientation) of the Form are changed based on the size of the browser size.
* The columns count in the form is taken by using reflection, you might change it as per your application needs.
