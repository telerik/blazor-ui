# Import (Paste) from Excel

Sometimes, users want to paste content onto the grid instead of using the built-in abilities for creating new items. This sample project shows one way you could implement such ability for your app.

## Key Points

* At the time of writing, the Blazor `@onpaste` event does not provide the data that is pasted, so a JavaScript solution is needed.

* To get the pasted content, you either need a `contenteditable=true` element, or an `input`. Using an editable element will let the end user inadvertedly destroy the page by altering the HTML, so it is not an option. Thus, we need to use an input.

* To use an input to get pasted content, you need this input to be focused, which will take away focus from the grid. Since this is not suitable for a built-in option, it cannot be a part of the Telerik Grid feature set.

* Once you get the pasted content in the app, you need to parse that content and extract model instances so you can add them to your data source. This is specific to the model and the application and this sample showcases a very basic example of doing that.

