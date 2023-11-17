const _apiUrl = '/api/commentlike';

export const fetchLikesForComment = (commentId) => {
  return fetch(`${_apiUrl}/${commentId}`).then((res) => res.json());
};

export const fetchNewCommentLike = (commentId) => {
  return fetch(`${_apiUrl}/${commentId}`, {
    method: 'POST',
  }).then((res) => res.json());
};

export const fetchDeleteCommentLike = (commentId) => {
  return fetch(`${_apiUrl}/${commentId}`, {
    method: 'DELETE',
  });
};
