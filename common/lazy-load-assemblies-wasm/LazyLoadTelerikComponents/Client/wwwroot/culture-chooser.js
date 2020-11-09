window.blazorCulture = {
    get: () => {
        return window.localStorage['BlazorCulture'];
    },

    set: (value) => {
        window.localStorage['BlazorCulture'] = value;
    }
};