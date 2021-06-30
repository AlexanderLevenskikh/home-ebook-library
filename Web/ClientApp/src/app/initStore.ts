import { applyMiddleware, compose, createStore } from '@reduxjs/toolkit';
import { useDispatch } from 'react-redux';
import { rootReducer } from 'root/app/reducer';
import { createBrowserHistory } from 'history';
import { middlewareArray, sagaMiddleware } from 'root/app/middleware';
import { rootSaga } from 'root/app/saga';

export const appHistory = createBrowserHistory();

const composeEnhancer: typeof compose = (window as any).__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const store = createStore(
    rootReducer(appHistory),
    undefined,
    composeEnhancer(applyMiddleware(...middlewareArray)),
);

sagaMiddleware.run(rootSaga);

export type AppState = ReturnType<typeof store.getState>;

if (module.hot && !IS_WDS) {
    module.hot.accept('root/app/reducer', () => {
        store.replaceReducer(rootReducer(appHistory));
    });
}

export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
