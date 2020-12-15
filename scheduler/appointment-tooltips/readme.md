# Appointment Tooltips

By default, the <a href="https://docs.telerik.com/blazor-ui/components/scheduler/overview" target="_blank">Blazor Scheduler</a> puts the appointment title in a tooltip. Sometimes you may want to customize that, and/or add more content and details in a tooltip.

You can do that by using the <a href="https://docs.telerik.com/blazor-ui/components/scheduler/templates/appointment" target="_blank">appointment templates</a> and the <a href="https://docs.telerik.com/blazor-ui/components/tooltip/overview" target="_blank">Blazor Tooltip component</a>.

This sample project shows one way to implement this. Key points:

* The model and service only showcase the basic concept, tweak them as necessary.
* The appointment templates use a component in the `~/Shared` folder that holds the rendering with the desired styling for each appointment, and the tooltip for it.
* The tooltip loads data on demand based on the appointment ID it receives from the scheduler template. In this example it just fetches the appointment from the service and you could pass it as a `Parameter` instead, but this example showcase loading data on demand when the tooltip shows. This is implemented through a component for its content that is also in the `~/Shared` folder.