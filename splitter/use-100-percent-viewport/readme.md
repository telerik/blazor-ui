# How to make Splitter take 100% height of the viewport

When creating layouts with the Splitter, it is a common requirement that they take up 100% of the available height.

To accomplish this, simply set the Splitter's `Height` parameter to `100%`.

It is important to note that this relies on the standard CSS behavior of setting height in percent - all parent elements must have a `height` set, so that the content size can be calculated based off the viewport.

This example shows a basic layout with the splitter that has:
* header
* footer
* sidebar

where 
* the header and footer have static dimensions
* the whole layout takes up 100% height and width of the viewport
* the content (`@Body`) takes 100% height and width of the remaining space after the header, footer and sidebar are rendered

This is accomplished by:
* setting `Width` and `Height` to `100%` for the splitters;
* adding `height:100%` styles to the splitter parents (`html` and `body` in this example) in the app stylesheet.

The code is in `~Shared/MainLayout.razor`. Comments in the code offer some more details.