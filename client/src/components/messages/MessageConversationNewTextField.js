import { IconButton, TextField } from '@mui/material';
import SendIcon from '@mui/icons-material/Send';
import { useMessages } from '../context/MessagesContext.js';
import { useState } from 'react';
import { useSnackBar } from '../context/SnackBarContext.js';
import { fetchSendMessageExistingConversation } from '../../managers/messagesManager.js';

export const MessageConversationNewTextField = ({
  connection,
  loggedInUser,
}) => {
  const [inputMessage, setInputMessage] = useState('');
  const [blankMessageError, setBlankMessageError] = useState(false);
  const { getMyMessagesByConversation, getMyConversations, conversation } =
    useMessages();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const handleSendMessage = () => {
    setBlankMessageError(false);
    const newMessage = {
      senderIdentityUserId: loggedInUser.identityUserId,
      receiverIdentityUserId: conversation.userProfileIdentityUserId,
      body: inputMessage,
    };

    if (inputMessage.length !== 0) {
      fetchSendMessageExistingConversation(newMessage).then(() => {
        getMyMessagesByConversation();
        setInputMessage('');
        getMyConversations();
      });
    } else {
      setBlankMessageError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Message cannot be empty.');
      handleSnackBarOpen();
    }

    // if (!activeConversationId) {
    //   console.error('No active conversation selected');
    //   return;
    // }

    // connection
    //   .invoke('SendMessage', {
    //     senderIdentityUserId: loggedInUser.identityUserId,
    //     receiverIdentityUserId: conversation.userProfileIdentityUserId,
    //     body: inputMessage,
    //   })
    //   .then(() => {

    //     setInputMessage('');
    //   })
    //   .catch((err) => console.error(err));
  };

  return (
    <>
      <div
      className='messagesNewTextField'
        style={{
          position: 'absolute',
          bottom: '0px',
          width: '297px',
        }}
      >
        <TextField
          placeholder="New message..."
          fullWidth
          error={blankMessageError}
          margin="normal"
          multiline
          value={inputMessage}
          autoFocus={true}
          onChange={(e) => {
            setInputMessage(e.target.value);
            setBlankMessageError(false);
          }}
          sx={{ maxHeight: 200, overflow: 'auto', position: 'relative' }}
          InputProps={{
            endAdornment: (
              <IconButton
                aria-label="send"
                style={{ position: 'absolute', bottom: 7, right: 3 }}
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
