window.resizeHelper = {
    _dotNetRef: null,
    _handler: null,

    addListener: function (dotNetRef) {
        this._dotNetRef = dotNetRef;
        var timeout;
        this._handler = function () {
            clearTimeout(timeout);
            timeout = setTimeout(function () {
                if (resizeHelper._dotNetRef) {
                    resizeHelper._dotNetRef.invokeMethodAsync('OnWindowResized');
                }
            }, 250);
        };
        window.addEventListener('resize', this._handler);
    },

    removeListener: function () {
        if (this._handler) {
            window.removeEventListener('resize', this._handler);
            this._handler = null;
        }
        this._dotNetRef = null;
    }
};
