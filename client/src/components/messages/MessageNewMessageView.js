import { useState } from 'react';
import { useMessages } from '../context/MessagesContext.js';
import SendIcon from '@mui/icons-material/Send';
import { Fade, IconButton, TextField, Typography } from '@mui/material';
import { MessageNewMessageRecipient } from './MessageNewMessageRecipientSearch.js';

export const MessageNewMessageView = ({conversations}) => {
  const {
    openMessages,
    setOpenMessages,
    handleCloseMessages,
    handleToggleMessages,
    activeConversationId,
    setActiveConversationId,
    newMessageView,
    setNewMessageView,
    selectedRecipient,
    setSelectedRecipient,
  } = useMessages();
  const [newMessageBody, setNewMesageBody] = useState('');

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
                value={newMessageBody}
                onChange={(e) => setNewMesageBody(e.target.value)}
                sx={{ position: 'relative' }}
                InputProps={{
                  endAdornment: (
                    <IconButton
                    aria-label="send"
                    style={{ position: 'absolute', bottom: 3, right: 3 }}
                    // onClick={() => handleSendMessage()}
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
            <MessageNewMessageRecipient conversations={conversations} />
          </>
        )}
      </div>
        </Fade>
    </>
  );
};
