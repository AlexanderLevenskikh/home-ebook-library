import React, { FC, useEffect } from 'react';
import { BookList } from 'root/pages/books/BooksList/BookList';
import { useAppDispatch } from 'root/app/initStore';
import { loadBooksAction, loadBooksSaga } from 'root/features/books/saga';

export const BooksPage: FC = () => {
    const dispatch = useAppDispatch();
    useEffect(() => {
        dispatch(loadBooksAction({}));
    }, []);

    return <BookList />;
};
