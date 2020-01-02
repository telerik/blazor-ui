function raiseResizeEvent() {
    var namespace = 'ResponsiveChart'; // the namespace of the app, you will have to change this for your app
    var method = 'RaiseWindowResizeEvent'; //the name of the method in our "service"
    DotNet.invokeMethodAsync(namespace, method, Math.floor(window.innerWidth), Math.floor(window.innerHeight));
}

//throttle resize event, taken from https://stackoverflow.com/a/668185/812369
var timeout = false;
window.addEventListener("resize", function () {
    if (timeout !== false)
        clearTimeout(timeout);
    timeout = setTimeout(raiseResizeEvent, 200);
});
