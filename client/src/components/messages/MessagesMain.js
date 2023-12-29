import React, { useEffect, useState } from 'react';
// import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Fab from '@mui/material/Fab';
import Paper from '@mui/material/Paper';
import { useMessages } from '../context/MessagesContext.js';
import {
  Badge,
  Divider,
  Fade,
  Typography,
  useMediaQuery,
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
import { useTheme } from '@emotion/react';

export const MessagesMain = ({ loggedInUser }) => {
  const [connection, setConnection] = useState();
  const {
    openMessages,
    handleToggleMessages,
    activeConversationId,
    newMessageView,
    setNewMessageView,
    setSelectedRecipient,
    getMyConversations,
    unreadMessages
  } = useMessages();

  useEffect(() => {
    getMyConversations();

    // const connection = new HubConnectionBuilder()
    // .withUrl(`https://localhost:5001/message-hub?userId=${loggedInUser.identityUserId}`)
    // .configureLogging(LogLevel.Information)
    // .build();
    // setConnection(connection);

    //   connection
    //     .start()
    //     .then(() => {
    //       console.log('Connection Established');
    //     })
    //     .catch((error) => console.error(error));

    //   return () => {
    //     connection.stop();
    //   };
  }, []);

  // const handleSendNewMessage = () => {
  //   if (!activeConversationId) {
  //     console.error('No active conversation selected');
  //     return;
  //   }

  //   connection
  //     .invoke('SendMessage', {
  //       senderUserProfileId: loggedInUser.IdentityUserId,
  //       recipientUserProfileId: 2, // Replace with the recipient's actual UserProfileId
  //       body: newInputMessage,
  //     })
  //     .then(() => setNewInputMessage(''))
  //     .catch((err) => console.error(err));
  // };

    const theme = useTheme();
    const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  if (!unreadMessages) {
    return null
  }

  return (
    <div>
        <Fab
          color="primary"
          aria-label="messages"
          onClick={() => {
            setNewMessageView(true);
            handleToggleMessages();
            setSelectedRecipient(null);
          }}
          style={{ position: 'fixed', bottom: 16, right: 16 }}
        >
          {openMessages ? <CloseIcon /> :
          <>
          <Badge color='secondary' badgeContent={unreadMessages.length} max={99}>
          <MailIcon />
          </Badge>
          </> 
          }
        </Fab>

      <Fade in={openMessages}>
        {mediaQuerySmall ?
        
        <Paper
          elevation={10}
          sx={{
            borderRadius: '3%',
            position: 'fixed',
            bottom: 80,
            right: 16,
            width: 350,
            height: 491,
            overflow: 'auto',
            zIndex: '1000',
          }}
          className="messages-container"
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
          <MessageConversationSidebar loggedInUser={loggedInUser} />

          <div
            style={{
              marginLeft: '60px',
            }}
            className="messages-inner"
          >
            <div
              style={{
                paddingLeft: '16px',
              }}
            >
              {activeConversationId && !newMessageView ? (
                <>
                  <MessageConversationView
                    loggedInUser={loggedInUser}
                    connection={connection}
                  />
                  <MessageConversationNewTextField
                    connection={connection}
                    loggedInUser={loggedInUser}
                  />
                </>
              ) : (
                <>
                  <MessageNewMessageView loggedInUser={loggedInUser} />
                </>
              )}
            </div>
          </div>
        </Paper>
        :
        <Paper
          elevation={10}
          sx={{
            borderRadius: '3%',
            position: 'fixed',
            bottom: 80,
            right: 16,
            width: 410,
            height: 491,
            overflow: 'auto',
            zIndex: '1500',
          }}
          className="messages-container"
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
          <MessageConversationSidebar loggedInUser={loggedInUser} />

          <div
            style={{
              marginLeft: '60px',
            }}
            className="messages-inner"
          >
            <div
              style={{
                paddingLeft: '16px',
              }}
            >
              {activeConversationId && !newMessageView ? (
                <>
                  <MessageConversationView
                    loggedInUser={loggedInUser}
                    connection={connection}
                  />
                  <MessageConversationNewTextField
                    connection={connection}
                    loggedInUser={loggedInUser}
                  />
                </>
              ) : (
                <>
                  <MessageNewMessageView loggedInUser={loggedInUser} />
                </>
              )}
            </div>
          </div>
        </Paper>
      }
      </Fade>
    </div>
  );
};
