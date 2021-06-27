export interface IListDto<T> {
    items: T[];
    count: number;
}

export interface IPagingDto {
    limit?: number;
    offset?: number;
}
