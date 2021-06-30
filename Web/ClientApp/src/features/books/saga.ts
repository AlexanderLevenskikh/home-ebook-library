import { call, getContext, put, takeLatest } from 'typed-redux-saga';
import { createAction, PayloadAction } from '@reduxjs/toolkit';
import { booksSliceName, loadBooksFailed, loadBooksSucceed } from 'root/features/books/slice';
import { IDependencies } from 'root/app/dependencies';
import { IGetBooksRequestDto } from 'root/api/dto/book';

export const loadBooksAction = createAction<IGetBooksRequestDto>(`${booksSliceName}/loadBooks`);

export function* booksSagaArray() {
    yield* takeLatest(loadBooksAction.type, loadBooksSaga);
}

export function* loadBooksSaga(action: PayloadAction<IGetBooksRequestDto>) {
    try {
        const { api } = yield* getContext<IDependencies>('dependencies');

        const books = yield* call(api.book.getBooks, action.payload);
        yield* put(
            loadBooksSucceed({
                items: books.items,
                totalCount: books.count,
            }),
        );
    } catch (error) {
        yield* put(loadBooksFailed({ error }));
    }
}
