# Two Drawers on the Same Site

This example shows how you can put two drawers on the same layout - a `Push` drawer and an `Overlay` drawer.

There are a few important things:

* The `Overlay` drawer must come first as it is absolutely positioned

* The `Push` drawer needs a z-index tweak so it does not show up above the modal overlay

* You may want to handle the selected items explicitly if you use both drawers for navigation. This is not implemented in this sample, it just showcases the drawers order and CSS rule.

* The Drawer component is designed to be a single instance on the layout.