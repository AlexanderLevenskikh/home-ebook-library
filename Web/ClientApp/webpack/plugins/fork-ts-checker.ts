import ForkTsCheckerWebpackPlugin from 'fork-ts-checker-webpack-plugin';

export const webpackForkTsCheckerPlugin = (tsconfigPath: string) => {
    return new ForkTsCheckerWebpackPlugin({
        typescript: {
            configFile: tsconfigPath,
        },
        async: true,
    });
};
