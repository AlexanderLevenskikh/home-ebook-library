import { IDependencies } from 'root/app/dependencies';
import { configureStore } from '@reduxjs/toolkit';

export function initStore(deps: IDependencies) {
    return configureStore({
        reducer,
    });
}
