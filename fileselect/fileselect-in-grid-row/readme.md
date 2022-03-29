# File Select (Upload) in Grid Row

Sometimes, you may need to associate files with a model that you edit in a grid.

To upload the files you would use a component like the <a href="https://demos.telerik.com/blazor-ui/fileselect/overview" target="_blank">FileSelect</a> or <a href="https://demos.telerik.com/blazor-ui/upload/overview" target="_blank">Upload</a>, and you need a way to know which row (model) they are about.

The typical approach would be to handle the appropriate component event and pass the current model through a **lambda expression**. Then, apply that metadata in the file saving logic.

In this example, the `FileSelect` component is used and data from the model is used to save the files in specific folders (that depend on the "employee" ID) through the `OnSelect` <a href="https://docs.telerik.com/blazor-ui/components/fileselect/events" target="_blank">event</a>.

With the `Upload` component, you would choose what metadata to pass to the endpoint and implement the logic there (see the `OnUpload` <a href="https://docs.telerik.com/blazor-ui/components/upload/events" target="_blank">event</a>).

In either case, you may want to also update the grid data source to "know" about the associated files. Typically, you would have the file upload in <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/overview" target="_blank">edit mode of the grid</a> and that will make things easier (see <a href="https://docs.telerik.com/blazor-ui/components/grid/templates/editor" target="_blank">grid editor template</a>). In this example, such persistence is not implemented for the sake of brevity.

This approach (using lambda expressions to pass additional data from the current context) is suitable for other scenarios as well - such as editing a record in a treelist, listview or other data bound component, or for other situations where you may need the specific item from a repeated list.

This sample is a `server-side` Blazor project where a `FileSelect` component is straightforward to use. In a `WebAssembly` app, you may want to consider the Telerik `Upload` as your first choice, because it sends the file directly to your server endpoint, which you would otherwise have to implement on your own with a File Select type of component.