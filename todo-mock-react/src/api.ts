import axios, {AxiosInstance} from 'axios';

export const initAxios = (): void => {
    // TODO: V get base url from tenant + config file
    axios.defaults.baseURL = 'https://' + process.env.API_URL;


};

export function getAsQueryParamString(params:any): any {
    if (!params) {
        return undefined;
    }

    return Object.keys(params)
        .filter(key => typeof params[key] === 'string' ? params[key].length > 0 : !!params[key])
        .map(key => key + '=' + params[key])
        .join('&');
}

// TODO: V legacy from here on
let isAxiosInitialized: boolean = false;
let initializedAxiosInstance: AxiosInstance;

export const axiosInstance = (): AxiosInstance => {
    if (!isAxiosInitialized || !initializedAxiosInstance) {
        initAxiosInstance();
        isAxiosInitialized = true;
    }

    return initializedAxiosInstance;
};

const initAxiosInstance = () => {
    axios.defaults.withCredentials = true;

    let baseURL = `https://localhost:44328/api/`;
    const newInstance = axios.create({
        baseURL,
        withCredentials: true,
    });

    newInstance.interceptors.response.use(function(response) {
        if (response.status > 200) {
            console.error(`Got HTTP-Status ${response.status}`);
        }
        return response;
    }, function(error) {
        console.error(`Got Error Response:\n${error}`);
        return Promise.reject(error);
    });

    initializedAxiosInstance = newInstance;
};