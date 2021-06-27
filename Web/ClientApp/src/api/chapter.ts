import { httpClient, HttpClientMethod, HttpClientResponseType } from 'root/api/httpClient';
import { IChapterApi } from 'root/api/interfaces/chapter';
import { IChapterListDto, IGetChaptersRequestDto } from 'root/api/dto/chapter';

const controllerRoute = 'api/chapter';

export class ChapterApi implements IChapterApi {
    getChapters(request: IGetChaptersRequestDto): Promise<IChapterListDto> {
        return httpClient.makeRequest({
            method: HttpClientMethod.GET,
            responseType: HttpClientResponseType.JSON,
            route: `${controllerRoute}/list`,
            request: {
                query: request,
            },
        });
    }
}
