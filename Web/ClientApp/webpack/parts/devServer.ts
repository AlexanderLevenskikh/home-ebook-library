import { Configuration } from 'webpack-dev-server';

export const webpackDevServerPart = (): Configuration => {
    return {
        host: '0.0.0.0',
        public: 'localhost:8080',
        publicPath: '/',
        headers: {
            'Access-Control-Allow-Origin': '*',
        },
        quiet: false,
        noInfo: false,
        stats: {
            assets: false,
            colors: true,
            version: false,
            hash: false,
            timings: false,
            children: false,
            chunks: false,
            chunkModules: false,
        },
        historyApiFallback: {
            rewrites: [{ from: /./, to: '/public/index.html' }],
        },
        hot: true,
    };
};
