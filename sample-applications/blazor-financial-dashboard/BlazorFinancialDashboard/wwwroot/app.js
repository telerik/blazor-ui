viewPortResizeObserver = {
    serverMethodName: "OnViewPortResize",

    dotNetRefs: [],

    timeOutId: null,

    resizeDebounceDelay: 300,

    init: function() {
        window.addEventListener("resize", viewPortResizeObserver.notifyServer);
        window.addEventListener("unload", viewPortResizeObserver.destroy);
    },

    addComponent: function(dotNetRef) {
        if (viewPortResizeObserver.dotNetRefs.indexOf(dotNetRef) < 0) {
            viewPortResizeObserver.dotNetRefs.push(dotNetRef);
        }
    },

    notifyServer: function(e) {
        clearTimeout(viewPortResizeObserver.timeoutId);

        viewPortResizeObserver.timeoutId = window.setTimeout(function() {
            viewPortResizeObserver.dotNetRefs.forEach((dotNetRef) => {
                dotNetRef.invokeMethodAsync(viewPortResizeObserver.serverMethodName);
            });
        }, viewPortResizeObserver.resizeDebounceDelay);
    },

    removeComponent: function(dotNetRef) {
        let idx = viewPortResizeObserver.dotNetRefs.indexOf(dotNetRef);

        if (idx >= 0) {
            viewPortResizeObserver.dotNetRefs.splice(idx, 1);
        }
    },

    destroy() {
        window.removeEventListener("resize", viewPortResizeObserver.notifyServer);
    }
};

document.addEventListener("DOMContentLoaded", viewPortResizeObserver.init);
