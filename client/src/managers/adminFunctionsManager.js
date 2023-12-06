const _apiUrl = '/api/admin';

export const fetchAdminAllAdmins = () => {
  return fetch(`${_apiUrl}`).then(res => res.json());
};

export const fetchAdminAllBannedUsers = () => {
  return fetch(`${_apiUrl}/banned`).then(res => res.json());
};

export const fetchAdminUnbanAccount = (userProfileId) => {
  return fetch(`${_apiUrl}/unban/${userProfileId}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
  });
};

export const fetchAdminBanAccount = (userProfileId) => {
  return fetch(`${_apiUrl}/ban/${userProfileId}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
  });
};

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

export const fetchAdminDeleteProfilePhoto = (profileId) => {
  return fetch(`${_apiUrl}/profilephoto/${profileId}`, {
    method: 'DELETE',
  });
};

export const fetchPromoteToAdmin = (userProfileId) => {
    return fetch(`${_apiUrl}/promote/${userProfileId}`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
    });
}

export const fetchDemoteToUser = (userProfileId) => {
    return fetch(`${_apiUrl}/demote/${userProfileId}`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
    });
}

export const fetchAdminDeleteUserProfile = (identityUserId) => {
  return fetch(`${_apiUrl}/userprofile/${identityUserId}`, {
    method: 'DELETE',
  });
};


