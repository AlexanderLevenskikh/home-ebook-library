import { DefinePlugin } from 'webpack';

export interface IWebpackDefinePluginArgs {
    isWebpackDevServer: boolean;
    isProductionDependencies: boolean;
    isProductionMode: boolean;
}

export const webpackDefinePlugin = (args: IWebpackDefinePluginArgs) => {
    const { isWebpackDevServer, isProductionDependencies, isProductionMode } = args;

    return new DefinePlugin({
        IS_WDS: isWebpackDevServer,
        IS_PROD_DEPS: isProductionDependencies,
        IS_PROD_MODE: isProductionMode,
    });
};
