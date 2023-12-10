import { useState } from 'react';
import { useMessages } from '../context/MessagesContext.js';
import SendIcon from '@mui/icons-material/Send';
import { Fade, IconButton, TextField, Typography } from '@mui/material';
import { MessageNewMessageRecipient } from './MessageNewMessageRecipientSearch.js';
import { useSnackBar } from '../context/SnackBarContext.js';
import { fetchSendMessageNoConversation } from '../../managers/messagesManager.js';

export const MessageNewMessageView = ({ loggedInUser }) => {
  const {
    newMessageView,
    setNewMessageView,
    selectedRecipient,
    getMyConversations,
  } = useMessages();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [newMessageBody, setNewMesageBody] = useState('');
  const [blankMessageError, setBlankMessageError] = useState(false);

  const handleSendMessage = () => {
    setBlankMessageError(false);
    const newMessage = {
      senderIdentityUserId: loggedInUser.identityUserId,
      receiverIdentityUserId: selectedRecipient.identityUserId,
      body: newMessageBody,
    };

    if (newMessageBody.length !== 0) {
      fetchSendMessageNoConversation(newMessage).then((res) => {
        getMyConversations(res.messageConversationId);
        setNewMessageView(false);
        setNewMesageBody('');
      });
    } else {
      setBlankMessageError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Message cannot be empty.');
      handleSnackBarOpen();
    }
  };

  return (
    <>
      <Fade in={newMessageView}>
        <div style={{ marginTop: '8px', marginRight: '16px' }}>
          {selectedRecipient ? (
            <>
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  justifyContent: 'space-between',
                  height: '420px',
                }}
              >
                <Typography
                  variant="h6"
                  textAlign="center"
                >
                  {selectedRecipient.name}
                </Typography>
                <TextField
                  placeholder="New message..."
                  multiline
                  minRows={8}
                  fullWidth
                  error={blankMessageError}
                  value={newMessageBody}
                  autoFocus={true}
                  onChange={(e) => {
                    setBlankMessageError(false);
                    setNewMesageBody(e.target.value);
                  }}
                  sx={{ position: 'relative' }}
                  InputProps={{
                    endAdornment: (
                      <IconButton
                        aria-label="send"
                        style={{ position: 'absolute', bottom: 3, right: 3 }}
                        onClick={() => handleSendMessage()}
                      >
                        <SendIcon />
                      </IconButton>
                    ),
                  }}
                />
              </div>
            </>
          ) : (
            <>
              <Typography
                textAlign="center"
                variant="h6"
              >
                New Message
              </Typography>
              <MessageNewMessageRecipient />
            </>
          )}
        </div>
      </Fade>
    </>
  );
};
