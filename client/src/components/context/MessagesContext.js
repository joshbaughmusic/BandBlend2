import { createContext, useContext, useState } from 'react';
import { MessagesMain } from '../messages/MessagesMain.js';

const MessagesContext = createContext({});

export const useMessages = () => {
  return useContext(MessagesContext);
};

export const MessagesProvider = ({ children, loggedInUser }) => {
  const [openMessages, setOpenMessages] = useState(false);
  const [activeConversationId, setActiveConversationId] = useState(null);
  const [newMessageView, setNewMessageView] = useState(false);

  const handleToggleMessages = () => {
    setOpenMessages(!openMessages);
    setActiveConversationId(null)
  };

  const handleCloseMessages = () => {
    setOpenMessages(false);
  };

  return (
    <MessagesContext.Provider
      value={{
        openMessages,
        setOpenMessages,
        handleToggleMessages,
        handleCloseMessages,
        activeConversationId,
        setActiveConversationId,
        newMessageView,
        setNewMessageView,
      }}
    >
      <MessagesMain loggedInUser={loggedInUser} />
      {children}
    </MessagesContext.Provider>
  );
};
