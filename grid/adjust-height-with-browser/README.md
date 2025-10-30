# Change page size according to available height; hide columns based on screen size

> This sample app is mostly obsolete and no longer maintained. The up-to-date Telerik documentation resources and examples are available at:
> * [Grid Adaptive Mode](https://demos.telerik.com/blazor-ui/grid/adaptive)
> * [Grid Adaptive Mode Stacked Columns](https://www.telerik.com/blazor-ui/documentation/components/grid/columns/stacked)
> * [Adjust Grid Height to Match the Browser Viewport Height](https://docs.telerik.com/blazor-ui/knowledge-base/grid-adjust-height-with-browser)
> * [Hide or Show Grid Columns on Browser Window Resize](https://docs.telerik.com/blazor-ui/components/mediaquery/integration)
> * [Scroll to Selected Grid Row](https://docs.telerik.com/blazor-ui/knowledge-base/grid-scroll-to-selected-row)
> * [Apply Custom Grid Row or Cell Styles](https://docs.telerik.com/blazor-ui/knowledge-base/grid-conditional-cell-background)
> * [Override the Telerik Theme](https://docs.telerik.com/blazor-ui/styling-and-themes/override-theme-styles)
>
> The one behavior that is not demonstrated on the Telerik documentation site is how to change the Grid `PageSize`, depending on the Grid height.

Demonstrates Responsive Grid, Finding and Selecting Row, Formatting

This project was created using the Telerik 'Blank Server Project' template and includes the 'BlazorPro.BlazorSize' NuGet package by Ed Charbeneau to access browser dimensions. It is meant to provide an example for how to address three common requirements for representing data using a grid for database applications.

## Responsive Grid
* This uses the BlazorSize package to detect the browser size
* Determine how many rows will fit within the available grid height (to eliminate or minimize vertical scroll bar)
* Uses media breakpoints to determine which columns should be displayed based upon the browser width. (Resize width of browser to see columns subtracted / added)

## Find and Select Row
* Demonstrates how to bind-Page select a page
* Uses java script to make sure row is visible on page

## Formatting
* Demonstrates how to change background colors and eliminate alternate row backgroud color
* Changes data alignment to top of row
* Conditionally Set font color for population based on data

Sample date provided by: https://simplemaps.com/data/world-cities

Most of what I have demonstrated here is thanks to the knowledge and patience of Marin Bratanov.

Sample project courtesy of [mdvandemore](https://github.com/mdvandemore)
