import React, { useState } from 'react';
// import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';
import Fab from '@mui/material/Fab';
import Paper from '@mui/material/Paper';
import TextField from '@mui/material/TextField';
import SendIcon from '@mui/icons-material/Send';
import AddIcon from '@mui/icons-material/Add';
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

export const MessagesMain = () => {
  const [conversations, setConversations] = useState();
  const [user, setUser] = useState('');
  const [room, setRoom] = useState('');
  const [chosenConversation, setChosenConversation] = useState('');
  const [newMessageView, setNewMessageView] = useState(false);
  const [connection, setConnection] = useState();
  const {
    openMessages,
    setOpenMessages,
    handleCloseMessages,
    handleToggleMessages,
  } = useMessages();

  const joinRoom = async (user, room) => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl('https://localhost:5001/message-hub')
        .configureLogging(LogLevel.Information)
        .build();

      connection.on('ReceiveMessage', (user, message) => {
        console.log('message received:', message);
      });

      await connection.start();
      await connection.invoke('JoinRoom', { user, room });
      setConnection(connection);
    } catch (e) {
      console.log(e);
    }
  };

  const handleSubmit = () => {
    joinRoom(user, room);
  };

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
            zIndex: '2000',
          }}
        >
          <Container>
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
              placeholder="User..."
              fullWidth
              margin="normal"
              value={user}
              onChange={(e) => setUser(e.target.value)}
              InputProps={{}}
            />
            <TextField
              placeholder="Room..."
              fullWidth
              margin="normal"
              value={room}
              onChange={(e) => setRoom(e.target.value)}
              InputProps={{}}
            />
            <Button onClick={() => handleSubmit()}>Submit</Button>
          </Container>
        </Paper>
      </Fade>
    </div>
  );
};
