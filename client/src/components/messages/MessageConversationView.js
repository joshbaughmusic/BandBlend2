import { useEffect, useState } from 'react';
import { useMessages } from '../context/MessagesContext.js';
import { fetchMyMessagesByConversation } from '../../managers/messagesManager.js';
import { Message } from './Message.js';
import { MessageConversationNewTextField } from './MessageConversationNewTextField.js';
import { Typography } from '@mui/material';
import { DeleteConversation } from './DeleteConversation.js';

export const MessageConversationView = ({ loggedInUser, connection }) => {
  const {
    activeConversationId,
    messages,
    getMyMessagesByConversation,
    conversation,
  } = useMessages();

  useEffect(() => {
    getMyMessagesByConversation();
  }, [activeConversationId]);

  // useEffect(() => {
  //   if (connection) {
  //     connection.on('SendMessage', (message) => {
  //       console.log('message:', message);
  //       setMessages((prevMessages) => [...prevMessages, message]);
  //     });
  //   }
  // }, [connection]);

  const el = document.getElementById(`message-container`);

  useEffect(() => {
    if (el) {
      el.scrollTop = el.scrollHeight;
    }
  }, [messages]);

  if (!messages || !conversation) {
    return (
      <>
        <Typography
          textAlign="center"
          sx={{ mt: 1, mr: '24px' }}
        >
          Loading...
        </Typography>
      </>
    );
  }

  return (
    <>
      <div
        id={`message-container`}
        style={{
          overflow: 'auto',
          height: '435px',
          paddingBottom: '80px',
          position: 'relative',
        }}
      >
       
          <DeleteConversation />
          <Typography
            variant="h6"
            textAlign="center"
            sx={{ mt: 1, mr: '24px' }}
          >
            {`${conversation.userProfile.name}`}
          </Typography>
      
        {messages.map((m, index) => (
          <Message
            message={m}
            key={index}
            loggedInUser={loggedInUser}
          />
        ))}
      </div>
    </>
  );
};
