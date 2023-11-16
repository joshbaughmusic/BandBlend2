const _apiUrl = '/api/photo';

export const fetchMyAdditionalPhotos = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchOtherAdditionalPhotos = (id) => {
  return fetch(`${_apiUrl}/user/${id}`).then((res) => res.json());
};

export const fetchUploadAdditionalPhoto = (url) => {
  return fetch(`${_apiUrl}/add`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(url),
  });
};
export const fetchDeleteAdditionalPhoto = (id) => {
  return fetch(`${_apiUrl}/delete/${id}`, {
    method: "DELETE"
  });
};