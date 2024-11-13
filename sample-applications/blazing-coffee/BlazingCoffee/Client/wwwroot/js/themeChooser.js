window.themeChooser = {
    themeVersion: "7.0.0",
    themeList: [
        { themeValue: "default-ocean-blue", mainTheme:"default", isSwatch: true },
        { themeValue: "default", mainTheme: "default", isSwatch: false },
        { themeValue: "bootstrap", mainTheme: "bootrstrap", isSwatch: false },
        { themeValue: "material", mainTheme: "material", isSwatch: false },
    ],
    defaultTheme: { themeValue: "default-ocean-blue", mainTheme: "default", isSwatch: true },
    getTheme: function () {
        let themeSetting = JSON.parse(window.localStorage.getItem('ThemeSetting')) || {};
        return themeSetting;
    },
    setTheme: function (theme) {
        let isValidTheme = this.themeList.filter(t => t.themeValue == theme.themeValue).length;
        if (!isValidTheme) {
            theme = this.defaultTheme;
        }

        window.localStorage['ThemeSetting'] = JSON.stringify(theme);
        this.changeTheme(theme);
    },
    changeTheme: function (theme) {
        // Build the new css link
        let oldLink = document.getElementById("theme");
        let cdnParts = ["https://blazor.cdn.telerik.com/blazor/", this.themeVersion, "/kendo-theme-"];

        if (theme.isSwatch) {
            cdnParts.push(`${theme.mainTheme}/swatches/${theme.themeValue}.css`);
        } else {
            cdnParts.push(`${theme.themeValue || this.defaultTheme}/all.css`);
        }
        
        let head = document.getElementsByTagName("head")[0];
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", cdnParts.join(""));

        // Wait for new styles to load and only then remove the only ones
        newLink.onload = () => {
            head.querySelector("#theme").remove();

            // Components such as the chart and the scheduler need
            // to be re-rendered in order to show the new theme colors
            var componentElements = document.querySelectorAll([
                ".k-chart",
                ".k-scheduler-layout",
                ".k-gauge"
            ].join(","));

            var instances = TelerikBlazor._instances;

            for (var i = 0; i < componentElements.length; i++) {
                var id = componentElements[i].getAttribute("data-id");
                var instance = instances[id];

                if (instance && instance.refresh) {
                    instance.refresh();
                }
            }
        };

        head.appendChild(newLink);
    },
    init: function () {
        let themeSetting = this.getTheme() || this.defaultTheme;
        this.setTheme(themeSetting);
    }
}
