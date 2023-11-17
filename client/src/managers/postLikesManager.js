const _apiUrl = '/api/postlike';

export const fetchLikesForPost = (postId) => {
  return fetch(`${_apiUrl}/${postId}`).then((res) => res.json());
};

export const fetchNewPostLike = (postId) => {
  return fetch(`${_apiUrl}/${postId}`, {
    method: 'POST',
  }).then((res) => res.json());
};

export const fetchDeletePostLike = (postId) => {
  return fetch(`${_apiUrl}/${postId}`, {
    method: 'DELETE',
  });
};
