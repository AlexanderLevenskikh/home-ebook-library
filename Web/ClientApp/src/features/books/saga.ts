import { call, getContext, put, select, takeLatest } from 'typed-redux-saga';
import { createAction, PayloadAction } from '@reduxjs/toolkit';
import {
    booksSliceName,
    loadBooksFailed,
    loadBooksStarted,
    loadBooksSucceed,
    setBooks,
} from 'root/features/books/slice';
import { IDependencies } from 'root/app/dependencies';
import { IGetBooksRequestDto } from 'root/api/dto/book';
import { authorsLoadingStateSelector, authorsSelectors } from 'root/features/authors/slice';
import { LoadingState } from 'root/shared/types/loadingState';
import { loadAuthorsForBooksSaga } from 'root/features/authors/saga';

export const loadBooksAction = createAction<IGetBooksRequestDto>(`${booksSliceName}/loadBooks`);

export function* booksSagaArray() {
    yield* takeLatest(loadBooksAction.type, loadBooksSaga);
}

export function* loadBooksSaga(action: PayloadAction<IGetBooksRequestDto>) {
    try {
        const loadingState = yield* select(authorsLoadingStateSelector);

        if (loadingState !== LoadingState.Pending) {
            yield* put(loadBooksStarted({}));
            const { api } = yield* getContext<IDependencies>('dependencies');

            const books = yield* call(api.book.getBooks, action.payload);
            const bookIds = books.items.map((book) => book.id);
            yield* put(setBooks({ items: books.items }));
            yield* call(loadAuthorsForBooksSaga, bookIds);
            yield* put(loadBooksSucceed({ totalCount: books.count }));
        }
    } catch (error) {
        yield* put(loadBooksFailed({ error }));
    }
}
