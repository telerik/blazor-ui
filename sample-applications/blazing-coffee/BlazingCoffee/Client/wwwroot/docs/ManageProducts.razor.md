﻿# Features you'll find here include

This demo showcases <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/overview" target="_blank">CRUD operations</a> using the Telerik Data Grid which rely on an EF context on the backend.
To simplify the codebase, an <a href="https://docs.telerik.com/blazor-ui/common-features/observable-data" target="_blank">ObservableCollection</a> is used maintain an updated UI.
A custom editor is used to display groups and allow file uploads.

## Telerik Grid

- <a href="https://docs.telerik.com/blazor-ui/components/grid/editing/overview" target="_blank">Full CRUD operations</a> persisted by EF
- <a href="https://docs.telerik.com/blazor-ui/components/grid/toolbar" target="_blank">Grid Tool Bar</a> with custom Toggle column command and Add Product
- <a href="https://docs.telerik.com/blazor-ui/components/grid/columns/visible" target="_blank">Column hide/show</a>
- <a href="https://docs.telerik.com/blazor-ui/components/grid/templates/column" target="_blank">Column Template</a> with images
- CRUD <a href="https://docs.telerik.com/blazor-ui/components/grid/columns/command" target="_blank">Command Columns</a>

### Editor Template / File Upload

- <a href="https://docs.telerik.com/blazor-ui/components/grid/templates/editor" target="_blank">Editor template</a> displays File Upload on Edit dialog only
- <a href="https://docs.telerik.com/blazor-ui/components/upload/overview" target="_blank">Telerik File Upload</a> from Edit function
- File Upload <a href="https://docs.telerik.com/blazor-ui/components/upload/validation" target="_blank">limits</a> DOCX / PDF
- Server will auto convert DOCX > PDF via <a href="https://docs.telerik.com/blazor-ui/components/document-processing/overview" target="_blank">Telerik Document Processing</a>
- Telerik File Upload demonstrates how to upload using authorization Bearer token using IAccessTokenProvider 