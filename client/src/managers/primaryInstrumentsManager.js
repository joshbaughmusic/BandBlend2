const _apiUrl = '/api/primaryinstrument';

export const fetchPrimaryInstruments = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};
