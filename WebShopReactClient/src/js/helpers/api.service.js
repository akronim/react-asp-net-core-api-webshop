import fetcher from "./fetcher";

export const apiService = {
  get,
};

function get(url, successCallback) {
  const requestOptions = {
    method: "GET",
  };

  return fetcher.fetchCall(url, requestOptions, successCallback);
}

export default apiService;
