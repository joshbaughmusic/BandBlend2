const _apiUrl = '/api/auth';

export const login = (email, password) => {
  return fetch(_apiUrl + '/login', {
    method: 'POST',
    credentials: 'same-origin',
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser();
    }
  });
};

export const logout = () => {
  return fetch(_apiUrl + '/logout');
};

export const tryGetLoggedInUser = () => {
  return fetch(_apiUrl + '/me').then((res) => {
    return res.status === 401 ? Promise.resolve(null) : res.json();
  });
};

export const register = (userProfile) => {
  userProfile.password = btoa(userProfile.password);

  return fetch(_apiUrl + '/register', {
    credentials: 'same-origin',
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(userProfile),
  })
    .then((res) => {
      if (!res.ok) {
        const statusCode = res.status;
        if (statusCode === 400) {
          throw new Error('Email already in use');
        } else if (statusCode === 500) {
          throw new Error('Failed to create a new account');
        } else {
          throw new Error(`Unexpected error with status: ${statusCode}`);
        }
      }
      return fetch(_apiUrl + '/me').then((res) => res.json());
    })
    .catch((error) => {
      console.error('Registration error:', error);
      throw error;
    });
};
