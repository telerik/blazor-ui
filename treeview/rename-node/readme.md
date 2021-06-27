# Rename TreeView Node

Tree TreeView component is a data visualization component, and it does not provide editing capabilities out-of-the-box. If your users need to perform CRUD operations a lot, you may want to consider using <a href="https://demos.telerik.com/blazor-ui/treelist/editing-inline" target="_blank">the TreeList component that offers built-in editing</a> (in fact, it offers three different edit modes and UX).

If you want to add editing capabilities to your treeview, the most straight forward way to implement them is to:

1. Create a component that will provide the desired item rendering and editing UX.
    * In this sample, it is the `~/Shared/EditableTreeNode.razor` component.
1. Put that component in the <a href="https://docs.telerik.com/blazor-ui/components/treeview/templates" target="_blank">`ItemTemplate`</a> of your treeview.
1. Pass to that component the current item that it will render and edit.
    * We pass it as a parameter to the child component.
1. Raise an event after an item was edited so the parent treeview can re-render if/as necessary.
    * In this sample we fetch the data from the mock database every time to ensure it is fresh and we get other people's edits. In your case you can choose when and how to make updates.