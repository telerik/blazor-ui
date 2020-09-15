# PDF and JPG Export in the Browser with JS

This sample project shows how you can us the Kendo Drawing API to export DOM elements to an image or a PDF ([Demo](https://demos.telerik.com/kendo-ui/pdf-export/index)).

In this example, we use it to export the currently rendered grid to a PDF or a JPG file.

Key points of interest:

* The LibMan package manager is used to fetch the needed JS dependencies (the Pako library, and the two needed Kendo libraries). The `Microsoft.Web.LibraryManager.Build` package restores them on build.

* There is a C# service that calls the surfaced JS interop by using an element reference - this is the DOM element that will be exported.

* The Base64 version of the files is passed through the C# Blazor code to showcase the steps clearly. You may want to refactor the code so only JS is used between the export and save operations so that you don't have to increase the SignalR message size, and reduce roundtrips.

