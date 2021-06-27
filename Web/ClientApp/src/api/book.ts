import { httpClient, HttpClientMethod, HttpClientResponseType } from 'root/api/httpClient';
import { IBookApi } from 'root/api/interfaces/book';
import { IBookListDto, IGetBooksRequestDto } from 'root/api/dto/book';

const controllerRoute = 'api/book';

export class BookApi implements IBookApi {
    getBooks(request: IGetBooksRequestDto): Promise<IBookListDto> {
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
