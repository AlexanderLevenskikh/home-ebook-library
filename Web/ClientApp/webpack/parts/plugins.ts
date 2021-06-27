import path from 'path';
import { Configuration } from 'webpack';
import { webpackContext } from '../context';
import { webpackMiniCssPlugin } from '../plugins/mini-css-extract';
import { webpackHTMLPlugin } from '../plugins/html';
import { webpackForkTsCheckerPlugin } from '../plugins/fork-ts-checker';
import { webpackDevServerHMRPlugin } from '../plugins/devServerHMR';
import { webpackDefinePlugin } from '../plugins/define';

interface IWebpackPluginsPartArgs {
    serviceTitle: string;
    isWebpackDevServer: boolean;
    isProductionDependencies: boolean;
    isProductionMode: boolean;
}

export const webpackPluginsPart = (args: IWebpackPluginsPartArgs): Configuration['plugins'] => {
    const { serviceTitle, isWebpackDevServer, isProductionDependencies, isProductionMode } = args;

    return [
        webpackDefinePlugin({
            isWebpackDevServer,
            isProductionDependencies,
            isProductionMode,
        }),
        webpackMiniCssPlugin('[name].[contenthash].css'),
        webpackHTMLPlugin({
            title: serviceTitle,
            templatePath: path.resolve(webpackContext, 'public/index.html'),
        }),
        webpackForkTsCheckerPlugin(path.resolve(webpackContext, 'tsconfig.json')),
        ...(isWebpackDevServer ? [webpackDevServerHMRPlugin()] : []),
    ];
};
