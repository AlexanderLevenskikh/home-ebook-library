import { IMap } from 'root/shared/types/map';

export function itemsToMap<T>(items: T[], getKey: (item: T) => string): IMap<T> {
    return items.reduce(
        (result: IMap<T>, item: T) => ({
            ...result,
            [getKey(item)]: item,
        }),
        {},
    );
}
