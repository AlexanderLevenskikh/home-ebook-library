import OptimizeCSSAssetsPlugin from 'optimize-css-assets-webpack-plugin';

export const webpackOptimizeCssAssetsPlugin = () => {
    return new OptimizeCSSAssetsPlugin({ });
}
