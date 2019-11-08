# Batch Editing

This example shows how you can implement behavior similar to batch editing available in other component suites (for example, in [Kendo UI](https://demos.telerik.com/kendo-ui/grid/editing)).

It relies on the [InCell edit mode](https://docs.telerik.com/blazor-ui/components/grid/editing/incell) and implements the batch operations by storing metadata in the models of the grid, as well as copies of the original data upon edit so that updates can be reverted. Through [selection](https://docs.telerik.com/blazor-ui/components/grid/selection/multiple), you can also revert or delete multiple rows at a time.

Other notes:

* The status indicator for available updates is in a separate column and not a small triangle per field. Having such a granular indicator would require implementing custom row templates with the desired appearance and extra code to compare which fields are changed.
* You can remove the entire command column if deleting through the selection and the toolbar is sufficient, and if you implement row insertion through a [custom form outside of the grid](https://demos.telerik.com/blazor-ui/grid/editing-custom-form). You could even move the status indicator to a template in the ID column and remove that column as well, to preserve real estate.

If this is not sufficient for your needs, let us know what features you would like to see in a built-in batch editing feature in our Feedback Portal: [https://feedback.telerik.com/blazor/1428492-batch-editing](https://feedback.telerik.com/blazor/1428492-batch-editing).
