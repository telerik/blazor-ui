# Telerik Grid - Export To Excel (Hierarchy)

This project demonstrates how you can implement an export to excel functionality that supports [hierarchy][TelerikGridHierarchy].

## Description

For the time being, [Telerik Grid][TelerikGrid] doesn't contain a native export to excel funtionaly, that being said, it doesn't mean it cannot be done.
The following example demonstrates how such a functionality can be implemented using [SpreadStreamProcessing][SpreadStreamProcessing] library.

For this project [SpreadStreamProcessing][SpreadStreamProcessing] library was chosen over [SpreadProcessing][SpreadProcessing] for performance purposes, it has a limited API but much faster performance.
This can be especially useful for WASM scenarios where performance and memory management are still problematic in the framework. 

## Implementation

As shown in [`Index.razor.cs`][SourceCode_Index] you have to initialize an instance of [`ExportHelper`][SourceCode_ExportHelper] class and then call `ExportCurrentData()` method to export your data to excel.

This will generically detect your data model type (and its detail models) at run-time and generate columns, then dynamically fill in the rows from the provided datasource respectively. 

The project includes the following main methods: 
- `async Task ExportToExcel()`: Method used in [`Index.razor.cs`][SourceCode_Index] and is called to initiate the export functionality to excel/csv.
- `async Task<bool> ExportCurrentData()`: Method used in [`ExportHelper`][SourceCode_ExportHelper] that handles the functionality of creating and the downloading the created document.
- `byte[] GenerateDocument()`: Generates a document of type `byte[]` from the provided datasource.
- `async Task Save()`: Uses `JSRuntime` to call a JavaScript function named `saveFile` to download the document created.

### Thanks

This contribution was made by [Hüssam Elvani][Contributor].

   [TelerikGrid]: <https://docs.telerik.com/blazor-ui/components/grid/overview>
   [TelerikGridHierarchy]: <https://docs.telerik.com/blazor-ui/components/grid/hierarchy>
   [SpreadStreamProcessing]: <https://docs.telerik.com/devtools/document-processing/libraries/radspreadstreamprocessing/overview>
   [SpreadProcessing]: <https://docs.telerik.com/devtools/document-processing/libraries/radspreadprocessing/overview>
   [SourceCode_Index]: <https://github.com/telerik/blazor-ui/blob/master/grid/export-to-xlsx-hierarchy/Pages/Index.razor.cs>
   [SourceCode_ExportHelper]: <https://github.com/telerik/blazor-ui/blob/master/grid/export-to-xlsx-hierarchy/Helpers/ExportHelper.cs>
   [Contributor]: <http://github.com/hussamelvani>
