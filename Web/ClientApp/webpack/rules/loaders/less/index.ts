export const webpackLessLoader = (javascriptIsEnabled: boolean = false) => ({
    loader: 'less-loader',
    options: {
        lessOptions: {
            javascriptEnabled: javascriptIsEnabled,
        },
    },
});
