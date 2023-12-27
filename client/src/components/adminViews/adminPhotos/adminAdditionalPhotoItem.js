import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../context/SnackBarContext.js';
import { useState } from 'react';
import { fetchAdminDeleteOtherAdditionalPhoto } from '../../../managers/adminFunctionsManager.js';

export const AdminAdditionalPhotosItem = ({
  photo,
  getOtherAdditonalPhotos,
}) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [picPopUp, setPicPopUp] = useState(null);

  const handleConfirmClick = () => {
    fetchAdminDeleteOtherAdditionalPhoto(photo.id).then((res) => {
      if (res.status === 204) {
        getOtherAdditonalPhotos();
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('Photo successfully deleted!');
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete photo.');
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  return (
    <>
      <div className="photoItem">
        <img
          className="additional-photo"
          src={photo.url}
          alt="picture"
          onClick={() => setPicPopUp(photo)}
        />
        <div className="deletePic-X">
          <CloseIcon onClick={() => setConfirmOpen(true)} />
        </div>
      </div>
      {picPopUp ? (
        <div className="popup-media">
          <span onClick={() => setPicPopUp(null)}>&times;</span>
          <img
            className="popup-photoItem"
            src={picPopUp?.url}
            alt="An enlarged photo"
          />
        </div>
      ) : (
        ''
      )}
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
            Are you sure you want to delete this photo?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            variant="contained"
            onClick={() => handleConfirmClick()}
            color="error"
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
