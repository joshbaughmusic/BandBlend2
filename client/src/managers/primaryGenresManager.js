const _apiUrl = '/api/primarygenre';

export const fetchPrimaryGenres = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};
