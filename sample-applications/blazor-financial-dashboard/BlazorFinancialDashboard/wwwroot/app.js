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
        clearTimeout(viewPortResizeObserver.timeOutId);

        viewPortResizeObserver.timeOutId = window.setTimeout(function() {
            viewPortResizeObserver.dotNetRefs.slice().forEach(dotNetRef => {
                dotNetRef.invokeMethodAsync(viewPortResizeObserver.serverMethodName).catch(error => {
                    // Blazor can dispose a component while a debounced resize is pending.
                    if (String(error).includes("There is no tracked object with id")) {
                        viewPortResizeObserver.removeComponent(dotNetRef);
                        return;
                    }

                    console.error("Viewport resize notification failed.", error);
                });
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
        clearTimeout(viewPortResizeObserver.timeOutId);
        viewPortResizeObserver.dotNetRefs = [];
    }
};

document.addEventListener("DOMContentLoaded", viewPortResizeObserver.init);
