window.themeChooser = {
    themeVersion: "14.1.0",
    themeList: [
        { themeValue: "default-ocean-blue", mainTheme:"default", isSwatch: true },
        { themeValue: "default", mainTheme: "default", isSwatch: false },
        { themeValue: "bootstrap", mainTheme: "bootstrap", isSwatch: false },
        { themeValue: "material", mainTheme: "material", isSwatch: false },
    ],
    defaultTheme: { themeValue: "default-ocean-blue", mainTheme: "default", isSwatch: true },
    getTheme: function () {
        let themeSetting = JSON.parse(window.localStorage.getItem('ThemeSetting')) || {};
        return themeSetting;
    },
    setTheme: function (theme) {
        let isThemeValid = this.themeList.filter(t => t.themeValue == theme.themeValue).length;
        if (!isThemeValid) {
            theme = this.defaultTheme;
        }

        window.localStorage['ThemeSetting'] = JSON.stringify(theme);
        this.changeTheme(theme);
    },
    changeTheme: function (theme) {
        // Build the new css link
        let oldLink = document.getElementById("theme");
        let themeUrlParts = ["https://unpkg.com/@progress/kendo-theme-", theme.mainTheme, "@", this.themeVersion, "/dist/"];

        if (theme.isSwatch) {
            themeUrlParts.push(`${theme.themeValue}.css`);
        } else {
            themeUrlParts.push("all.css");
        }
        
        let head = document.getElementsByTagName("head")[0];
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", themeUrlParts.join(""));

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
