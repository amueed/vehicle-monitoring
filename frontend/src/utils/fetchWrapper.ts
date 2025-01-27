/* eslint-disable @typescript-eslint/no-explicit-any */
export const fetchWrapper = {
    get,
};

function get(url: string) {
    const requestOptions: any = {
        method: "GET",
    };
    return fetch(url, requestOptions).then(handleResponse);
}

function handleResponse(response: any) {
    return response.text().then((text: any) => {
        const data = text && JSON.parse(text);
        if (!response.ok) {
            const status = response.status;
            const error = (data && data.message) || response.statusText;
            return Promise.reject({ status, error });
        }

        return data;
    });
}