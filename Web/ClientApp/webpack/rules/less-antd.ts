import { RuleSetRule } from 'webpack';
import { IWebpackCSSRuleCreatorArgs } from './css';
import { webpackCssLoader } from './loaders/css';
import { webpackLessLoader } from './loaders/less';
import { webpackPostCSSLoader } from './loaders/postcss';
import { webpackStyleLoader } from './loaders/style';

export const webpackLessAntdRule = ({
    exclude,
    include,
    isProduction = false,
    enableMiniCSS = false,
    postCSSConfigDirPath,
}: IWebpackCSSRuleCreatorArgs): RuleSetRule => ({
    test: /\.(less|css)$/,
    use: [
        webpackStyleLoader(enableMiniCSS || isProduction),
        webpackCssLoader(isProduction, 2, false),
        webpackPostCSSLoader(postCSSConfigDirPath),
        webpackLessLoader(true),
    ],
    include,
    exclude,
});
