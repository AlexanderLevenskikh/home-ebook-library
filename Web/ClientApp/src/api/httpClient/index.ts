import { notEmpty } from 'root/shared/utils/notEmpty';
import { objectToFormData } from 'root/api/httpClient/objectToFormData';

export interface IHttpClient {
    makeRequest(options: IHttpClientOptions): Promise<any>;
}

export enum HttpClientMethod {
    GET = 'GET',
    POST = 'POST',
    PUT = 'PUT',
    DELETE = 'DELETE',
}

export interface IHttpClientRequest {
    query?: Record<string, any>;
    body?: Record<string, any>;
    toFormData?: boolean;
}

export enum HttpClientResponseType {
    Binary,
    Primitive,
    JSON,
}

export interface IHttpClientOptions {
    route: string;
    method: HttpClientMethod;
    request: IHttpClientRequest;
    responseType: HttpClientResponseType;
}

export class HttpClient implements IHttpClient {
    private readonly serverOrigin: string;

    constructor(serverOrigin: string) {
        this.serverOrigin = serverOrigin;
    }

    public async makeRequest(options: IHttpClientOptions): Promise<any> {
        const { request, responseType, method, route } = options;

        const href = HttpClient.buildHref(this.serverOrigin, route, request.query);

        let httpClientOptions: RequestInit = {
            method: options.method.toString(),
        };

        if ((method === HttpClientMethod.POST || method === HttpClientMethod.PUT) && request.body) {
            if (request.toFormData) {
                const body = objectToFormData(request.body);

                httpClientOptions = {
                    ...httpClientOptions,
                    body,
                };
            } else {
                httpClientOptions = {
                    ...httpClientOptions,
                    body: JSON.stringify(request.body),
                    headers: {
                        ...httpClientOptions.headers,
                        Accept: 'application/json, application/xml, text/plain, text/html, *.*',
                        'Content-Type': 'application/json; charset=utf-8',
                    },
                };
            }
        }

        return fetch(href, httpClientOptions).then(async (response) => {
            if (response.ok) {
                if (responseType === HttpClientResponseType.Binary) {
                    const blob = await response.blob();
                    const contentDisposition = response.headers.get('content-disposition');
                    if (contentDisposition) {
                        const filenameRegex = /filename[^;=\n]*=(?:(\\?['"])(.*?)\1|(?:[^\s]+'.*?')?([^;\n]*))/gi;
                        const firstGroupMatches = filenameRegex.exec(contentDisposition);
                        const secondGroupMatches = filenameRegex.exec(contentDisposition);
                        if (notEmpty(secondGroupMatches)) {
                            let filename;
                            if (secondGroupMatches[3]) {
                                filename = decodeURIComponent(secondGroupMatches[3]);
                            } else if (notEmpty(firstGroupMatches) && firstGroupMatches[2]) {
                                filename = firstGroupMatches[2];
                            } else {
                                filename = 'file';
                            }

                            let file: Blob;
                            try {
                                file = new File([blob], filename);
                            } catch (err) {
                                console.error(err);
                                return null;
                            }

                            return file;
                        }
                    }

                    return blob;
                } else if (responseType === HttpClientResponseType.Primitive) {
                    return response.text();
                }
                return HttpClient.parseJSON(response);
            } else {
                // Ability to implement error handling based on status code/payload/etc...
                console.error(response.status);
            }
        });
    }

    private static buildHref(baseUrl: string, route: string, searchParams?: Record<string, any>): string {
        const url = new URL(route, baseUrl);

        if (searchParams) {
            Object.keys(searchParams).forEach((key) => {
                const value = searchParams[key];
                if (notEmpty(value)) {
                    url.searchParams.append(key, value);
                }
            });
        }

        return url.href;
    }

    private static async parseJSON(response: Response): Promise<any> {
        const text = await response.text();
        let json = text ? JSON.parse(text) : {};
        const count = response.headers.get('X-Total-Count');

        if (count) {
            json = {
                items: json,
                count: Number.parseInt(count),
            };
        }

        return json;
    }
}

const serverOrigin = window.location.origin;

export const httpClient = new HttpClient(serverOrigin);
