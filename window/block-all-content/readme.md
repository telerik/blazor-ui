# Disable All Content with Telerik Window

When you add a `<TeleriKWindow>` component to your app, it fills up the browser viewport by default when it is maximized. Also, its modal feature can cover the content too.

If you want it to disable all the content in the app, you need to ensure that the app content fits in the viewport, though, especially for a maximized window.

This means that the application layout must:

* make the high-level elements (such as `html`, `body`, `.page`, `.main` in this example) fit the viewport height
* define the element that will have a lot of content and scrollbars (`.main` in this example)

This is usually achieved with rules similar to this (**note**: they will vary depending on your app and layout):

```
/* set all top-level elements in the layout to height 100% so they match the viewport */
html, body, .page, .main{
    height: 100%;
    min-height: 100%;
    max-height: 100%;
    overflow: hidden;
}

/* define where scrollbars can appear in the layout -
    in a child element whose actual height
    still matches the viewport*/
.main {
    overflow: auto;
}
```

In this sample project, there are two pages that define the same "tall" content, and one of them provides CSS rules that fit the content to the viewport so the maximized window will block it. The other does not and you can scroll "below" the window.

In a real case you would probably include those CSS rules in your application stylesheet, they are in the component here to better showcase them and the difference in the results and behavior.