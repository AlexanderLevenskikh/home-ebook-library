import { IListDto, IPagingDto } from 'root/api/dto/shared';

export interface IBookDto {
    id: string;
    title: string;
    contentId: string;
    imageId?: string;
    authorIds: string[];
}

export interface IBookListDto extends IListDto<IBookDto> {}

export interface IGetBooksRequestDto extends IPagingDto {
    authorId?: string;
    titleSubstring?: string;
}
