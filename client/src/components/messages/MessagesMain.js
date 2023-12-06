import React, { useState } from 'react';
// import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Fab from '@mui/material/Fab';
import Paper from '@mui/material/Paper';
import TextField from '@mui/material/TextField';
import SendIcon from '@mui/icons-material/Send';
import AddIcon from '@mui/icons-material/Add';
import { useMessages } from '../context/MessagesContext.js';
import {
  Container,
  Divider,
  Fade,
  IconButton,
  Tooltip,
  Typography,
} from '@mui/material';
import './Messages.css';

export const MessagesMain = () => {
  const [conversations, setConversations] = useState();
  const [user, setUser] = useState('');
  const [chosenConversation, setChosenConversation] = useState('');
  const [newMessageView, setNewMessageView] = useState(false);
  const [connection, setConnection] = useState();
  const {
    openMessages,
    setOpenMessages,
    handleCloseMessages,
    handleToggleMessages,
  } = useMessages();

//   const joinConversation = async (user, conversation, message) => {
//     try {
//       const connection = new HubConnectionBuilder()
//         .withUrl('https://localhost:5001/chat')
//         .configureLogging(LogLevel.Information)
//         .build();

//       connection.on('ReceiveMessage', (user, message));
//       console.log('message received:', message);

//       await connection.start();
//       await connection.invoke('JoinConversation', { user, conversation });
//       setConnection(connection);
//     } catch (e) {
//       console.log(e);
//     }
//   };

  return (
    <div>
      <Fab
        color="primary"
        aria-label="messages"
        onClick={handleToggleMessages}
        style={{ position: 'fixed', bottom: 16, right: 16 }}
      >
        <SendIcon />
      </Fab>

      <Fade in={openMessages}>
        <Paper
          elevation={5}
          style={{
            position: 'fixed',
            bottom: 80,
            right: 16,
            width: 410,
            height: 500,
            overflow: 'auto',
            border: '2px solid black',
            zIndex: "2000"
          }}
        >
          <Container>
            {/* <div>
              <div>Sample Message 1</div>
              <div>Sample Message 2</div>
            </div> */}

            <div className="messagesMain-header">
              <Typography variant="h6">Messages</Typography>
              <Tooltip
                title="New Message"
                placement="left-start"
              >
                <IconButton>
                  <AddIcon />
                </IconButton>
              </Tooltip>
            </div>
            <Divider />
            <TextField
              placeholder="Type your message..."
              fullWidth
              margin="normal"
              value={user}
              onChange={(e) => setUser(e.target.value)}
              InputProps={{
                endAdornment: (
                  <Fab
                    size="small"
                    color="primary"
                    onClick={handleCloseMessages}
                  >
                    <SendIcon />
                  </Fab>
                ),
              }}
            />
          </Container>
        </Paper>
      </Fade>
    </div>
  );
};
