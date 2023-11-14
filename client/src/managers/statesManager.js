const _apiUrl = '/api/state';

export const fetchStates = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};
