import { createEntityAdapter, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { LoadingState } from 'root/shared/types/loadingState';
import { IBookDto } from 'root/api/dto/book';
import { IErrorPayload } from 'root/shared/types/errorPayload';
import { AppState } from 'root/app/initStore';
import { createLoadingSelector } from 'root/shared/utils/createLoadingSelector/createLoadingSelector';
import { IAuthorDto } from 'root/api/dto/author';
import { getAuthorId } from 'root/features/authors/utils/getAuthorId';

export const authorsSliceName = 'authors';

const authorsAdapter = createEntityAdapter<IAuthorDto>({
    selectId: getAuthorId,
    sortComparer: (a, b) => a.title.localeCompare(b.title),
});

const authorsSlice = createSlice({
    name: authorsSliceName,
    initialState: authorsAdapter.getInitialState({
        loadingState: LoadingState.Idle,
    }),
    reducers: {
        loadAuthorsStarted(state, action) {
            state.loadingState = LoadingState.Pending;
        },
        loadAuthorsSucceed(state, action: PayloadAction<{ items: IAuthorDto[] }>) {
            state.loadingState = LoadingState.Succeed;
        },
        loadAuthorsFailed(state, action: PayloadAction<IErrorPayload>) {
            state.loadingState = LoadingState.Failed;
        },
        setAuthors(state, action: PayloadAction<{ items: IAuthorDto[] }>) {
            authorsAdapter.setAll(state, action.payload.items);
        },
        addAuthors(state, action: PayloadAction<{ items: IAuthorDto[] }>) {
            authorsAdapter.addMany(state, action.payload.items);
        },
    },
});

export const authorsSelectors = authorsAdapter.getSelectors<AppState>((state) => state.authors);
export const authorsByIdsSelector = (authorIds: string[]) => (state: AppState) =>
    authorIds.map((authorId) => authorsSelectors.selectById(state, authorId));
export const authorsLoadingStateSelector = (state: AppState) => state.authors.loadingState;
export const authorsLoadingSelector = createLoadingSelector(authorsLoadingStateSelector);

export const {
    actions: { loadAuthorsFailed, loadAuthorsStarted, loadAuthorsSucceed, addAuthors, setAuthors },
    reducer,
} = authorsSlice;
export default reducer;
