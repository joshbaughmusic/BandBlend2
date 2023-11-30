const _apiUrl = '/api/feed';

export const fetchUserFeed = (page = 1, pageSize = 10) => {
  return fetch(`${_apiUrl}?page=${page}&pageSize=${pageSize}`).then((res) =>
    res.json()
  );
};

export const fetchUserFeedStates = () => {
  return fetch(`${_apiUrl}/states`).then((res) => res.json());
};

export const fetchUserFeedPrimaryGenres = () => {
  return fetch(`${_apiUrl}/primarygenres`).then((res) => res.json());
};

export const fetchUserFeedPrimaryInstruments = () => {
  return fetch(`${_apiUrl}/primaryinstruments`).then((res) => res.json());
};
