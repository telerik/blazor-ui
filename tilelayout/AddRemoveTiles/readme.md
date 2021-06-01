# Add and Remove Tiles

This example project demonstrates a simple customizable dashboard which uses TileLayout component and allows adding and removing tiles from a collection to display the desired set of data in the main section.

The layout of the index page uses TelerikSplitter to divide the main data section and a side pane that displays the available data tiles that can be added to the dashboard.

The content for the tiles is defined as separate components in the Components/Tiles folder. `TileContentFactory.razor` is handling for the conditional rendering of the content in the tiles based on the information retrieved from the `TilesDataService.cs`.

At the time of writing a `Visible` parameter is not included in the TileLayout state. Therefore the component uses a bool field `Visible` in the tiles model to handle the conditional rendering of the tiles depending on its value. With that being said, as the tiles collection reference changes in the process, the component state cannot maintain data for the removed items and thus when they are re-added, they appear at the last position.

A configuration of adding and removing tiles whilst keeping their initial position through the state will be possible once this feature request in the public portal is available - [Command buttons in the tile header that work with draggable and provide built-in close and minimize](https://feedback.telerik.com/blazor/1506097-command-buttons-in-the-tile-header-that-work-with-draggable-and-provide-built-in-close-and-minimize).
