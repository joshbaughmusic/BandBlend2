const _apiUrl = '/api/subgenre';

export const fetchSubGenres = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};

export const fetchMyProfileSubGenres = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchEditMyProfileSubGenres = (subGenreIdArray) => {
  return fetch(`${_apiUrl}/me/edit`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(subGenreIdArray),
  });
};
