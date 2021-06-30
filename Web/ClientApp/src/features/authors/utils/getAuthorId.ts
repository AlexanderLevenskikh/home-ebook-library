import { IAuthorDto } from 'root/api/dto/author';

export function getAuthorId(author: IAuthorDto): string {
    return author.id;
}
