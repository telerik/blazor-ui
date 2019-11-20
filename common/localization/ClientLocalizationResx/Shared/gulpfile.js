/// <binding BeforeBuild='generate-resources' ProjectOpened='generate-resources' />
var gulp = require('gulp');
var resxConverter = require("gulp-resx-convert");

gulp.task('generate-resources', () => {
    return gulp.src(["./ResxSource/*.resx"])
        .pipe(resxConverter.convert({
            csharp: {
                //Sets the namespace to be used - used for Reflection, matches the project namespace in this case
                namespace: "ClientLocalizationResx.Shared.Translations",
                //Output as properties or constants. Setting this to true will use properties
                properties: true,
                //Set this to true to create a partial class
                partial: false
            },
            //Uncomment this to generate JSON files - they may be easier to parse to a Dictionary, for example
            //json: {}
        }))
        .pipe(gulp.dest("./Translations"));
});