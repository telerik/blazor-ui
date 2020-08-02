# Editor Import and Export

The [Blazor Editor component](https://docs.telerik.com/blazor-ui/components/editor/overview) works with a string content. The [Telerik Document Processing tools](https://docs.telerik.com/blazor-ui/common-features/document-processing) that come with your Blazor license let you easily convert (export) that to other formats (such as PDF and DOCX), and/or obtain an HTML string from other files (such as DOCX).

This sample project shows how to:

* [Import](#import) - Convert a .docx file to an HTML string and put it in the editor (can also work with some other formats).
* [Export](#export) - Convert the HTML from the editor to a PDF and other formats and download it.

You can also extend it to use other formats.

The sample also increases the SignalR maximum message size in `Startup.cs` to allow for file downloads, and to let large content travel to the browser (such as the editor content, e.g., when you click the View HTML button, or the files themselves).

## Import

The conversion happens in the `FileConverter.cs` file - the `GetHtmlString` method.

In this sample, it reads a `docx` file in the `wwwroot` folder, but you can develop it further to let the user upload a file before reading it, and to use other formats (such as RTF).

A key point is that the Editor needs only the body of the content - full HTML cannot be edited, so you must make sure to remove the `html`, `head` elements, and to only provide the contents of the `body` tag without the tag itself. In this sample, the conversion is done as a `Fragment` export level, which keeps only the body and adds inline styles - this is a feature of the Telerik DPL. If you use the full page export, by default styles go into a separate `<style>` tag and you should consider either including that (it might affect the rest of the page), or using inline styles in the export settings.

The `ReadFile` helper function shows a sample way of tackling various formats and creating appropriate providers for them to import.

Once the HTML string is prepared, we simply return it in the view-model and pass it to the editor `Value`.

## Export

The export is done in the in the `FileConverter.cs` file - the `ExportAndDownloadHtmlContent` method.

First, it creates the in-memory document with the HTML that we need for the conversion, then checks what provider to use based on the file exetension, and then - with the use of a helper class (`FileDownloader.cs`) and a JavaScript function (in `fileDownloader.js`) - it downloads that content in the browser.

This also shows how to export to more formats (make sure to use the proper MIME type if you download them, also available in this sample), you can also extens it to save those files on the server.

The export is triggered by a [custom tool](https://docs.telerik.com/blazor-ui/components/editor/custom-tool) that is placed at the beginning of the editor toolbar, you can invoke it in any way you prefer from the view (e.g., buttons outside of the editor or other events).