const { kendoSassBuild } = require('@progress/kendo-theme-tasks');

function buildStyles(done) {
    kendoSassBuild({
        file: './sass/styles.scss',
        compiler: 'sass',
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
