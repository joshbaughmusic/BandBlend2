import { createContext, useContext, useEffect, useState } from 'react';
import { MessagesMain } from '../messages/MessagesMain.js';
import {
  fetchMarkAsRead,
  fetchMyConversations,
  fetchMyMessagesByConversation,
  fetchUnreadMessages,
} from '../../managers/messagesManager.js';

const MessagesContext = createContext({});

export const useMessages = () => {
  return useContext(MessagesContext);
};

export const MessagesProvider = ({ children, loggedInUser }) => {
  const [openMessages, setOpenMessages] = useState(false);
  const [activeConversationId, setActiveConversationId] = useState(null);
  const [newMessageView, setNewMessageView] = useState(true);
  const [selectedRecipient, setSelectedRecipient] = useState(null);
  const [messages, setMessages] = useState();
  const [conversations, setConversations] = useState();
  const [conversation, setConversation] = useState();
  const [unreadMessages, setUnreadMessages] = useState();

  useEffect(() => {
   if (loggedInUser) {
    fetchUnreadMessages().then(setUnreadMessages)
   }
   if (activeConversationId) {
    fetchMarkAsRead(activeConversationId).then(() => {
      fetchUnreadMessages().then(setUnreadMessages);
    });
   }
  }, [loggedInUser, activeConversationId])

  const handleToggleMessages = () => {
    setOpenMessages(!openMessages);
    setActiveConversationId(null);
  };

  const handleCloseMessages = () => {
    setOpenMessages(false);
  };

  const getMyMessagesByConversation = () => {
    fetchMyMessagesByConversation(activeConversationId).then((res) => {
      setMessages(res);
      fetchMarkAsRead(activeConversationId)
    });
  };

  const getMyConversations = (id) => {
    fetchMyConversations().then((res) => {
      const conversationsWithOnlyOtherUserAttached = res.map((c) => {
        return c.userProfileIdIdentityUserId1 === loggedInUser.identityUserId
          ? {
              id: c.id,
              userProfileId: c.userProfileId2,
              userProfileIdentityUserId: c.userProfileIdIdentityUserId2,
              lastMessageDate: c.lastMessageDate,
              userProfile: c.userProfile2,
            }
          : {
              id: c.id,
              userProfileId: c.userProfileId1,
              userProfileIdentityUserId: c.userProfileIdIdentityUserId1,
              lastMessageDate: c.lastMessageDate,
              userProfile: c.userProfile1,
            };
      });
      setConversations(conversationsWithOnlyOtherUserAttached);
      if (id) {
        setActiveConversationId(id);
      }
    });
  };

  useEffect(() => {
    if (conversations) {
      setConversation(conversations.find((c) => c.id == activeConversationId));
    }
  }, [activeConversationId]);

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
        selectedRecipient,
        setSelectedRecipient,
        messages,
        setMessages,
        getMyMessagesByConversation,
        getMyConversations,
        conversations,
        setConversations,
        conversation,
        setConversation,
        unreadMessages,
        setUnreadMessages
      }}
    >
      <MessagesMain loggedInUser={loggedInUser} />
      {children}
    </MessagesContext.Provider>
  );
};
