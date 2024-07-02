const mix = require('laravel-mix');

mix.js('./frontend/js/main.js', './wwwroot/js')
    .sass('./frontend/sass/main.scss', './wwwroot/css');