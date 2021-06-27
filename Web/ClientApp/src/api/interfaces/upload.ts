import { IUploadDto, IUploadFileRequestDto, IUploadFilesRequestDto, IUploadListDto } from 'root/api/dto/upload';

export interface IUploadApi {
    createUpload(request: IUploadFileRequestDto): Promise<IUploadDto>;
    createUploads(request: IUploadFilesRequestDto): Promise<IUploadListDto>;
    getUpload(uploadId: string): Promise<IUploadDto>;
    getUploadFile(uploadId: string): Promise<File>;
}
