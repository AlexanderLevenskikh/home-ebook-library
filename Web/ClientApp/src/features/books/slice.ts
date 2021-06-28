import { createSlice } from '@reduxjs/toolkit';
import { LoadingState } from 'root/shared/types/loadingState';
import { IBookDto } from 'root/api/dto/book';
import { IMap } from 'root/shared/types/map';

export interface IBooksState {
    map: IMap<IBookDto>;
    loadingState: LoadingState;
    detailsLoadingState: LoadingState;
}

const initialState: IBooksState = {
    items: [],
    loadingState: LoadingState.Idle,
};

export const booksSlice = createSlice({
    name: 'books',
    initialState,
    reducers: {
        loadBooks(state, action) {
            if (state.loadingState !== LoadingState.Pending) {
                state.loadingState = LoadingState.Pending;
            }
        },
        booksReceived(state, action) {},
    },
});
