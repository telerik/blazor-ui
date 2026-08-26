window.themeChooser = {
    themeVersion: "14.5.0",
    themeList: [
        { themeValue: "meridian-main", mainTheme: "meridian", isSwatch: true },
    ],
    defaultTheme: { themeValue: "meridian-main", mainTheme: "meridian", isSwatch: true },
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
        let oldLink = document.getElementById("theme");
        let head = document.getElementsByTagName("head")[0];
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", `https://blazor.cdn.telerik.com/blazor/${this.themeVersion}/kendo-theme-meridian/all.css`);

        // Wait for new styles to load and only then remove the only ones
        newLink.onload = () => {
            oldLink.remove();

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

        head.insertBefore(newLink, oldLink);
    },
    init: function () {
        let themeSetting = this.getTheme() || this.defaultTheme;
        this.setTheme(themeSetting);
    }
}
