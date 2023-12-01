const _apiUrl = '/api/feed';

export const fetchUserFeed = (page = 1, pageSize = 10) => {
  return fetch(`${_apiUrl}?page=${page}&pageSize=${pageSize}`).then((res) =>
    res.json()
  );
};

export const fetchUserFeedStates = () => {
  return fetch(`${_apiUrl}/states`).then((res) => res.json());
};

export const fetchDeleteUserFeedState = (stateId) => {
  return fetch(`${_apiUrl}/states/${stateId}`, {
    method: "DELETE"
  });
};

export const fetchCreateUserFeedState = (stateIdArr) => {
  return fetch(`${_apiUrl}/states`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(stateIdArr)
  });
};

export const fetchUserFeedPrimaryGenres = () => {
  return fetch(`${_apiUrl}/primarygenres`).then((res) => res.json());
};

export const fetchDeleteUserFeedPrimaryGenre = (primaryGenreId) => {
  return fetch(`${_apiUrl}/primarygenres/${primaryGenreId}`, {
    method: 'DELETE',
  });
};

export const fetchCreateUserFeedPrimaryGenre = (primaryGenreArr) => {
  return fetch(`${_apiUrl}/primarygenres`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(primaryGenreArr),
  });
};


export const fetchUserFeedPrimaryInstruments = () => {
  return fetch(`${_apiUrl}/primaryinstruments`).then((res) => res.json());
};

export const fetchDeleteUserFeedPrimaryInstrument = (primaryInstrumentId) => {
  return fetch(`${_apiUrl}/primaryinstruments/${primaryInstrumentId}`, {
    method: 'DELETE',
  });
};

export const fetchCreateUserFeedPrimaryInstrument = (primaryInstrumentArr) => {
  return fetch(`${_apiUrl}/primaryinstruments`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(primaryInstrumentArr),
  });
};

export const fetchUserFeedUsers = () => {
  return fetch(`${_apiUrl}/users`).then((res) => res.json());
};

export const fetchDeleteUserFeedUser = (userId) => {
  return fetch(`${_apiUrl}/users/${userId}`, {
    method: 'DELETE',
  });
};

export const fetchCreateUserFeedUser = (userArr) => {
  return fetch(`${_apiUrl}/users`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(userArr),
  });
};
