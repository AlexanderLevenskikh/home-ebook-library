module.exports = function (api) {
    api.cache(true);
    const presets = [
        [
            '@babel/preset-env',
            {
                useBuiltIns: 'entry',
                corejs: 3,
            },
        ],
        '@babel/typescript',
        '@babel/react',
    ];
    return {
        sourceType: 'unambiguous',
        presets,
    };
};
