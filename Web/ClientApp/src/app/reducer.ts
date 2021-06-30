import { combineReducers } from 'redux';
import { connectRouter } from 'connected-react-router';
import { BrowserHistory } from 'history';
import booksReducer from 'root/features/books/slice';
import authorsReducer from 'root/features/authors/slice';

export const rootReducer = (history: BrowserHistory) =>
    combineReducers({
        router: connectRouter(history),
        authors: authorsReducer,
        books: booksReducer,
    });
