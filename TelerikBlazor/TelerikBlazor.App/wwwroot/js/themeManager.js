window.theme = {
    changeCss: function (cssFile) {

        var oldlink = document.getElementById("kendoCss");

        var newlink = document.createElement("link");
        newlink.setAttribute("id", "kendoCss");
        newlink.setAttribute("rel", "stylesheet");
        newlink.setAttribute("type", "text/css");
        newlink.setAttribute("href", cssFile);

        document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    }
}