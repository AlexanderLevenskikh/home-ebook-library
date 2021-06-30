import { spawn } from 'typed-redux-saga';
import { booksSagaArray } from 'root/features/books/saga';

export function* rootSaga() {
    yield* spawn(booksSagaArray);
}
