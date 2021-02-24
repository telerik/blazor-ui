# Custom PopUp Editing Form in the Telerik Grid

This example shows how you can implement a custom popup editor with an entirely custom template and layout.

The built-in [popup editing](https://docs.telerik.com/blazor-ui/components/grid/editing/popup) supports [editor templates](https://docs.telerik.com/blazor-ui/components/grid/templates#edit-template) for the given field, but it does not provide full flexibility on the layout.

This example provides two pages:

* `Index.razor` adds all the code in one places so it is easy to review. It uses the `Telerik Form` component to provide the actual editing and validation.
* `SeparateComponent.razor` uses the `Shared/CustomEditForm.razor` to provide the custom editing so that it can abstract away the UI part of it. It uses the standard `EditForm`.