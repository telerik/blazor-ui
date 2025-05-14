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
        let shouldAddComponent = true;

        viewPortResizeObserver.dotNetRefs.forEach(x => {
            if (x._id == dotNetRef._id) {
                shouldAddComponent = false;
            }
        });

        if (shouldAddComponent) {
            viewPortResizeObserver.dotNetRefs.push(dotNetRef);
        }
    },

    notifyServer: function(e) {
        clearTimeout(viewPortResizeObserver.timeoutId);

        viewPortResizeObserver.timeoutId = window.setTimeout(function() {
            viewPortResizeObserver.dotNetRefs.forEach(dotNetRef => {
                dotNetRef.invokeMethodAsync(viewPortResizeObserver.serverMethodName);
            });
        }, viewPortResizeObserver.resizeDebounceDelay);
    },

    removeComponent: function(dotNetRef) {
        viewPortResizeObserver.dotNetRefs = viewPortResizeObserver.dotNetRefs.filter(x => {
            return x._id != dotNetRef._id;
        });
    },

    destroy() {
        window.removeEventListener("resize", viewPortResizeObserver.notifyServer);
    }
};

document.addEventListener("DOMContentLoaded", viewPortResizeObserver.init);
