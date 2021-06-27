import { Configuration } from 'webpack';
import { webpackTerserPlugin } from '../plugins/terser-webpack';
import { webpackOptimizeCssAssetsPlugin } from '../plugins/optimize-css-assets';

export const webpackOptimizationPart = (isProduction: boolean): Configuration['optimization']  => {
    return {
        minimizer: [
            webpackTerserPlugin(),
            webpackOptimizeCssAssetsPlugin(),
        ],
    };
};
