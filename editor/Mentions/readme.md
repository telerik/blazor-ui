# Editor Mentions

The [Blazor Editor component](https://docs.telerik.com/blazor-ui/components/editor/overview) uses the open source library - [ProseMirror](https://prosemirror.net/), that lets you create and customize structured documents with a WYSIWG interface. It allows users to define their own custom plugins that be hooked up to the editor, since the library is written in javascript, all of the existing plugins also are.

This sample project shows how to:

* Setup the [ProseMirror-Mentions](https://github.com/joelewis/prosemirror-mentions) plugin with a Telerik Blazor Editor.

Setup steps:
1. Go to `EditorMentions/NpmJs`
2. Run `npm ci`
3. Run `npm run build`
4. Run the Blazor application
5. Type `@e` to see the results

> [!NOTE]
> By default ProseMirror-Mentions comes without any styles, the ones you see in this demo can be found in the `wwwroot/css/site.css`