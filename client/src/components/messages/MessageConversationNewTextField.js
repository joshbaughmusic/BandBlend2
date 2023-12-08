import { IconButton, TextField } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { useMessages } from '../context/MessagesContext.js';
import { useState } from 'react';

export const MessageConversationNewTextField = ({
  connection,
  loggedInUser,
  conversation,
}) => {
  const [inputMessage, setInputMessage] = useState();
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

  const handleSendMessage = () => {
    if (!activeConversationId) {
      console.error('No active conversation selected');
      return;
    }

    connection
      .invoke('SendMessage', {
        senderIdentityUserId: loggedInUser.identityUserId,
        receiverIdentityUserId: conversation.userProfileIdentityUserId,
        body: inputMessage,
      })
      .then(() => {
        
        setInputMessage('');
      })
      .catch((err) => console.error(err));
  };

  return (
    <>
    <div style={{position: "absolute", bottom: "0px", width: "297px", backgroundColor: "white"}}>

      <TextField
        placeholder="New message..."
        fullWidth
        margin="normal"
        value={inputMessage}
        onChange={(e) => setInputMessage(e.target.value)}
        InputProps={{
          endAdornment: (
            <IconButton
            edge="end"
            aria-label="send"
            onClick={() => handleSendMessage()}
            >
              <SendIcon />
            </IconButton>
          ),
        }}
        />
        </div>
    </>
  );
};
