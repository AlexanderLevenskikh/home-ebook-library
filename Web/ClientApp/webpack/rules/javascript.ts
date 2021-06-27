import { RuleSetRule } from 'webpack';
import { IWebpackRuleCreatorArgs } from './index';
import { webpackBabelLoader } from './loaders/babel';

export interface IWebpackJavascriptRuleCreatorArgs extends IWebpackRuleCreatorArgs {
    configFile: string;
}

export const webpackJavascriptRule = ({ exclude, include, configFile }: IWebpackJavascriptRuleCreatorArgs): RuleSetRule => ({
    test: /\.jsx?$/,
    use: [
        webpackBabelLoader(configFile),
    ],
    include,
    exclude,
});

