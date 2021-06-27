import { IBookListDto, IGetBooksRequestDto } from 'root/api/dto/book';

export interface IBookApi {
    getBooks(request: IGetBooksRequestDto): Promise<IBookListDto>;
}
