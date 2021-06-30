import React, { FC } from 'react';
import { useSelector } from 'react-redux';
import { IBookDto } from 'root/api/dto/book';
import { authorsByIdsSelector } from 'root/features/authors/slice';

interface IProps {
    authorIds: string[];
}

export const BooksListAuthor: FC<IProps> = ({ authorIds }) => {
    const authors = useSelector(authorsByIdsSelector(authorIds));

    if (authors.length === 1) {
        return <span>{authors[0]?.title}</span>;
    }

    return (
        <ul>
            {authors.map((author) => {
                return <li key={author?.id}>{author?.title}</li>;
            })}
        </ul>
    );
};

export function renderBooksListAuthor(book: IBookDto) {
    return <BooksListAuthor authorIds={book.authorIds} />;
}
