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
import { fetchDeleteComment } from '../../managers/commentsManager.js';

export const DeleteComment = ({ commentId, getCommentsForPost, getUserPosts }) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const handleDeleteClick = () => {
    setConfirmOpen(true);
  };

  const handleConfirmClick = () => {
    fetchDeleteComment(commentId).then((res) => {
      if (res.status === 204) {
        getCommentsForPost();
        getUserPosts();
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('Comment successfully deleted!');
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete comment.');
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
        placement="top"
      >
        <IconButton onClick={handleDeleteClick}>
          <DeleteIcon />
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
            Are you sure you want to delete this comment?
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
