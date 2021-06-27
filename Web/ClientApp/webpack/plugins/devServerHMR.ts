import { HotModuleReplacementPlugin } from 'webpack';

export const webpackDevServerHMRPlugin = () => {
    return new HotModuleReplacementPlugin();
};
