import React, { useEffect, useState } from 'react';
// import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Fab from '@mui/material/Fab';
import Paper from '@mui/material/Paper';
import TextField from '@mui/material/TextField';
import { useMessages } from '../context/MessagesContext.js';
import {
  Button,
  Container,
  Divider,
  Fade,
  IconButton,
  Tooltip,
  Typography,
} from '@mui/material';
import './Messages.css';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import { fetchMyConversations } from '../../managers/messagesManager.js';
import MailIcon from '@mui/icons-material/Mail';
import CloseIcon from '@mui/icons-material/Close';
import { MessageConversationSidebar } from './MessageConversationSidebar.js';
import { MessageConversationView } from './MessageConversationView.js';
import { MessageConversationNewTextField } from './MessageConversationNewTextField.js';
import { MessageNewMessageView } from './MessageNewMessageView.js';

export const MessagesMain = ({ loggedInUser }) => {
  const [conversations, setConversations] = useState();
  const [newInputMessage, setNewInputMessage] = useState();
  const [connection, setConnection] = useState();
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

  const getMyConversations = () => {
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
      setActiveConversationId(conversationsWithOnlyOtherUserAttached[0].id);
    });
  };

  useEffect(() => {
    getMyConversations();

    const connection = new HubConnectionBuilder()
      .withUrl('https://localhost:5001/message-hub')
      .configureLogging(LogLevel.Information)
      .build();

    setConnection(connection);

    connection
      .start()
      .then(() => {
        console.log('Connection Established');
      })
      .catch((error) => console.error(error));

    return () => {
      connection.stop();
    };
  }, []);

  const handleSendNewMessage = () => {
    if (!activeConversationId) {
      console.error('No active conversation selected');
      return;
    }

    connection
      .invoke('SendMessage', {
        senderUserProfileId: loggedInUser.IdentityUserId,
        recipientUserProfileId: 2, // Replace with the recipient's actual UserProfileId
        body: newInputMessage,
      })
      .then(() => setNewInputMessage(''))
      .catch((err) => console.error(err));
  };

  return (
    <div>
      <Fab
        color="primary"
        aria-label="messages"
        onClick={() => {
          setNewMessageView(true);
          handleToggleMessages();
        }}
        style={{ position: 'fixed', bottom: 16, right: 16 }}
      >
        {openMessages ? <CloseIcon /> : <MailIcon />}
      </Fab>

      <Fade in={openMessages}>
        <Paper
          elevation={5}
          variant="outlined"
          sx={{
            position: 'fixed',
            bottom: 80,
            right: 16,
            width: 410,
            height: 500,
            overflow: 'auto',
            border: '2px solid black',
            zIndex: '1500',
          }}
        >
          <div
            className="messagesMain-header"
            style={{
              paddingLeft: '24px',
              paddingRight: '24px',
            }}
          >
            <Typography variant="h6">Messages</Typography>
          </div>
          <Divider />
          <MessageConversationSidebar
            loggedInUser={loggedInUser}
            conversations={conversations}
          />

          <div
            style={{
              marginLeft: '60px',
            }}
          >
            <div
              style={{
                paddingLeft: '16px',
              }}
            >
              {activeConversationId && !newMessageView ? (
                <div style={{ position: 'relative' }}>
                  <MessageConversationView
                    loggedInUser={loggedInUser}
                    connection={connection}
                    conversation={conversations.find(
                      (c) => c.id == activeConversationId
                    )}
                  />
                  <MessageConversationNewTextField
                    connection={connection}
                    loggedInUser={loggedInUser}
                    conversation={conversations.find(
                      (c) => c.id == activeConversationId
                    )}
                  />
                </div>
              ) : (
                <>
                 <MessageNewMessageView />
                </>
              )}
            </div>
          </div>
        </Paper>
      </Fade>
    </div>
  );
};
