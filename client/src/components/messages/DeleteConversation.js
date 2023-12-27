import DeleteIcon from '@mui/icons-material/Delete';
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  IconButton,
  Button,
  Tooltip,
} from '@mui/material';
import { useState } from 'react';
import { useSnackBar } from '../context/SnackBarContext.js';
import { useMessages } from '../context/MessagesContext.js';
import { fetchDeleteMessageConverstaion } from '../../managers/messagesManager.js';

export const DeleteConversation = () => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const {
    setActiveConversationId,
    setNewMessageView,
    setSelectedRecipient,
    getMyConversations,
    conversation,
  } = useMessages();

  const handleDeleteClick = () => {
    setConfirmOpen(true);
  };

  const handleConfirmClick = () => {
    fetchDeleteMessageConverstaion(conversation.id).then((res) => {
      if (res.status === 204) {
        getMyConversations();
        setActiveConversationId(null);
        setSelectedRecipient(null);
        setNewMessageView(true);
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('Conversation successfully deleted!');
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete conversation.');
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  return (
    <>
      <div style={{ position: 'absolute', right: '20px', top: '2px' }}>
        <Tooltip
          title="Delete Conversation"
          placement="top-start"
        >
          <IconButton onClick={handleDeleteClick}>
            <DeleteIcon />
          </IconButton>
        </Tooltip>
      </div>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
        sx={{ marginBottom: '10vh' }}
      >
        <DialogTitle id="alert-dialog-title">{'Confirm Deletion'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to delete this conversation? All associated
            messages will be deleted as well.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            variant="contained"
            color="error"
            onClick={() => handleConfirmClick()}
          >
            Delete
          </Button>
          <Button
            variant="contained"
            onClick={handleConfirmClose}
          >
            Cancel
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
