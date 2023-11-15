const _apiUrl = '/api/tag';

export const fetchTags = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};

export const fetchMyProfileTags = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchEditMyProfileTags = (tagIdArray) => {
  return fetch(`${_apiUrl}/me/edit`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(tagIdArray),
  });
};
