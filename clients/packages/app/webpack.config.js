const webpackConfig = require('@workshop/webpack');
const { merge } = require('webpack-merge');

module.exports = merge(webpackConfig, {
  entry: './src/index.tsx',
  devServer: {
    port: '5704',
  },
});
