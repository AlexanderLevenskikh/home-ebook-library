import { IUploadApi } from 'root/api/interfaces/upload';
import { IUploadDto, IUploadFileRequestDto, IUploadFilesRequestDto, IUploadListDto } from 'root/api/dto/upload';
import { httpClient, HttpClientMethod, HttpClientResponseType } from 'root/api/httpClient';

const controllerRoute = 'api/upload';

export class UploadApi implements IUploadApi {
    createUpload(request: IUploadFileRequestDto): Promise<IUploadDto> {
        return httpClient.makeRequest({
            method: HttpClientMethod.POST,
            responseType: HttpClientResponseType.JSON,
            route: controllerRoute,
            request: {
                body: request,
                toFormData: true,
            },
        });
    }

    createUploads(request: IUploadFilesRequestDto): Promise<IUploadListDto> {
        return httpClient.makeRequest({
            method: HttpClientMethod.POST,
            responseType: HttpClientResponseType.JSON,
            route: `${controllerRoute}/multiple`,
            request: {
                body: request,
                toFormData: true,
            },
        });
    }

    getUpload(uploadId: string): Promise<IUploadDto> {
        return httpClient.makeRequest({
            method: HttpClientMethod.GET,
            responseType: HttpClientResponseType.JSON,
            route: `${controllerRoute}/${uploadId}`,
            request: {},
        });
    }

    getUploadFile(uploadId: string): Promise<File> {
        return httpClient.makeRequest({
            method: HttpClientMethod.GET,
            responseType: HttpClientResponseType.Binary,
            route: `${controllerRoute}/${uploadId}/file`,
            request: {},
        });
    }
}
