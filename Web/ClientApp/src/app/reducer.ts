import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import { BrowserHistory } from 'history';
import booksReducer from 'root/features/books/slice';

export const rootReducer = (history: BrowserHistory) =>
    combineReducers({
        router: connectRouter(history),
        books: booksReducer,
    });
