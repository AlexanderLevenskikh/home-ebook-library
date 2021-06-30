export function itemsToIds<T>(items: T[], getKey: (item: T) => string): string[] {
    return items.map((item) => getKey(item));
}
