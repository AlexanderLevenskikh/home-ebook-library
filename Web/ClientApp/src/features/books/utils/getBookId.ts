import { IBookDto } from 'root/api/dto/book';

export function getBookId(book: IBookDto): string {
    return book.id;
}
