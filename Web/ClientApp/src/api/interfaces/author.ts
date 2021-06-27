import { IAuthorListDto, IGetAuthorsRequestDto } from 'root/api/dto/author';

export interface IAuthorApi {
    getAuthors(request: IGetAuthorsRequestDto): Promise<IAuthorListDto>;
}
