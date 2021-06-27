import TerserPlugin from 'terser-webpack-plugin';

export const webpackTerserPlugin = () => {
    return new TerserPlugin({
        parallel: true,
        terserOptions: {
            output: {
                comments: false,
            },
        },
    });
}
