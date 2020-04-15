# Uploaded Files and Form Validation

This example shows how you can use uploaded files as part of form model and have them participate in the form validation.

The framework does not have a built-in feature for validating uploaded files (https://github.com/dotnet/aspnetcore/issues/18821), so this is a workaround through the events and API the Telerik Upload component exposes.

The example shows how you can keep track of the files the user selectes and the server responses that confirm those files are OK in order to mark the form as valid. Actual server validation is not implemented in this example, the files are not even stored to the disk, but it shows the concept of ensuring the server has the file before allowing the user to submit.