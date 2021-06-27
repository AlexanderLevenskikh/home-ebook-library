import { IUploadApi } from 'root/api/interfaces/upload';
import { UploadApi } from 'root/api/upload';
import { IBookApi } from 'root/api/interfaces/book';
import { IChapterApi } from 'root/api/interfaces/chapter';
import { IAuthorApi } from 'root/api/interfaces/author';
import { BookApi } from 'root/api/book';
import { ChapterApi } from 'root/api/chapter';
import { AuthorApi } from 'root/api/author';

export interface IApi {
    upload: IUploadApi;
    book: IBookApi;
    chapter: IChapterApi;
    author: IAuthorApi;
}

export class Api implements IApi {
    upload = new UploadApi();
    book = new BookApi();
    chapter = new ChapterApi();
    author = new AuthorApi();
}
