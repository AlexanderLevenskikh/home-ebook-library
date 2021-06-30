import { createEntityAdapter, createSelector, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { LoadingState } from 'root/shared/types/loadingState';
import { IBookDto } from 'root/api/dto/book';
import { IErrorPayload } from 'root/shared/types/errorPayload';
import { getBookId } from 'root/features/books/utils/getBookId';
import { AppState } from 'root/app/initStore';
import { createLoadingSelector } from 'root/shared/utils/createLoadingSelector/createLoadingSelector';

export const booksSliceName = 'books';

const booksAdapter = createEntityAdapter<IBookDto>({
    selectId: getBookId,
    sortComparer: (a, b) => a.title.localeCompare(b.title),
});

const booksSlice = createSlice({
    name: booksSliceName,
    initialState: booksAdapter.getInitialState({
        loadingState: LoadingState.Idle,
        detailsLoadingState: LoadingState.Idle,
        totalCount: 0,
    }),
    reducers: {
        loadBooksStarted(state, action) {
            state.loadingState = LoadingState.Pending;
        },
        loadBooksSucceed(state, action: PayloadAction<{ items: IBookDto[]; totalCount: number }>) {
            state.loadingState = LoadingState.Succeed;
            state.totalCount = action.payload.totalCount;
            booksAdapter.addMany(state, action.payload.items);
        },
        loadBooksFailed(state, action: PayloadAction<IErrorPayload>) {
            state.loadingState = LoadingState.Failed;
        },
    },
});

export const booksSelectors = booksAdapter.getSelectors<AppState>((state) => state.books);
export const booksLoadingSelector = createLoadingSelector((state) => state.books.loadingState);
export const loadingBookDetailsSelector = createLoadingSelector((state) => state.books.detailsLoadingState);
export const booksTotalCountSelector = (state: AppState) => state.books.totalCount;

export const {
    actions: { loadBooksFailed, loadBooksStarted, loadBooksSucceed },
    reducer,
} = booksSlice;
export default reducer;
