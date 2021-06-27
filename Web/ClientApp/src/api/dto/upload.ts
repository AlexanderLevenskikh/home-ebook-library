import { IListDto } from 'root/api/dto/shared';

export interface IUploadDto {
    id: string;
    name: string;
    contentType: string;
    size: number;
}

export interface IUploadListDto extends IListDto<IUploadDto> {}

export interface IUploadFileRequestDto {
    files: File;
    provider: UploadProvider;
}

export interface IUploadFilesRequestDto {
    files: File[];
    provider: UploadProvider;
}

export enum UploadProvider {
    Book = 1,
    Image = 2,
}
