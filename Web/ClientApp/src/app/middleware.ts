import createSagaMiddleware from 'redux-saga';
import { Dependencies } from 'root/app/dependencies';
import { createLogger } from 'redux-logger';
import { routerMiddleware } from 'connected-react-router';
import { appHistory } from 'root/app/initStore';
import { rootSaga } from 'root/app/saga';

export const sagaMiddleware = createSagaMiddleware({
    context: {
        dependencies: new Dependencies(),
    },
});

const loggerMiddleware = createLogger({
    collapsed: true,
    diff: true,
});

export const middlewareArray = [routerMiddleware(appHistory), sagaMiddleware, ...(IS_WDS ? [] : [loggerMiddleware])];
