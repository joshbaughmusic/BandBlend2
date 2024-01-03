import { useEffect, useState } from 'react';
import {
  fetchCreateUserFeedPrimaryGenre,
  fetchDeleteUserFeedPrimaryGenre,
  fetchUserFeedPrimaryGenres,
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
  useMediaQuery,
} from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { fetchPrimaryGenres } from '../../../../managers/primaryGenresManager.js';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import CloseIcon from '@mui/icons-material/Close';
import { useTheme } from '@emotion/react';


export const AdminFeedPrimaryGenres = () => {
  const [feedPrimaryGenres, setFeedPrimaryGenres] = useState();
  const [primaryGenres, setPrimaryGenres] = useState();
  const [selectedPrimaryGenres, setSelectedPrimaryGenres] = useState(
    []
  );
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [openModal, setOpenModal] = useState(false);

  const getUserFeedPrimaryGenresAndPrimaryGenres = async () => {
    const userFeedPrimaryGenresData =
      await fetchUserFeedPrimaryGenres();
    setFeedPrimaryGenres(userFeedPrimaryGenresData);
    const primaryGenresData = await fetchPrimaryGenres();
    setPrimaryGenres(
      primaryGenresData.filter(
        (pi) =>
          !userFeedPrimaryGenresData.some(
            (ufpi) => pi.id == ufpi.primaryGenreId
          )
      )
    );
  };

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
    getUserFeedPrimaryGenresAndPrimaryGenres();
  }, []);

  const handleModalClose = () => {
    if (selectedPrimaryGenres.length > 0) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };
  const handleSubmit = () => {
    fetchCreateUserFeedPrimaryGenre(selectedPrimaryGenres).then(
      (res) => {
        if (res.status === 204) {
          getUserFeedPrimaryGenresAndPrimaryGenres();
          setSelectedPrimaryGenres([]);
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
    setSelectedPrimaryGenres([]);
  };

  const handleCheck = (e) => {
    const primaryGenreId = parseInt(e.target.value);

    setSelectedPrimaryGenres((prevSelectedPrimaryGenres) => {
      if (e.target.checked) {
        return [...prevSelectedPrimaryGenres, primaryGenreId];
      } else {
        return prevSelectedPrimaryGenres.filter(
          (id) => id !== primaryGenreId
        );
      }
    });
  };

  const handleDelete = (primaryGenreId) => {
    fetchDeleteUserFeedPrimaryGenre(primaryGenreId).then(() => {
      getUserFeedPrimaryGenresAndPrimaryGenres();
    });
  };

  if (!feedPrimaryGenres || !primaryGenres) {
    return (
      <>
        <div className="feedSettingsItem-container">
          <Typography variant="h6">Followed Genres:</Typography>
          <Tooltip
            title="Follow New Genre"
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
        <Typography variant="h6">Followed Genres:</Typography>
        <Tooltip
          title="Follow New Genre"
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
        {feedPrimaryGenres.length === 0 ? (
          <Typography sx={{ mt: '4px' }}>No followed genres</Typography>
        ) : (
          feedPrimaryGenres.map((fs, index) => (
            <Chip
              key={index}
              label={fs.primaryGenre.name}
              onDelete={() => handleDelete(fs.primaryGenre.id)}
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
                Follow New Genres
              </Typography>
              <IconButton onClick={handleModalClose}>
                <CloseIcon />
              </IconButton>
            </div>
            <Divider />
          </div>
          <FormGroup>
            {primaryGenres.map((s, index) =>
              feedPrimaryGenres.some((fs) => fs.id === s.id) ? null : (
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
            onClick={() => handleConfirmClose()}
            color="error"
          >
            Discard Changes
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
