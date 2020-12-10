# Import (Paste) from Excel

Sometimes, users want to paste content onto the grid instead of using the built-in abilities for creating new items. This sample project shows one way you could implement such ability for your app.

## Key Points

* At the time of writing, the Blazor `@onpaste` event does not provide the data that is pasted, so a JavaScript solution is needed.

* To get the pasted content, you either need a `contenteditable=true` element, or an `input`. Using an editable element will let the end user inadvertently destroy the page by altering the HTML, so it is not an option. Thus, we need to use an input.

* To use an input to get pasted content, you need this input to be focused, which will take away focus from the grid. Since this is not suitable for a built-in option, it cannot be a part of the Telerik Grid feature set.

* Once you get the pasted content in the app, you need to parse that content and extract model instances so you can add them to your data source. This is specific to the model and the application and this sample showcases a very basic example of doing that.
    * You may want to implement a method in the models that you wish to paste from Excel that will receive the pasted row as a string and "deserialize" it intelligently (for example, trap parsing errors and skip fields instead of failing to insantiate, attempt parsing against several fields or a different order of the fields).

## UX Issues

To get the pasted info, you need the focus to be on an input. This removes the ability to keep an input/element in the grid focused. This will prevent the following grid features from working:

* Editing
* Keyboard navigation
* Filter Row
* Text selection
* Maybe others that rely on elements being focused


These issues mean that such a pasting feature cannot be a built-in feature in the component. You should review if the trade-off is worth it for your use case.

## Alternative Ideas

If you need to let your users take data from Excel and add it to the grid, you can consider the following alternatives that will not harm the grid UX:

* Allow your users to upload the Excel or CSV file, use tools like the <a href="https://docs.telerik.com/devtools/document-processing/introduction" target="_blank">Telerik Document Processing Libraries</a> to read and parse the data so you can add it to the data source of the grid.

* Add a button that triggers a popup with the textarea where the user can paste the Excel data so you can parse it and add it to the grid data source.

You can use the <a href="https://docs.telerik.com/blazor-ui/components/grid/toolbar" target="_blank">grid toolbar</a> to add either.
