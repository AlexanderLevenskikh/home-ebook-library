import { RuleSetRule } from 'webpack';
import { IWebpackJavascriptRuleCreatorArgs } from './javascript';
import { webpackBabelLoader } from './loaders/babel';

export const webpackTypescriptRule = ({ exclude, include, configFile }: IWebpackJavascriptRuleCreatorArgs): RuleSetRule => ({
    test: /\.[jt]s$/,
    use: [
        webpackBabelLoader(configFile),
    ],
    include,
    exclude,
});
