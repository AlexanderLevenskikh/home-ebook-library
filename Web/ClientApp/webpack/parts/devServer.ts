import { Configuration } from 'webpack-dev-server';

export const webpackDevServerPart = (): Configuration => {
    return {
        compress: true,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, PATCH, OPTIONS',
            'Access-Control-Allow-Headers': 'X-Requested-With, content-type, Authorization',
            mode: 'cors',
        },
        historyApiFallback: {
            rewrites: [{ from: /./, to: '/index.html' }],
        },
        hot: true,
        port: 8080,
        proxy: {
            '/api': {
                target: {
                    host: '127.0.0.1',
                    protocol: 'https:',
                    port: 5001,
                },
                secure: false,
            },
        },
    };
};
