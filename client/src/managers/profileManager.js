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