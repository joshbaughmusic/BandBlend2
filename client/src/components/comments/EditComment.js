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
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  useMediaQuery,
} from '@mui/material';
import { useState } from 'react';
import { useSnackBar } from '../context/SnackBarContext.js';
import CloseIcon from '@mui/icons-material/Close';
import EditIcon from '@mui/icons-material/Edit';
import { fetchEditComment } from '../../managers/commentsManager.js';
import { useTheme } from '@emotion/react';

export const EditComment = ({ comment, getCommentsForPost }) => {
  const [commentBodyToEdit, setCommentBodyToEdit] = useState(comment.body);
  const [error, setError] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
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

  const handleModalOpen = () => setOpenModal(true);

  const handleModalClose = () => {
    if (comment.body !== commentBodyToEdit) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };
  const handleSubmit = () => {
    setError(false);
    if (commentBodyToEdit.length > 0) {
      fetchEditComment(comment.id, commentBodyToEdit).then((res) => {
        if (res.status === 204) {
          getCommentsForPost();
          setSuccessAlert(true);
          setSnackBarMessage('Comment successfully edited!');
          handleConfirmClose();
          handleSnackBarOpen(true);
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to edit comment.');
          handleSnackBarOpen(true);
        }
      });
    } else {
      setError(true);
      setSuccessAlert(false);
      setSnackBarMessage('Comment must not be empty.');
      handleSnackBarOpen(true);
    }
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setCommentBodyToEdit(comment.body);
    setError(false);
  };

  return (
    <>
      <ListItem disablePadding>
        <ListItemButton onClick={handleModalOpen}>
          <ListItemIcon>
            <EditIcon />
          </ListItemIcon>
          <ListItemText primary="Edit" />
        </ListItemButton>
      </ListItem>
      
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
                  Edit Comment
                </Typography>
                <IconButton onClick={handleModalClose}>
                  <CloseIcon />
                </IconButton>
              </div>
              <Divider />
            </div>
            <TextField
              className="comment-text-field"
              multiline
              minRows={5}
              fullWidth
              label="Edit Comment"
              value={commentBodyToEdit}
              onChange={(e) => setCommentBodyToEdit(e.target.value)}
              error={error}
            />
            <div className="post-submit-button-container">
              <Button
                variant="contained"
                onClick={handleSubmit}
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
