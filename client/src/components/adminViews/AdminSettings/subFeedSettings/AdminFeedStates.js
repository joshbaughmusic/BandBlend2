import { useEffect, useState } from 'react';
import {
  fetchCreateUserFeedState,
  fetchDeleteUserFeedState,
  fetchUserFeedStates,
} from '../../../../managers/feedManager.js';
import {
  Box,
  Button,
  Checkbox,
  Chip,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Divider,
  FormControlLabel,
  FormGroup,
  IconButton,
  Modal,
  Skeleton,
  Stack,
  Tooltip,
  Typography,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { fetchStates } from '../../../../managers/statesManager.js';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import CloseIcon from '@mui/icons-material/Close';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: 400,
  bgcolor: 'background.paper',
  border: '2px solid #000',
  boxShadow: 24,
  p: 4,
  height: '50%',
  overflow: 'auto',
};

export const AdminFeedStates = () => {
  const [feedStates, setFeedStates] = useState();
  const [states, setStates] = useState();
  const [selectedStates, setSelectedStates] = useState([]);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [openModal, setOpenModal] = useState(false);

  const getUserFeedStatesAndStates = async () => {
    const userFeedStatesData = await fetchUserFeedStates();
    setFeedStates(userFeedStatesData);
    const statesData = await fetchStates();
    setStates(
      statesData.filter(
        (sd) => !userFeedStatesData.some((ufs) => sd.id == ufs.stateId)
      )
    );
  };

  useEffect(() => {
    getUserFeedStatesAndStates();
  }, []);

  const handleModalClose = () => {
    if (selectedStates.length > 0) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };
  const handleSubmit = () => {
    fetchCreateUserFeedState(selectedStates).then((res) => {
      if (res.status === 204) {
        getUserFeedStatesAndStates();
        setSelectedStates([]);
        setOpenModal(false);
        setSuccessAlert(true);
        setSnackBarMessage('Feed settings updated!');
        handleConfirmClose();
        handleSnackBarOpen(true);
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to update feed settings.');
        handleSnackBarOpen(true);
      }
    });
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setSelectedStates([]);
  };

  const handleCheck = (e) => {
    const stateId = parseInt(e.target.value);

    setSelectedStates((prevSelectedStates) => {
      if (e.target.checked) {
        return [...prevSelectedStates, stateId];
      } else {
        return prevSelectedStates.filter((id) => id !== stateId);
      }
    });
  };

  const handleDelete = (stateId) => {
    fetchDeleteUserFeedState(stateId).then(() => {
      getUserFeedStatesAndStates();
    });
  };

  if (!feedStates || !states) {
    return (
      <>
        <div className="feedSettingsItem-container">
          <Typography variant="h6">Followed States:</Typography>
          <Tooltip
            title="Follow New State"
            placement="left-start"
          >
            <IconButton
              component="label"
              variant="contained"
            >
              <AddIcon />
            </IconButton>
          </Tooltip>
        </div>
        <Skeleton
          variant="rounded"
          width="100%"
          height={66}
        />
      </>
    );
  }

  return (
    <>
      <div className="feedSettingsItem-container">
        <Typography variant="h6">Followed States:</Typography>
        <Tooltip
          title="Follow New State"
          placement="left-start"
        >
          <IconButton
            component="label"
            variant="contained"
            onClick={() => setOpenModal(true)}
          >
            <AddIcon />
          </IconButton>
        </Tooltip>
      </div>
      <Box
        sx={{
          minHeight: "66px",
          border: 1,
          borderColor: 'divider',
          padding: 2,
          display: 'flex',
          flexDirection: 'row',
          flexWrap: 'wrap',
          gap: "15px",
          justifyContent: 'flex-start',
        }}
      >
        {feedStates.length === 0 ? 
        <Typography>No followed states!</Typography>
      :
        feedStates.map((fs, index) => (
          <Chip
            key={index}
            label={fs.state.name}
            onDelete={() => handleDelete(fs.state.id)}
            sx={{
              width: "70px"
            }}
          />
        ))
      }
      </Box>
      <Modal
        open={openModal}
        onClose={handleModalClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <div className="divider-header-container">
            <div className="modal-header">
              <Typography
                id="modal-modal-title"
                variant="h6"
                component="h2"
              >
                Follow New States
              </Typography>
              <IconButton onClick={handleModalClose}>
                <CloseIcon />
              </IconButton>
            </div>
            <Divider />
          </div>
          <FormGroup>
            {states.map((s, index) =>
              feedStates.some((fs) => fs.id === s.id) ? null : (
                <FormControlLabel
                  key={index}
                  control={<Checkbox />}
                  label={s.name}
                  onChange={handleCheck}
                  value={s.id}
                />
              )
            )}
            {/* ... other FormControlLabels ... */}
          </FormGroup>
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
      <Dialog
        open={confirmOpen}
        onClose={handleConfirmClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        <DialogTitle id="alert-dialog-title">{'Discard Changes?'}</DialogTitle>
        <DialogContent>
          <DialogContentText id="alert-dialog-description">
            Are you sure you want to discard your changes?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => handleConfirmClose()}>Discard Changes</Button>
          <Button onClick={() => setConfirmOpen(false)}>Cancel</Button>
        </DialogActions>
      </Dialog>
    </>
  );
};
