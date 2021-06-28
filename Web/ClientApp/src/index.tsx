import 'core-js/stable';
import 'regenerator-runtime/runtime';

import React from 'react';
import ReactDOM from 'react-dom';
import { AppLayout } from 'root/shared/components/AppLayout/AppLayout';
import './general.less';

function initApp() {
    const root = document.getElementById('root');

    if (root) {
        ReactDOM.render(renderApp(), root);
    }

    function renderApp() {
        return <AppLayout></AppLayout>;
    }
}

initApp();
