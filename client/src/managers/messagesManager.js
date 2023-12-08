const _apiUrl = '/api/messages';

export const fetchMyConversations = () => {
  return fetch(`${_apiUrl}/conversations`).then((res) => res.json());
};

export const fetchMyMessagesByConversation = (conversationId) => {
  return fetch(`${_apiUrl}/messages/${conversationId}`).then((res) =>
    res.json()
  );
};

