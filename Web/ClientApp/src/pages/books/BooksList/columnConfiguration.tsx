import { ColumnProps } from 'antd/lib/table';
import React from 'react';
import { IBookListItemView } from 'root/pages/books/BooksList/BookListView';

export function createBooksListColumnConfiguration(): ColumnProps<IBookListItemView>[] {
    return [
        {
            title: 'Заголовок',
            key: 'title',
            dataIndex: 'title',
            width: '35%',
        },
    ];
}
