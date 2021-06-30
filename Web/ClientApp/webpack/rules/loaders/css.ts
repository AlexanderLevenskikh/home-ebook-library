export const webpackCssLoader = (isProduction: boolean, importLoaders: number, isLocalMode: boolean = true) => ({
    loader: 'css-loader',
    options: {
        modules: {
            mode: isLocalMode ? 'local' : 'global',
            localIdentName: isProduction ? '[hash:base64:5]' : '[local]_[hash:base64:5]',
        },
        importLoaders,
    },
});
