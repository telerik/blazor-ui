const gulp = require('gulp');
const sass = require('gulp-sass')(require('node-sass'));
const postcss = require("gulp-postcss");
const autoprefixer = require("autoprefixer");
const calc = require("postcss-calc");

const sassOptions = {
    precision: 10,
    outputStyle: 'compressed'
};

const postcssOptions = [
    calc({
        precision: 10
    }),
    autoprefixer({
        overrideBrowserslist: [ '> 10%' ]
    })
];

gulp.task('sass', function () {
    return gulp.src('./Theme/*.scss')
        .pipe(sass.sync(sassOptions).on('error', sass.logError))
        .pipe(postcss(postcssOptions))
        .pipe(gulp.dest('./wwwroot/css'));
});
