import { RuleSetRule } from 'webpack';
import { IWebpackJavascriptRuleCreatorArgs } from './javascript';
import { webpackBabelLoader } from './loaders/babel';
import { webpackReactHotLoader } from './loaders/reactHotLoader';

export interface IWebpackTSXRuleCreatorArgs extends IWebpackJavascriptRuleCreatorArgs {
    isWebpackDevServer?: boolean;
}

export const webpackTSXRule = ({
    isWebpackDevServer = false,
    include,
    configFile,
}: IWebpackTSXRuleCreatorArgs): RuleSetRule => ({
    test: /\.[jt]sx?$/,
    use: [...(isWebpackDevServer ? [webpackReactHotLoader()] : []), webpackBabelLoader(configFile)],
    include,
});
