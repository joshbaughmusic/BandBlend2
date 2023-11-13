const _apiUrl = '/api/post';

export const fetchUserPosts = (id, page = 1, pageSize = 10) => {
  return fetch(`${_apiUrl}/user/${id}?page=${page}&pageSize=${pageSize}`).then(
    (res) => res.json()
  );
};

export const featchCreateNewPost = (postText) => {
  return fetch(`${_apiUrl}/new`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(postText)
  }).then((res) => res.json());
};

