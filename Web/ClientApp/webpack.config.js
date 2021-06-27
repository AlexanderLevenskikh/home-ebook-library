// fake webpack config used only to help make Webstorm resolve imported .less files
var path = require('path');
var webpack = require('webpack');

module.exports = {
    // Directory resolution fix
    resolve: {
        alias: {
            root: path.resolve(__dirname, './src'),
        },
    },
};
