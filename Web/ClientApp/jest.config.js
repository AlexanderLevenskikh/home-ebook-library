const tsJestPresets = require('ts-jest/presets');

const preset = tsJestPresets.jsWithBabel;

module.exports = {
    cacheDirectory: '<rootDir>/.jest-cache',
    globals: {
        'ts-jest': {
            babelConfig: true,
            tsConfig: 'tsconfig.json',
            useBabelrc: true,
            enableTsDiagnostics: true,
        },
    },
    moduleDirectories: ['./node_modules', './src'],
    moduleFileExtensions: ['js', 'json', 'jsx', 'ts', 'tsx', 'node'],
    moduleNameMapper: {
        '^root/(.*)$': '<rootDir>/src/$1',
        '\\.(jpg|jpeg|png|gif|eot|otf||svg|ttf|woff|woff2)$': '<rootDir>/scripts/fileMock.js',
        '\\.(css|less)$': 'identity-obj-proxy',
    },
    setupFilesAfterEnv: ['<rootDir>/scripts/setup.jest.js'],
    testRegex: '(test.tsx?)$',
    testPathIgnorePatterns: ['/typings/'],
    transform: {
        '^.+\\.(js|jsx|ts|tsx)$': 'babel-jest',
    },
    transformIgnorePatterns: [],
    verbose: true,
};
