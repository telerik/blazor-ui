# Scheduler Custom Edit Form

This example shows how you can use a custom form (component) to edit appointments in the scheduler, instead of the built-in editor.

Key points of interest (comments in the code also offer some insights):

* You must cancel the `OnEdit` event to avoid the built-in form.
* You need to clone the appointment model to prevent user changes from immediately affecting the data collection.
* A title, start and end time are mandatory fields an appointment must have, and the end time must be after the start time. The custom editor must ensure this (example available in this project), together with the data service (such data integrity example is not implemented in this simple project).
* In this example, a Window is used to host the custom form, and the component with the scheduler needs to handle an EventCallback from the content in order to re-render the scheduler with the new data (see [here](https://docs.telerik.com/blazor-ui/knowledge-base/window-does-not-update-parent)).