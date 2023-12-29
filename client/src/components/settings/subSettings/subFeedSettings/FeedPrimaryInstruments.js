import { useEffect, useState } from 'react';
import {
  fetchCreateUserFeedPrimaryInstrument,
  fetchDeleteUserFeedPrimaryInstrument,
  fetchUserFeedPrimaryInstruments,
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
  Tooltip,
  Typography,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { fetchPrimaryInstruments } from '../../../../managers/primaryInstrumentsManager.js';
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

export const FeedPrimaryInstruments = () => {
  const [feedPrimaryInstruments, setFeedPrimaryInstruments] = useState();
  const [primaryInstruments, setPrimaryInstruments] = useState();
  const [selectedPrimaryInstruments, setSelectedPrimaryInstruments] = useState(
    []
  );
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [openModal, setOpenModal] = useState(false);

  const getUserFeedPrimaryInstrumentsAndPrimaryInstruments = async () => {
    const userFeedPrimaryInstrumentsData =
      await fetchUserFeedPrimaryInstruments();
    setFeedPrimaryInstruments(userFeedPrimaryInstrumentsData);
    const primaryInstrumentsData = await fetchPrimaryInstruments();
    setPrimaryInstruments(
      primaryInstrumentsData.filter(
        (pi) =>
          !userFeedPrimaryInstrumentsData.some(
            (ufpi) => pi.id == ufpi.primaryInstrumentId
          )
      )
    );
  };

  useEffect(() => {
    getUserFeedPrimaryInstrumentsAndPrimaryInstruments();
  }, []);

  const handleModalClose = () => {
    if (selectedPrimaryInstruments.length > 0) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };
  const handleSubmit = () => {
    fetchCreateUserFeedPrimaryInstrument(selectedPrimaryInstruments).then(
      (res) => {
        if (res.status === 204) {
          getUserFeedPrimaryInstrumentsAndPrimaryInstruments();
          setSelectedPrimaryInstruments([]);
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
      }
    );
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setSelectedPrimaryInstruments([]);
  };

  const handleCheck = (e) => {
    const primaryInstrumentId = parseInt(e.target.value);

    setSelectedPrimaryInstruments((prevSelectedPrimaryInstruments) => {
      if (e.target.checked) {
        return [...prevSelectedPrimaryInstruments, primaryInstrumentId];
      } else {
        return prevSelectedPrimaryInstruments.filter(
          (id) => id !== primaryInstrumentId
        );
      }
    });
  };

  const handleDelete = (primaryInstrumentId) => {
    fetchDeleteUserFeedPrimaryInstrument(primaryInstrumentId).then(() => {
      getUserFeedPrimaryInstrumentsAndPrimaryInstruments();
    });
  };

  if (!feedPrimaryInstruments || !primaryInstruments) {
    return (
      <>
        <div className="feedSettingsItem-container">
          <Typography variant="h6">Followed Instruments:</Typography>
          <Tooltip
            title="Follow New PrimaryInstrument"
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
        <Typography variant="h6">Followed Instruments:</Typography>
        <Tooltip
          title="Follow New Instrument"
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
          minHeight: '66px',
          border: 1,
          borderColor: 'divider',
          padding: 2,
          display: 'flex',
          flexDirection: 'row',
          flexWrap: 'wrap',
          gap: '15px',
          justifyContent: 'flex-start',
        }}
      >
        {feedPrimaryInstruments.length === 0 ? (
          <Typography sx={{ mt: '4px' }}>No followed instruments</Typography>
        ) : (
          feedPrimaryInstruments.map((fs, index) => (
            <Chip
              key={index}
              label={fs.primaryInstrument.name}
              onDelete={() => handleDelete(fs.primaryInstrument.id)}
            />
          ))
        )}
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
                Follow New Instruments
              </Typography>
              <IconButton onClick={handleModalClose}>
                <CloseIcon />
              </IconButton>
            </div>
            <Divider />
          </div>
          <FormGroup>
            {primaryInstruments.map((s, index) =>
              feedPrimaryInstruments.some((fs) => fs.id === s.id) ? null : (
                <FormControlLabel
                  key={index}
                  control={<Checkbox />}
                  label={s.name}
                  onChange={handleCheck}
                  value={s.id}
                />
              )
            )}
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
