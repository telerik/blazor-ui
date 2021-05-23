# Showing a Popup Causes the Page to Scroll to Top


The behavior stems from the place of rendering of the popup in the DOM, which element is scrollable, and
which element is focused. The Telerik popups have a default focus which is essential for accessibility and UX
and browsers try to `scrollIntoView()` the focused element. That focused element is now in the popup
and the browser does not correctly estimate where and what to scroll, and does not take into account the
`position: absolute` that the popup has, so it usually scrolls to the top of the content.

The solution is to control what can be scrolled and to ensure that the parent elements of the popups match the browser viewport
and also match the scrollable container. In this layout, the `.content` element is the container that should get
scrollbars because it holds the actual app content. So, with a bit of CSS we can make all its parent elements match the viewport
size and height, so that the browser will not scroll when an absolutely positioned element gets focus.


This means that the application layout must usually:

* make the high-level elements (such as `html`, `body`, `#app`, `.page`, `.main` in this example) fit the viewport height
* define the element that will have a lot of content and scrollbars (`.content` in this example)

This is usually achieved with rules similar to this (**note**: they will vary depending on your app and layout):

```css
/* set all top-level elements in the layout to height 100% so they match the viewport */
html, body, #app, .page, .main {
    /* the two key rules to define dimensions and ensure scrollbars are not in a high level */
    height: 100%;
    overflow: hidden;
    /* these two rules are a common safeguard to better tighten dimensions, they may not be needed for your case */
    min-height: 100%;
    max-height: 100%;
}
/* define where scrollbars can appear in the layout - in a child element whose actual height
    still matches the viewport*/
.content {
    /* allow scrolling of the actual app content */
    overflow: auto;
    /* height is not 100% in this layout beause it uses flex and has a header inside 
    so we use calc() to account for the header and we take its size from the app stylesheet */
    height: calc(100% - 3.5rem);
}
```

In this sample project, there are two pages that define the same "tall" content, and one of them (`Fix.razor`) provides CSS rules that fit the content to the viewport so the scrolling behavior does not manifest.

In a real case you would probably include those CSS rules in your application stylesheet, they are in the component here to better showcase them and the difference in the results and behavior.