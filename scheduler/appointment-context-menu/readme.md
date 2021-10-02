# Appointment Context Menu

The scheduler lets you <a href="https://demos.telerik.com/blazor-ui/scheduler/appointment-editing" target="_blank">edit appointments</a> by double clicking them, it provides resize handles and lets you drag them to change them, and offers a [x] button to delete them.

In addition to that interactivity, you may want to add a context menu to the appointments to provide shortcuts or other custom features specific to your application (such as assigning resources, or other common actions that your users repeat often).

To use a context menu for the appointments:

1. Add the desired <a href="https://demos.telerik.com/blazor-ui/contextmenu/overview" target="_blank">context menu</a> to the page. Create its items, commands and actions as needed.

1. Use the <a href="https://docs.telerik.com/blazor-ui/components/scheduler/templates/appointment" target="_blank">appointment template</a> of the scheduler to <a href="https://docs.telerik.com/blazor-ui/components/contextmenu/integration" target="_blank">integrate the context menu</a> with them.

In this sample project we provide a Delete shortcut and a way to toggle a custom field in the appointment model.

>Tip: As of 2.27.0 there is a built-in event you can use so you do not have to use templates, you can read more about it here: [Scheduler OnItemContextMenu Event](https://docs.telerik.com/blazor-ui/components/scheduler/events#onitemcontextmenu)
