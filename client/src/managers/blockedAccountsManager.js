const _apiUrl = '/api/blockedaccount';

export const fetchMyBlockedAccounts = () => {
  return fetch(`${_apiUrl}`).then((res) => res.json());
};

export const fetchCreateNewBlockedAccount = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
  });
};

export const fetchUnblockAccount = (id) => {
  return fetch(`${_apiUrl}/${id}`, {
    method: 'DELETE',
  });
};
