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

export const DeletePost = ({ postId, getUserPosts }) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const [successAlert, setSuccessAlert] = useState(false);
  const [snackBarOpen, setSnackBarOpen] = useState(false);

  const handleDeleteClick = () => {
    setConfirmOpen(true);
  };

  const handleConfirmClick = () => {
    fetchDeletePost(postId).then((res) => {
      if (res.status === 204) {
        getUserPosts();
        handleConfirmClose();
        setSuccessAlert(true)
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  const handleSnackBarOpen = () => {
    setSnackBarOpen(true);
  };

  const handleSnackBarClose = (event, reason) => {
    if (reason === 'clickaway') {
      return;
    }

    setSnackBarOpen(false);
  };

  return (
    <>
      <IconButton onClick={handleDeleteClick}>
        <DeleteIcon />
      </IconButton>
      {successAlert ? (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={6000}
          onClose={handleSnackBarClose}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="success"
            sx={{ width: '100%' }}
          >
            Post deleted successfully!
          </Alert>
        </Snackbar>
      ) : (
        <Snackbar
          open={snackBarOpen}
          autoHideDuration={6000}
          onClose={handleSnackBarClose}
        >
          <Alert
            onClose={handleSnackBarClose}
            severity="error"
            sx={{ width: '100%' }}
          >
            Failed to delete post.
          </Alert>
        </Snackbar>
      )}
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
