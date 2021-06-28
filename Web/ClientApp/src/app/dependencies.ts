import { Api, IApi } from 'root/api';

export interface IDependencies {
    api: IApi;
}

export class Dependencies implements IDependencies {
    api = new Api();
}
