# Scheduler Create appointments from an ICS file

This example shows how to convert iCalendar appointment to a C# model and pass them to the Scheduler.

Key points of interest (comments in the code also offer some insights):

1. Setup a Scheduler
1. Create a model class with appropriate properties
1. Convert the dates to a suitable C# format
1. Use a service to read the ICS file and convert the data between BEGIN:VEVENT and END:VEVENT to the model
1. Pass the data to the Scheduler
