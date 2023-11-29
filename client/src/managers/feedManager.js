const _apiUrl = '/api/feed';

export const fetchUserFeed = (page = 1, pageSize = 10) => {
  return fetch(`${_apiUrl}?page=${page}&pageSize=${pageSize}`).then(
    (res) => res.json()
  );
};
