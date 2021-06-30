import { ColumnProps } from 'antd/lib/table';
import React from 'react';
import { IBookDto } from 'root/api/dto/book';
import { renderBooksListAuthor } from 'root/pages/books/BooksList/columns/BooksListAuthor/BooksListAuthor';

export function createBooksListColumnConfiguration(): ColumnProps<IBookDto>[] {
    return [
        {
            title: 'Автор',
            key: 'author',
            render: (_, dto) => renderBooksListAuthor(dto),
            width: '35%',
        },
        {
            title: 'Заголовок',
            key: 'title',
            dataIndex: 'title',
            width: '35%',
        },
    ];
}
