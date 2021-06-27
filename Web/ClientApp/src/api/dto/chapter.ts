import { IListDto } from 'root/api/dto/shared';

export interface IChapterDto {
    id: string;
    level: number;
    title: string;
}

export interface IChapterListDto extends IListDto<IChapterDto> {}

export interface IGetChaptersRequestDto {
    bookId: string;
}
