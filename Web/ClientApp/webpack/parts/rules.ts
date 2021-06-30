import { webpackTSXRule } from '../rules/typescriptJSX';
import { webpackFileRule, webpackLessRule } from '../rules';
import { webpackContext } from '../context';
import { webpackLessAntdRule } from '../rules/less-antd';

interface IWebpackRulesPartArgs {
    isWebpackDevServer: boolean;
    isProduction: boolean;
    babelConfigPath: string;
}

export const webpackRulesPart = ({ isProduction, isWebpackDevServer, babelConfigPath }: IWebpackRulesPartArgs) => {
    return [
        webpackTSXRule({
            isWebpackDevServer,
            include: /src/,
            configFile: babelConfigPath,
        }),
        webpackLessRule({
            isProduction,
            include: /src/,
            exclude: /node_modules/,
            postCSSConfigDirPath: webpackContext,
        }),
        webpackLessAntdRule({
            isProduction,
            include: /antd/,
            postCSSConfigDirPath: webpackContext,
        }),
        webpackFileRule({
            include: /src/,
        }),
    ];
};
