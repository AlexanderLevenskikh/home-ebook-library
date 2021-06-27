import { httpClient, HttpClientMethod, HttpClientResponseType } from 'root/api/httpClient';
import { IAuthorApi } from 'root/api/interfaces/author';
import { IAuthorListDto, IGetAuthorsRequestDto } from 'root/api/dto/author';

const controllerRoute = 'api/author';

export class AuthorApi implements IAuthorApi {
    getAuthors(request: IGetAuthorsRequestDto): Promise<IAuthorListDto> {
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
