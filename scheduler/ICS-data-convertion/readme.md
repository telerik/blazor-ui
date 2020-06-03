# Scheduler Create appointments from an ICS file

This example shows one way to convert iCalendar appointment to a C# model and pass them to the Scheduler.

Key points of interest (comments in the code also offer some insights):

1. Setup a <a href="https://docs.telerik.com/blazor-ui/components/scheduler/overview" target="_blank">Scheduler</a>
1. Create an appointment model class with the appropriate fields (see <a href="https://docs.telerik.com/blazor-ui/components/scheduler/data-bind" target="_blank">here</a>)
1. Use a service to read the ICS file and convert the data between `BEGIN:VEVENT` and `END:VEVENT` to the model
    1. Parse the ICS format strings to extract the data so you can populate it in the appointment model
    1. Convert the dates to a suitable C# format
1. Pass the data to the Scheduler
