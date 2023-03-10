'use strict';

const webpack = require('webpack');
const path = require('path');

const bundleFolder = "./wwwroot/assets/";
const srcFolder = "./App/"

module.exports = {
    entry: [
        srcFolder + "index.jsx" // точку входа webpack в наши исходники
    ],
    // указание создания source-map, чтобы при отладке не лазить по огромному бандлу, а была привязка к исходникам
    devtool: "source-map", 
    // результат работы webpack'а
    output: { 
        filename: "bundle.js",
        publicPath: 'assets/',
        path: path.resolve(__dirname, bundleFolder)
    },
    // какие лоадеры нужно подключить
    module: {
        rules: [
            {
                test: /\.jsx$/,
                exclude: /(node_modules)/,
                loader: "babel-loader",
                query: {
                    presets: ["es2015", "stage-0", "react"]
                }
            }
        ]
    },
    plugins: [
    ]
};