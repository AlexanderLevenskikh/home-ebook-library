/**
 * Преобразует js-объект с любой вложенностью в объект FormData
 * При вызове функции необходимо передать только первый аргумент, остальные используются при рекурсивных вызовах
 */
export function objectToFormData(object: { [key: string]: any }, formData: FormData = new FormData(), namespace?: string): FormData {
    if (typeof object !== 'object') {
        throw new TypeError('First function argument must be the object.');
    }

    for (const property in object) {
        if (!object.hasOwnProperty(property)) {
            continue;
        }
        let formKey: string = property;

        if (Array.isArray(object)) {
            formKey = namespace ? `${namespace}[${property}]` : `[${property}]`;
        } else {
            formKey = namespace ? `${namespace}.${formKey}` : property;
        }

        if (typeof object[property] === 'object' && !(object[property] instanceof Blob)) {
            objectToFormData(object[property], formData, formKey);
        } else {
            formData.append(formKey, object[property]);
        }
    }

    return formData;
}
