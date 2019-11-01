function raiseResizeEvent() {
    var namespace = 'ResponsiveChart'; // the namespace of the app, you will have to change this for your app
    var method = 'RaiseWindowResizeEvent'; //the name of the method in our "service"
    DotNet.invokeMethodAsync(namespace, method, window.innerWidth, window.innerHeight);
}

//throttle resize event, taken from https://stackoverflow.com/a/668185/812369
var TO = false;
window.addEventListener("resize", function () {
    if (TO !== false)
        clearTimeout(TO);
    TO = setTimeout(raiseResizeEvent, 200);
});