const { kendoSassBuild } = require('@progress/kendo-theme-tasks');

function buildStyles(done) {
    var themes = ['./Theme/main.scss', './Theme/main-dark.scss'];

    themes.forEach((themeFile) => {
        kendoSassBuild({
            file: themeFile,
            output: {
                path: './wwwroot/css',
                filename: '[name].css'
            },
            sassOptions: {
                minify: true
            }
        });
    });

    done();
}

exports.sass = buildStyles;
