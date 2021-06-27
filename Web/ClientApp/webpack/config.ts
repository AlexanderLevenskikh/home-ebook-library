import path from 'path';
import webpack from 'webpack';
import { webpackContext } from './context';
import { webpackOptimizationPart } from './parts/optimization';
import { webpackPluginsPart } from './parts/plugins';
import { webpackRulesPart } from './parts/rules';
import { webpackDevServerPart } from './parts/devServer';

const IS_WDS = process.env.IS_WDS === 'true';
const IS_PROD_DEPS = process.env.IS_PROD_DEPS === 'true';
const IS_PROD_MODE = process.env.IS_PROD_MODE === 'true';

const webpackConfig = (): webpack.Configuration => {
    const publicPath = '/';

    const entryPoint = path.resolve('./src', 'index.tsx');

    const output = {
        publicPath,
        filename: IS_PROD_MODE ? '[name].[hash].js' : '[name].js',
        path: path.resolve(webpackContext, 'dist'),
    };

    const devtool = IS_PROD_MODE ? false : 'source-map';

    const babelConfigPath = path.resolve(webpackContext, 'babel.config.js');

    const resolve = {
        extensions: ['.ts', '.tsx', '.js', '.jsx', '.json'],
        alias: {
            ...(IS_WDS ? { 'react-dom': '@hot-loader/react-dom' } : {}),
            root: path.resolve(webpackContext, 'src'),
        },
    };

    return {
        mode: IS_PROD_MODE ? 'production' : 'development',
        entry: entryPoint,
        output,
        devtool,
        optimization: webpackOptimizationPart(IS_PROD_MODE),
        plugins: webpackPluginsPart({
            serviceTitle: 'Ebook Library',
            isWebpackDevServer: IS_WDS,
            isProductionDependencies: IS_PROD_DEPS,
            isProductionMode: IS_PROD_MODE,
        }),
        module: {
            rules: webpackRulesPart({ babelConfigPath, isWebpackDevServer: IS_WDS, isProduction: IS_PROD_MODE }),
        },
        resolve,
        context: webpackContext,
        // @ts-ignore
        devServer: webpackDevServerPart(),
    };
};

export default webpackConfig;
