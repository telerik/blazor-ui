# Add Item to MultiSelect

Generally, a multiselect or combo box widgets allows the user to select a predefined options and if you want to allow them to add more options, a more robust data editing component should be used (such as a grid or listview).

Nevertheless, it is possible to hack the component to:

* show an "Add" button if the data does not contain a match for the current input
* update the data source, current `Data` and `Value` through a few hacks in that button click and the `OnRead` handler

This example showcases one way you could do this. The component with the multiselect is in the `Shared` folder, and comments in the code offer more insights into the implementation.


