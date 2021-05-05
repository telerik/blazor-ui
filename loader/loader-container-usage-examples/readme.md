# LoaderContainer usage in the MainLayout and on an individual page

By updating the `LoaderVisible` property value in the main layout, you can achieve the desired result. 

Implement an approach that updates the value and calls the `StateHasChanged` method. The approach is relying on defining a method where the actual update is done and passing that action as a `CascadingParameter` to all the other components in your app.

>caption Add a loader in the main layout. The result from the first example in the project.

![Loader in the main layout](images/loader-container-in-main-layout.gif)

In this sample project, there are three examples of the `LoaderContainer` usage. You can navigate through them from the nav menu on the left side.