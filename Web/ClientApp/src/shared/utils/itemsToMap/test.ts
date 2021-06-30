import { itemsToMap } from 'root/shared/utils/itemsToMap/index';

describe('itemsToMap', function () {
    it('checking', () => {
        const items = [
            {
                id: '1',
                val: 'val1',
            },
            {
                id: '2',
                val: 'val2',
            },
        ];

        const result = itemsToMap(items, (item) => item.id);

        expect(Object.keys(result)).toContain('1');
        expect(Object.keys(result)).toContain('2');
        expect(Object.keys(result)).toHaveLength(2);
    });
});
