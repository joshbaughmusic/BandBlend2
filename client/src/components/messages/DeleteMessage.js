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
import { fetchDeleteMessage } from '../../managers/messagesManager.js';

export const DeleteMessage = ({ messageId }) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const {
    setActiveConversationId,
    setNewMessageView,
    setSelectedRecipient,
    getMyMessagesByConversation,
    getMyConversations,
  } = useMessages();

  const handleDeleteClick = () => {
    setConfirmOpen(true);
  };

  const handleConfirmClick = () => {
    fetchDeleteMessage(messageId).then((res) => {
      if (res.status === 204) {
        const result = res.headers.get('Result');
        if (result == 'Deleted conversation') {
          getMyConversations();
          setActiveConversationId(null);
          setSelectedRecipient(null);
          setNewMessageView(true);
          handleConfirmClose();
          setSuccessAlert(true);
          setSnackBarMessage('Message successfully deleted!');
          handleSnackBarOpen(true);
        } else {
          getMyMessagesByConversation();
          handleConfirmClose();
          setSuccessAlert(true);
          setSnackBarMessage('Message successfully deleted!');
          handleSnackBarOpen(true);
        }
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete message.');
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  return (
    <>
      <Tooltip
        title="Delete"
        placement="left"
      >
        <IconButton
          sx={{ p: '5px' }}
          onClick={handleDeleteClick}
        >
          <DeleteIcon sx={{ width: '20px' }} />
        </IconButton>
      </Tooltip>
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
            Are you sure you want to delete this messaage?
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
