# Editor Import and Export

The [Blazor Editor component](https://docs.telerik.com/blazor-ui/components/editor/overview) works with a string content. The [Telerik Document Processing tools](https://docs.telerik.com/blazor-ui/common-features/document-processing) that come with your Blazor license let you easily convert (export) that to other formats (such as PDF and DOCX), and/or obtain an HTML string from other files (such as DOCX).

This sample project shows how to:

* Convert a .docx file to an HTML string and put it in the editor
* Convert the HTML from the editor to a PDF and download it

You can also extend it to use other formats.

The sample also increases the SignalR maximum message size in `Startup.cs` to allow for file downloads, and to let large content travel to the browser (such as the editor content, e.g., when you click the View HTML button).

## DOCX Import

The conversion happens in the `FileConverter.cs` file - the `GetHtmlString` method.

In this sample, it reads a `docx` file in the `wwwroot` folder, but you can develop it further to let the user upload a file before reading it, and to use other formats (such as RTF).

A key point is that the Editor needs only the body of the content - full HTML cannot be edited, so you must make sure to remove the `html`, `head` elements, and to only provide the contents of the `body` tag without the tag itself. In this sample, the conversion is done as a `Fragment` export level, which keeps only the body and adds inline styles. If you use the full page export, by default styles go into a separate `<style>` tag and you should consider either including that, or using inline styles in the export settings.

The `ReadFile` helper function shows a sample way of tackling various formats and creating appropriate providers for them to import.

Once the HTML string is prepared, we simply return it in the view-model and pass it to the editor `Value`.

## PDF Export

The PDF export is done in the in the `FileConverter.cs` file - the `ExportHtmlFileToPdf` method.

First, it creates the PDF file, and then with the use of a helper class (`FileDownloader.cs`) and a JavaScript function (in `fileDownloader.js`), it downloads that content in the browser.

You can extend this further to export to more formats (make sure to use the proper MIME type if you download them), and/or save those files on the server.

The export is triggered by a [custom tool](https://docs.telerik.com/blazor-ui/components/editor/custom-tool) that is placed at the beginning of the editor toolbar, you can invoke it in any way you prefer from the view.