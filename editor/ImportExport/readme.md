# Editor Import and Export

The [Blazor Editor component](https://docs.telerik.com/blazor-ui/components/editor/overview) works with HTML `string` content. The [Telerik Document Processing tools](https://docs.telerik.com/blazor-ui/components/document-processing/overview) that come with your Blazor license let you convert, import and export different formats, such as DOCX, HTML, PDF, RTF, TXT.

This sample project shows how to:

* [Import](#import) - Convert a DOCX file to an HTML string and render it in the Editor.
* [Export](#export) - Convert the HTML from the Editor to a selected document format, and download the generated file.

The sample also [increases the max SignalR message size](https://docs.telerik.com/blazor-ui/components/editor/overview#large-content-support) in `Startup.cs`.

## Import

The conversion happens in the `GetHtmlString` method in `FileConverter.cs`.

The sample reads a DOCX file from the `wwwroot` folder, but you can enhance it to let users upload a file, or import other formats.

A key point is that the Editor needs only the `<body>` of the imported HTML content. Make sure to remove the `<html>` and `<head>` elements, and only provide the contents of the `<body>` without the tag itself. In this sample, the conversion is done as a `Fragment` export level, which keeps only the body and adds inline styles - this is a feature of Telerik Document Processing. If you use the full page export, by default styles go into a separate `<style>` tag and you should consider either including that (it might affect the rest of the page), or using inline styles in the export settings.

The `ReadFile` helper function shows how to handle various formats and create appropriate providers for them to import.

Once the HTML string is prepared, we pass as the Editor `Value`.

## Export

The export happens in the `ExportAndDownloadHtmlContent` method in `FileConverter.cs`.

1. It creates the in-memory document with the HTML.
1. It checks what provider to use based on the file exetension.
1. It adds an image converter that will convert any non-JPG images to JPG. Otherwise the exporting will fail with an exception.
1. It sends the file to the browser for download with the help of `FileDownloader.cs` and a JavaScript function in `fileDownloader.js`.

You can extend this implementation to save the exported file on the server.

The export is triggered by a [custom Editor tool](https://docs.telerik.com/blazor-ui/components/editor/custom-tools) that is placed at the beginning of the Editor toolbar. You can invoke the export in any way you prefer from the view, for example, a button outside the Editor or other event.

## WebAssembly Support

Blazor WebAssembly apps require a few additional NuGet packages and a workload to be installed:

* NuGet package `SkiaSharp.NativeAssets.WebAssembly`
* NuGet package `SkiaSharp.Views.Blazor`
* [Workload `wasm-tools`](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=linux-macos#net-webassembly-build-tools) for the correct .NET version

In addition, the [Document Processing tool does not support exporting of image URLs in WebAssembly apps](https://feedback.telerik.com/document-processing/1551306-wordsprocessing-htmlformatprovider-platformnotsupportedexception-thrown-when-trying-to-load-image-from-uri-in-blazor-wasm). For the time being, it can only export Base64 images in the Editor content.

Possible workarounds for non-base64 images are:

* Load the images manually and convert them to Base64 images before the exporting starts.
* Send the HTML markup with the images to a remote server, make the HTML-to-PDF conversion there, and then send the exported file back to the WebAssembly app for download.
