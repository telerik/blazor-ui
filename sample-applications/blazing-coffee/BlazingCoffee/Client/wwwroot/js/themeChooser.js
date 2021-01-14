window.themeChooser = {
    getTheme: function () {
        return window.localStorage['ThemeSetting'];
    },
    setTheme: function (themeName) {
        if (themeName === "auto") {
            window.localStorage.removeItem('ThemeSetting');
            this.autoDetectTheme();
        } else {
            window.localStorage['ThemeSetting'] = themeName;
            this.changeTheme(themeName);
        }
    },
    changeTheme: function (themeName) {
        // Build the new css link         
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", `css/${themeName}.css`);

        // Remove and replace the theme         
        let head = document.getElementsByTagName("head")[0];
        head.querySelector("#theme").remove();
        head.appendChild(newLink);
    },
    autoDetectTheme() {
        let isDark = window.matchMedia("(prefers-color-scheme: dark)").matches;

        if (isDark) {
            this.changeTheme("main-dark");
        } else {
            this.changeTheme("main");
        }
    },
    init: function () {
        let themeSetting = this.getTheme();
        let isThemeSet = !themeSetting;

        if (isThemeSet) {
            this.autoDetectTheme();
        }
        else {
            this.changeTheme(themeSetting);
        }
    }
}