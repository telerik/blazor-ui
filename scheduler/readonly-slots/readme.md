# Readonly Slots

This example showcases how you can set readonly slots for the scheduler, so the users will not be able to create or edit appointments in these slots.

The general way to do that is to:

* Create a method that will serve to check and validate if the provided appointment follows your desired rules. Get the currently edited/created appointment from the Item field the CRUD event arguments expose and pass it to that custom validation method.

* Create and toggle a flag to indicate whether the appointment is valid or not

* Based on that flag value, you can prevent creating or editing appointments in certain slots

* Add some custom CSS to visually mark the desired slots as disabled.