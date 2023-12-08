import { useEffect, useState } from 'react';
import { useMessages } from '../context/MessagesContext.js';
import { fetchMyMessagesByConversation } from '../../managers/messagesManager.js';
import { Message } from './Message.js';
import { MessageConversationNewTextField } from './MessageConversationNewTextField.js';
import { Typography } from '@mui/material';

export const MessageConversationView = ({ loggedInUser, connection, conversation }) => {
  const [messages, setMessages] = useState();

  const {
    openMessages,
    setOpenMessages,
    handleCloseMessages,
    handleToggleMessages,
    activeConversationId,
    setActiveConversationId,
    newMessageView,
    setNewMessageView,
  } = useMessages();

  const getMyMessagesByConversation = () => {
    fetchMyMessagesByConversation(activeConversationId).then(setMessages);
  };

  useEffect(() => {
    getMyMessagesByConversation();
  }, [activeConversationId]);

  useEffect(() => {
    if (connection) {
      connection.on('SendMessage', (message) => {
        console.log("message:", message)
        setMessages((prevMessages) => [...prevMessages, message]);
      });
    }
  }, [connection]);


  if (!messages) {
    return (
      <>
        <div>Loading...</div>
      </>
    );
  }

  return (
    <>
      <div style={{overflow: "auto", height: "435px", paddingBottom: "80px"}}>
        <Typography variant='h6' sx={{mt: 1, ml: "86.5px"}}>{`${conversation.userProfile.name}`}</Typography>
        {messages.map((m, index) => (
          <Message message={m} key={index} />
        ))}
        
      </div>
    </>
  );
};
