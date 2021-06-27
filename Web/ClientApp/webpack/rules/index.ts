import { RuleSetCondition } from 'webpack';

export interface IWebpackRuleCreatorArgs {
    include?: RuleSetCondition;
    exclude?: RuleSetCondition;
}

export { webpackTypescriptRule } from './typescript';
export { webpackJavascriptRule, IWebpackJavascriptRuleCreatorArgs } from './javascript';
export { webpackCssRule, IWebpackCSSRuleCreatorArgs } from './css';
export { webpackLessRule } from './less';
export { webpackFileRule } from './file';

