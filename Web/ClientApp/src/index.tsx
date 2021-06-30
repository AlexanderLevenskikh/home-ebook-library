import 'core-js/stable';
import 'regenerator-runtime/runtime';
import 'antd/dist/antd.less';

import React from 'react';
import ReactDOM from 'react-dom';
import { AppLayout } from 'root/pages/app/AppLayout/AppLayout';
import './general.less';
import { Provider } from 'react-redux';
import { appHistory, store } from 'root/app/initStore';
import { ConnectedRouter } from 'connected-react-router';
import { Route, Switch } from 'react-router';
import { BooksPage } from 'root/pages/books/BooksPage';
import ruRU from 'antd/es/locale/ru_RU';
import { ConfigProvider } from 'antd';

function initApp() {
    const root = document.getElementById('root');

    if (root) {
        ReactDOM.render(renderApp(), root);
    }

    function renderApp() {
        return (
            <Provider store={store}>
                <ConnectedRouter history={appHistory}>
                    <ConfigProvider locale={ruRU}>
                        <AppLayout>
                            <Switch>
                                <Route render={() => <BooksPage />} />
                            </Switch>
                        </AppLayout>
                    </ConfigProvider>
                </ConnectedRouter>
            </Provider>
        );
    }
}

initApp();
