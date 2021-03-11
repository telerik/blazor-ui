# InCell Editing - Template with Focus and Select, Tab and Enter

This example shows one approach you can use to get behavior in your <a href="https://docs.telerik.com/blazor-ui/components/grid/templates/editor" target="_blank">editor templates</a> with the <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/incell" target="_blank">incell edit mode</a> that the grid provides out-of-the-box without them (see the <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/incell#noteshttps://docs.telerik.com/blazor-ui/components/grid/editing/incell#notes" target="_blank">notes section</a>):
* focus the input in the custom editor when the cell is opened
* highlight the text of the custom editor when the cell is opened

It also shows how you can <a href="https://docs.telerik.com/blazor-ui/knowledge-base/inputs-handle-keyboard-events" target="_blank">handle keyboard events</a> for the inputs and, for example, trap `Enter` and `Tab` keys. This is used to fire the `OnUpdate` operation when the user presses `Tab` in the custom editor.

The code that provides that functionality is in  `~/Shared/FocusHandler.razor` - this is a simple component that wraps the custom editor template and uses a little bit of JavaScript (in `wwwroot/js/focusHandler.js`) to focus and select the content in the first input it finds. We call this script when the component initializes (the `OnAfterRenderAsync event`), which happens when the cell is opened for editing.

Handling the `Enter` and `Tab` keys is done with C# alone in this component and that raises an event in the component with the grid where we can choose to fire the update logic.

An "anonymous" render fragment lets this component be "transparent" for the actual editor - you can keep the custom editors in the grid declaration to make it easier to tie them to the data in the context.

>Idea, concept, and core code created by Jaco Jordaan