import React, { FC } from 'react';
import { Table } from 'antd';
import { IBookListItemView } from 'root/pages/books/BooksList/BookListView';
import styles from './styles.less';
import { createBooksListColumnConfiguration } from 'root/pages/books/BooksList/columnConfiguration';
import { getBookId } from 'root/features/books/utils/getBookId';
import { useSelector } from 'react-redux';
import { booksLoadingSelector, booksSelectors, booksTotalCountSelector } from 'root/features/books/slice';
import { TableHeaderCell } from 'root/shared/components/TableHeaderCell';

export const BookList: FC = () => {
    const books = useSelector(booksSelectors.selectAll);
    const loading = useSelector(booksLoadingSelector);
    const count = useSelector(booksTotalCountSelector);
    const columns = createBooksListColumnConfiguration();

    return (
        <Table<IBookListItemView>
            className={styles.list}
            columns={columns}
            bordered={false}
            rowKey={getBookId}
            dataSource={books}
            loading={loading}
            size='middle'
            components={{
                header: {
                    cell: TableHeaderCell,
                },
            }}
            pagination={false}
        />
    );
};
