const _apiUrl = '/api/post';

export const fetchUserPosts = (id) => {
  return fetch(`${_apiUrl}/user/${id}`).then((res) => res.json());
};

