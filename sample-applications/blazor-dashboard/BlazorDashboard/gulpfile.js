const { kendoSassBuild } = require('@progress/kendo-theme-tasks');

function buildStyles(done) {
    kendoSassBuild({
        file: './sass/styles.scss',
        output: {
            path: './wwwroot/css',
            filename: '[name].css'
        },
        sassOptions: {
            minify: true
        }
    });

    done();
}

exports.sass = buildStyles;
