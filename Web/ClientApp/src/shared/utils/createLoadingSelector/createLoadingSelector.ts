import { createSelector } from '@reduxjs/toolkit';
import { AppState } from 'root/app/initStore';
import { LoadingState } from 'root/shared/types/loadingState';

export function createLoadingSelector(loadingStateSelector: (state: AppState) => LoadingState) {
    return createSelector<AppState, LoadingState, boolean>(loadingStateSelector, (res) => res === LoadingState.Pending);
}
