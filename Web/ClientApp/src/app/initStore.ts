import { Dependencies } from 'root/app/dependencies';
import { configureStore } from '@reduxjs/toolkit';
import { useDispatch } from 'react-redux';
import createSagaMiddleware from 'redux-saga';
import { createLogger } from 'redux-logger';
import { rootReducer } from 'root/app/reducer';

const sagaMiddleware = createSagaMiddleware({
    context: {
        dependencies: new Dependencies(),
    },
});
const loggerMiddleware = createLogger({
    collapsed: true,
    diff: true,
});

export const store = configureStore({
    reducer: rootReducer,
    devTools: IS_WDS,
    middleware: [sagaMiddleware, ...(IS_WDS ? [] : [loggerMiddleware])],
});

if (module.hot && !IS_WDS) {
    module.hot.accept('root/app/reducer', () => {
        store.replaceReducer(rootReducer);
    });
}

export type AppDispatch = typeof store.dispatch;
export const useAppDispatch = () => useDispatch<AppDispatch>();
