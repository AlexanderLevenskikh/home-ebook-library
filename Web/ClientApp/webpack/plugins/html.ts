import HTMLWebpackPlugin from 'html-webpack-plugin';

export interface IWebpackHTMLPluginArgs {
    title: string;
    templatePath: string;
}

export const webpackHTMLPlugin = ({ templatePath, title }: IWebpackHTMLPluginArgs) => {
    return new HTMLWebpackPlugin({
        title,
        template: templatePath,
        inject: true,
    });
};
