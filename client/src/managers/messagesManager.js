const _apiUrl = '/api/messages';

export const fetchMyConversations = () => {
  return fetch(`${_apiUrl}/conversations`).then((res) => res.json());
};

export const fetchMyMessagesByConversation = (conversationId) => {
  return fetch(`${_apiUrl}/messages/${conversationId}`).then((res) =>
    res.json()
  );
};

export const fetchSendMessageExistingConversation = (message) => {
  return fetch(`${_apiUrl}/existing`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(message),
  });
};

export const fetchSendMessageNoConversation = (message) => {
  return fetch(`${_apiUrl}/new`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(message),
  }).then((res) => res.json())
};

export const fetchDeleteMessage = (id) => {
  return fetch(`${_apiUrl}/delete/${id}`, {
    method: 'DELETE',
  });
};

export const fetchDeleteMessageConverstaion = (id) => {
  return fetch(`${_apiUrl}/delete/conversation/${id}`, {
    method: 'DELETE',
  });
};

export const fetchEditMessage = (id, editedMessageBody) => {
  return fetch(`${_apiUrl}/edit/${id}`, {
    method: 'PUT',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(editedMessageBody),
  });
};
