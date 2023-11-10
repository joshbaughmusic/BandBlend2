const _apiUrl = '/api/photo';

export const fetchMyAdditionalPhotos = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchOtherAdditionalPhotos = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};
