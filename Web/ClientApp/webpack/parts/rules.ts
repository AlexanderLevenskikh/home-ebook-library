import { webpackTSXRule } from '../rules/typescriptJSX';
import { webpackFileRule, webpackLessRule } from '../rules';
import { webpackContext } from '../context';

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
            postCSSConfigDirPath: webpackContext,
        }),
        webpackFileRule({
            include: /src/,
        }),
    ];
};
