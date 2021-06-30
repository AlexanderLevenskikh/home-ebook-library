import React, { FC } from 'react';
import { Table } from 'antd';
import styles from './styles.less';
import { createBooksListColumnConfiguration } from 'root/pages/books/BooksList/columnConfiguration';
import { getBookId } from 'root/features/books/utils/getBookId';
import { useSelector } from 'react-redux';
import { booksLoadingSelector, booksSelectors, booksTotalCountSelector } from 'root/features/books/slice';
import { TableHeaderCell } from 'root/shared/components/TableHeaderCell';
import { IBookDto } from 'root/api/dto/book';

export const BookList: FC = () => {
    const books = useSelector(booksSelectors.selectAll);
    const loading = useSelector(booksLoadingSelector);
    const count = useSelector(booksTotalCountSelector);
    const columns = createBooksListColumnConfiguration();

    return (
        <Table<IBookDto>
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
