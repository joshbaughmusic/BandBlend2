const _apiUrl = '/api/profile';

export const fetchCurrentUserWithProfile = () => {
  return fetch(`${_apiUrl}/me`).then((res) => res.json());
};

export const fetchOtherUserWithProfile = (id) => {
  return fetch(`${_apiUrl}/${id}`).then((res) => res.json());
};

export const fetchAllUsersWithProfiles = (page = 1, pageSize = 10) => {
    return fetch(`${_apiUrl}?page=${page}&pageSize=${pageSize}`).then((res) => res.json());

}