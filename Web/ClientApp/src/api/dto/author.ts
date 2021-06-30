import { IListDto, IPagingDto } from 'root/api/dto/shared';

export interface IAuthorDto {
    id: string;
    title: string;
}

export interface IAuthorListDto extends IListDto<IAuthorDto> {}

export interface IGetAuthorsRequestDto extends IPagingDto {
    bookId?: string;
    bookIds?: string[];
    titleSubstring?: string;
}
