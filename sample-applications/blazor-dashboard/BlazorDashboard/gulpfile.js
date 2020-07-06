/// <binding BeforeBuild='sass, minify-css' />
'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var cleanCSS = require('gulp-clean-css');

gulp.task('sass', function () {
	return gulp.src('./sass/**/*.scss')
		.pipe(sass().on('error', sass.logError))
		.pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('minify-css', () => {
	return gulp.src('./wwwroot/css/styles.css')
		.pipe(cleanCSS())
		.pipe(gulp.dest('./wwwroot/css'));
});