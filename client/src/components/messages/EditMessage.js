import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  IconButton,
  Button,
  Box,
  Typography,
  Modal,
  Divider,
  TextField,
  Tooltip,
  useMediaQuery,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { useSnackBar } from '../context/SnackBarContext.js';
import CloseIcon from '@mui/icons-material/Close';
import EditIcon from '@mui/icons-material/Edit';
import { fetchEditMessage } from '../../managers/messagesManager.js';
import { useMessages } from '../context/MessagesContext.js';
import { useTheme } from '@emotion/react';


export const EditMessage = ({ message }) => {
  const [messageBodyToEdit, setMessageBodyToEdit] = useState(message.body);
  const [error, setError] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const { getMyMessagesByConversation } = useMessages();
  const [openModal, setOpenModal] = useState(false);

  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  let style;

  if (mediaQuerySmall) {
    style = {
      position: 'absolute',
      top: '50%',
      left: '50%',
      transform: 'translate(-50%, -50%)',
      width: '90%',
      bgcolor: 'background.paper',
      border: '2px solid #000',
      boxShadow: 24,
      p: 4,
      height: '60%',
      overflowY: 'auto',
    };
  } else {
    style = {
      position: 'absolute',
      top: '50%',
      left: '50%',
      transform: 'translate(-50%, -50%)',
      width: 500,
      bgcolor: 'background.paper',
      border: '2px solid #000',
      boxShadow: 24,
      p: 4,
      height: '60%',
      overflowY: 'auto',
    };
  }

  useEffect(() => {
    if (messageBodyToEdit.length !== 0) {
      setError(false);
    }
  }, [messageBodyToEdit]);

  const handleModalOpen = () => setOpenModal(true);

  const handleModalClose = () => {
    if (message.body !== messageBodyToEdit) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };
  const handleSubmit = () => {
    setError(false);
    if (messageBodyToEdit.length > 0) {
      fetchEditMessage(message.id, messageBodyToEdit).then((res) => {
        if (res.status === 204) {
          getMyMessagesByConversation();
          setSuccessAlert(true);
          setSnackBarMessage('Message successfully edited!');
          handleConfirmClose();
          handleSnackBarOpen(true);
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to edit message.');
          handleSnackBarOpen(true);
        }
      });
    } else {
      setError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Message must not be empty.');
      handleSnackBarOpen(true);
    }
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setMessageBodyToEdit(message.body);
    setError(false);
  };

  return (
    <>
      <Tooltip
        title="Edit"
        placement="right"
      >
        <IconButton onClick={handleModalOpen}>
          <EditIcon sx={{ width: '20px' }} />
        </IconButton>
      </Tooltip>
      <div>
        <Modal
          open={openModal}
          onClose={handleModalClose}
          aria-labelledby="modal-modal-title"
          aria-describedby="modal-modal-description"
          sx={{ marginBottom: '20vh' }}
        >
          <Box sx={style}>
            <div className="divider-header-container">
              <div className="modal-header">
                <Typography
                  id="modal-modal-title"
                  variant="h6"
                  component="h2"
                >
                  Edit Message
                </Typography>
                <IconButton onClick={handleModalClose}>
                  <CloseIcon />
                </IconButton>
              </div>
              <Divider />
            </div>
            <TextField
              className="message-text-field"
              multiline
              minRows={5}
              fullWidth
              label="Edit Message"
              value={messageBodyToEdit}
              onChange={(e) => setMessageBodyToEdit(e.target.value)}
              error={error}
            />
            <div className="message-submit-button-container">
              <Button
                variant="contained"
                onClick={handleSubmit}
                sx={{ mt: 2 }}
              >
                Submit
              </Button>
            </div>
          </Box>
        </Modal>
      </div>
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
            Are you sure you want to discard your changes?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button
            variant="contained"
            color="error"
            onClick={() => handleConfirmClose()}
          >
            Discard
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
