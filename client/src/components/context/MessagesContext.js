import { createContext, useContext, useState } from 'react';
import { MessagesMain } from '../messages/MessagesMain.js';

const MessagesContext = createContext({});

export const useMessages = () => {
  return useContext(MessagesContext);
};

export const MessagesProvider = ({ children }) => {
  const [openMessages, setOpenMessages] = useState(false);

  const handleToggleMessages = () => {
    setOpenMessages(!openMessages);
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
      }}
    >
      <MessagesMain />
      {children}
    </MessagesContext.Provider>
  );
};
