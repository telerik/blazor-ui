const { kendoSassBuild } = require('@progress/kendo-theme-tasks/src/build/kendo-build');
const sass = require('sass');

function buildStyles(done) {
    kendoSassBuild({
        file: './sass/styles.scss',
        output: {
            path: './wwwroot/css'
        },
        sassOptions: {
            implementation: sass,
            outputStyle: 'compressed',
            quietDeps: true
        }
    });

    done();
}

exports.sass = buildStyles;