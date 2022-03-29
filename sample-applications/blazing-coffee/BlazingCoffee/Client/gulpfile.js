const { kendoSassBuild } = require('@progress/kendo-theme-tasks/src/build/kendo-build');
const sass = require('sass');

function buildStyles(done) {
    var themes = ['./Theme/main.scss', './Theme/main-dark.scss'];

    themes.forEach((path) => {
        kendoSassBuild({
            file: path,
            output: {
                path: './wwwroot/css'
            },
            sassOptions: {
                implementation: sass,
                outputStyle: 'compressed',
                quietDeps: true
            }
        });
    })

    done();
}

exports.sass = buildStyles;