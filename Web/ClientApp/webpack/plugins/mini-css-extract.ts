import MiniCssExtractPlugin from 'mini-css-extract-plugin';

export const webpackMiniCssPlugin = (filename: string) => {
    return new MiniCssExtractPlugin({
        filename,
        ignoreOrder: true,
    });
};
