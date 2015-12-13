var gulp = require('gulp');
var nodemon = require('gulp-nodemon');
var  jshint = require('gulp-jshint');

gulp.task('default', function() {
  // place code for your default task here
});

gulp.task('develop', function () {
  nodemon({ script: 'app.js'
          , ext: 'html js'
          , ignore: ['ignored.js']})
    .on('restart', function () {
      console.log('restarted!')
    })
})

gulp.task('lint', function () {
  gulp.src('./*.js')
    .pipe(jshint())
})