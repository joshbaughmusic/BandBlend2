import DeleteIcon from '@mui/icons-material/Delete';
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  IconButton,
  Button,
  Snackbar,
  Alert,
} from '@mui/material';
import { useState } from 'react';
import { fetchDeletePost } from '../../managers/postsManager.js';
import { useSnackBar } from '../context/SnackBarContext.js';

export const DeletePost = ({ postId, getUserPosts }) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const {
    handleSnackBarOpen,
    setSnackBarMessage,
    setSuccessAlert,
  } = useSnackBar();

  const handleDeleteClick = () => {
    setConfirmOpen(true);
  };

  const handleConfirmClick = () => {
    fetchDeletePost(postId).then((res) => {
      if (res.status === 204) {
        getUserPosts();
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('Post successfully deleted!');
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete post.');
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  return (
    <>
      <IconButton onClick={handleDeleteClick}>
        <DeleteIcon />
      </IconButton>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">
          {'Confirm Post Deletion'}
        </DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to delete this post?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={handleConfirmClose}>Cancel</Button>
          <Button onClick={() => handleConfirmClick()}>Confirm</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
