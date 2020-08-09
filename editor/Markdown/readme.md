# Markdown Editor

The [Telerik Blazor Editor](https://demos.telerik.com/blazor-ui/editor/overview) provides HTML, and with the help of simple Markdown parser packages, you can get or set Markdown content in it.

This sample shows how to create a [custom tool](https://docs.telerik.com/blazor-ui/components/editor/custom-tool) that provides:

* A large text area to edit the raw markdown string
* One way to convert the HTML to Markdown so you can store it
* One way to convert the raw Markdown the user wrote to HTML and put it back in the editor so WYSIWYG editing experience can continue

> The conversions are shown in the custom tool, you can extend them to a service and use it as needed in custom tools, on the main editor page or in other code.

This sample uses the following packages to work with the Markdown content:

* [ReverseMarkdown](https://github.com/mysticmind/reversemarkdown-net) for HTML -> MD
* [MarkdownSharp](https://github.com/StackExchange/MarkdownSharp/) for MD -> HTML

> You can use any code and packages you prefer, as well as modify their settings (this sample uses the default).
