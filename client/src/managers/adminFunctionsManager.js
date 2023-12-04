const _apiUrl = '/api/admin';

export const fetchAdminDeletePostOtherPost = (id) => {
  return fetch(`${_apiUrl}/post/${id}`, {
    method: 'DELETE',
  });
};

export const fetchAdminDeleteCommentOtherPost = (id) => {
  return fetch(`${_apiUrl}/comment/${id}`, {
    method: 'DELETE',
  });
};

export const fetchAdminDeleteOtherAdditionalPhoto = (id) => {
  return fetch(`${_apiUrl}/additionalphoto/${id}`, {
    method: 'DELETE',
  });
};

