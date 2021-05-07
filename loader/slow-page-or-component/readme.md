# LoaderContainer usage in the MainLayout and on an individual page

In this sample project, there are three examples of the `LoaderContainer` usage. You can navigate through them from the nav menu on the left side.

* Use one `LoaderContainer` on the main layout of the app and trigger it from different components/pages.
    * Toggling the `LoaderVisible` property value in the main layout lets you control the component in this sample. Make sure to call `StateHasChanged` to re-render the layout. A `CascadingParameter` in the layout passes a reference to all components in the app that need it.
* Show a loading sign for slow pages during navigation between them.
    * The same field and method from the main layout are used in this example.
* Show a loading sign for components that are slow to load (such as individual tabs in a tabstrip).
    * Each component can use the standard pattern of showing a loading sign based on missing data and fetching the necessary data in its `OnParametersSetAsync` lifecycle method. This is showcased for one of the tabs.


> Add a loader in the main layout. The result from the first example in the project.

![Loader in the main layout](images/loader-container-in-main-layout.gif)

