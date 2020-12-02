# Export Grid to PDF on the Server

This set of sample projects showcases how you can build a custom PDF export on the server for the current grid data.

The key concepts are:

* A shared project is responsible for generating the PDF file through the Telerik Document Processing libraries based on provided data and grid state.
* This project returns the file for both the server and WebAssembly flavors (for the WASM case, this is a performance improvement because such operations are slow in the browser at this point mostly due to the lack of multithreading and AoT, and because exporting all the data would be a serious performance hit for serialization).
* You can choose which Blazor project to run by marking it as a Startup project.
* The current grid filters and paging are obtained through the OnRead event and sent to the server for processing and generation.
* The currently shown columns are also taken from the grid state and sent for processing. You can choose whether to do that (skipping it will simplify the code but you will then probably generate all fields from the model in all cases which may not be what the user expects, but in some cases it may serve your needs).