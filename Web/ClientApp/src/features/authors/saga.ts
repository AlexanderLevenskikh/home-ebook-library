import { call, getContext, put } from 'typed-redux-saga';
import { setAuthors } from 'root/features/authors/slice';
import { IDependencies } from 'root/app/dependencies';

export function* loadAuthorsForBooksSaga(bookIds: string[]) {
    const { api } = yield* getContext<IDependencies>('dependencies');

    const authors = yield* call(api.author.getAuthors, { bookIds });
    yield* put(setAuthors({ items: authors.items }));
}
