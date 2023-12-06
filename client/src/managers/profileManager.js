const _apiUrl = '/api/profile';

export const fetchCurrentUserWithProfile = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchOtherUserWithProfile = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchAllUsersWithProfiles = (page = 1, pageSize = 10, search, filter, sort) => {
    return fetch(
      `${_apiUrl}?page=${page}&pageSize=${pageSize}&search=${search}&filter=${filter}&sort=${sort}`
    ).then((res) => res.json());
}

export const fetchSearchProfiles = (searchTerms) => {
  return fetch(`${_apiUrl}/search/${searchTerms}`).then((res) => res.json());
};

export const fetchSaveProfile = (id) => {
  return fetch(`${_apiUrl}/${id}/save`, {
    method: "POST",
    headers: {"Content-Type": "application/json"}
  })
};

export const fetchUnsaveProfile = (id) => {
  return fetch(`${_apiUrl}/${id}/unsave`, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' },
  });
};

export const fetchEditPrimaryInfo = (id, profile) => {
  return fetch(`${_apiUrl}/${id}/primaryinfo`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(profile)
  });
};

export const fetchEditAbout = (id, updatedAbout) => {
  return fetch(`${_apiUrl}/${id}/about`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(updatedAbout),
  });
};


export const fetchEditProfilePicture = (url) => {
  return fetch(`${_apiUrl}/profilepicture`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(url),
  });
};

export const fetchDeleteMyUserProfile = () => {
  return fetch(`${_apiUrl}/delete/`, {
    method: 'DELETE',
  });
};
