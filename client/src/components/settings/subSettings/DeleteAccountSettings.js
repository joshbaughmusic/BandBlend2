import {
  Button,
  Container,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Typography,
} from '@mui/material';
import { useSnackBar } from '../../context/SnackBarContext.js';
import { fetchDeleteMyUserProfile } from '../../../managers/profileManager.js';
import { useNavigate } from 'react-router-dom';
import { useState } from 'react';

export const DeleteAccountSettings = ({ setLoggedInUser }) => {
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [confirmOpen, setConfirmOpen] = useState(false);
  const navigate = useNavigate();

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  const handleDeleteMyProfile = () => {
    fetchDeleteMyUserProfile()
      .then((res) => {
        if (res.status !== 204) {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to delete account.');
          handleSnackBarOpen();
        } else {
          setLoggedInUser(null)
          handleConfirmClose();
          navigate('/login');
          setSuccessAlert(true);
          setSnackBarMessage('Successfully deleted account.');
          handleSnackBarOpen();
        }
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return (
    <>
      <Container>
        <div className="deleteaccount-container">
          <Button
            variant="contained"
            onClick={() => setConfirmOpen(true)}
            color="error"
          >
            Delete Account
          </Button>
        </div>
      </Container>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
        sx={{ marginBottom: '10vh' }}
      >
        <DialogTitle id="alert-dialog-title">{'Discard Changes?'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to delete your account? This will delete all
            of your profile data, posts, comments, etc. This is irreversible.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            variant="contained"
            onClick={() => handleDeleteMyProfile()}
          >
            Delete Account
          </Button>
          <Button
            variant="contained"
            onClick={() => setConfirmOpen(false)}
          >
            Cancel
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
