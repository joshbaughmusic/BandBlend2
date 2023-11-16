import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from '@mui/material';
import '../AdditionalPhotos.css';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../context/SnackBarContext.js';
import { useState } from 'react';
import { fetchDeleteAdditionalPhoto } from '../../../managers/additonalPhotosManager.js';


export const MyAdditionalPhotosItem = ({ photo, getMyAdditonalPhotos }) => {
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const handleConfirmClick = () => {
    fetchDeleteAdditionalPhoto(photo.id).then((res) => {
      if (res.status === 204) {
        getMyAdditonalPhotos();
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
        />
        <div className="deletePic-X">
          <CloseIcon onClick={() => setConfirmOpen(true)} />
        </div>
      </div>
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{'Confirm Deletion'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to delete this photo?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => handleConfirmClick()}>Delete</Button>
          <Button onClick={handleConfirmClose}>Cancel</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
