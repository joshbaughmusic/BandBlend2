import { useEffect, useState } from 'react';
import { useMessages } from '../context/MessagesContext.js';
import { Message } from './Message.js';
import { Typography } from '@mui/material';
import { DeleteConversation } from './DeleteConversation.js';
import { useNavigate } from 'react-router-dom';

export const MessageConversationView = ({ loggedInUser, connection }) => {
  const {
    activeConversationId,
    messages,
    getMyMessagesByConversation,
    conversation,
  } = useMessages();

  const navigate = useNavigate();

  // const [intervalId, setIntervalId] = useState(null);

  useEffect(() => {
    getMyMessagesByConversation();

    //refetch new messages every 5 seconds while conversation is open

    // const id = setInterval(() => {
    //   getMyMessagesByConversation();
    // }, 5000);

    // setIntervalId(id);

    // return () => clearInterval(id);
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
        <div style={{ display: 'flex', justifyContent: 'center' }}>
          <Typography
            variant="h6"
            sx={{ mt: 1, mr: '24px', cursor: 'pointer', width: 'fit-content' }}
            onClick={() =>
              navigate(`/profile/${conversation.userProfile.profile.id}`)
            }
          >
            {`${conversation.userProfile.name}`}
          </Typography>
        </div>

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
