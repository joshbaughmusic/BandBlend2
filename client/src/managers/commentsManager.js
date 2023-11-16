const _apiUrl = '/api/comment';

export const fetchCommentsForPost = (postId, page = 1, pageSize = 10) => {
  return fetch(`${_apiUrl}/${postId}?page=${page}&pageSize=${pageSize}`).then(
    (res) => res.json()
  );
};

export const fetchCreateNewComment = (commentText) => {
  return fetch(`${_apiUrl}/new`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(commentText),
  }).then((res) => res.json());
};

export const fetchDeleteComment = (id) => {
  return fetch(`${_apiUrl}/delete/${id}`, {
    method: 'DELETE',
  });
};

export const fetchEditComment = (id, editedCommentBody) => {
  return fetch(`${_apiUrl}/edit/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(editedCommentBody),
  });
};
