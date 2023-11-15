import { useEffect, useState } from 'react';
import {
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Divider,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  Select,
  Stack,
  TextField,
  Modal,
  Typography,
  Button,
  Box,
} from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import { fetchStates } from '../../../../managers/statesManager.js';
import { fetchPrimaryGenres } from '../../../../managers/primaryGenresManager.js';
import { fetchPrimaryInstruments } from '../../../../managers/primaryInstrumentsManager.js';
import { fetchEditPrimaryInfo } from '../../../../managers/profileManager.js';

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
};

export const EditPrimaryInfo = ({ profile, getCurrentUserWithProfile }) => {
  const [profileToEdit, setProfileToEdit] = useState({
    id: profile.profile.id,
    userProfileId: profile.profile.userProfileId,
    profilePicture: profile.profile.profilePicture,
    city: profile.profile.city,
    stateId: profile.profile.stateId,
    about: profile.profile.about,
    primaryGenreId: profile.profile.primaryGenreId,
    primaryInstrumentId: profile.profile.primaryInstrumentId,
    spotifyLink: profile.profile.spotifyLink,
    facebookLink: profile.profile.facebookLink,
    instagramLink: profile.profile.instagramLink,
    tikTokLink: profile.profile.tikTokLink,
  });
  const [cityFieldError, setCityFieldError] = useState(false);
  const [openModal, setOpenModal] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const [usStates, setUsStates] = useState();
  const [primaryGenres, setPrimaryGenres] = useState();
  const [primaryInstruments, setPrimaryInstruments] = useState();
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getDropDowns = () => {
    fetchStates().then(setUsStates);
    fetchPrimaryGenres().then(setPrimaryGenres);
    fetchPrimaryInstruments().then(setPrimaryInstruments);
  };

  useEffect(() => {
    getDropDowns();
  }, []);

  useEffect(() => {
    setProfileToEdit({
      id: profile.profile.id,
      userProfileId: profile.profile.userProfileId,
      profilePicture: profile.profile.profilePicture,
      city: profile.profile.city,
      stateId: profile.profile.stateId,
      about: profile.profile.about,
      primaryGenreId: profile.profile.primaryGenreId,
      primaryInstrumentId: profile.profile.primaryInstrumentId,
      spotifyLink: profile.profile.spotifyLink,
      facebookLink: profile.profile.facebookLink,
      instagramLink: profile.profile.instagramLink,
      tikTokLink: profile.profile.tikTokLink,
    });
  }, [profile]);

  const handleChange = (e) => {
    setProfileToEdit({
      ...profileToEdit,
      [e.target.name]: e.target.value,
    });
  };

  const handleModalOpen = () => setOpenModal(true);

  const handleModalClose = () => {
    if (
      profileToEdit.city !== profile.profile.city ||
      profileToEdit.stateId !== profile.profile.stateId ||
      profileToEdit.primaryGenreId !== profile.profile.primaryGenreId ||
      profileToEdit.primaryInstrumentId !==
        profile.profile.primaryInstrumentId ||
      profileToEdit.spotifyLink !== profile.profile.spotifyLink ||
      profileToEdit.facebookLink !== profile.profile.facebookLink ||
      profileToEdit.instagramLink !== profile.profile.instagramLink ||
      profileToEdit.tikTokLink !== profile.profile.tikTokLink
    ) {
      setConfirmOpen(true);
    } else {
      setOpenModal(false);
    }
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setOpenModal(false);
    setProfileToEdit({
      id: profile.profile.id,
      userProfileId: profile.profile.userProfileId,
      profilePicture: profile.profile.profilePicture,
      city: profile.profile.city,
      stateId: profile.profile.stateId,
      about: profile.profile.about,
      primaryGenreId: profile.profile.primaryGenreId,
      primaryInstrumentId: profile.profile.primaryInstrumentId,
      spotifyLink: profile.profile.spotifyLink,
      facebookLink: profile.profile.facebookLink,
      instagramLink: profile.profile.instagramLink,
      tikTokLink: profile.profile.tikTokLink,
    });
    setCityFieldError(false);
  };

  const handleSubmit = () => {
    setCityFieldError(false);
    if (profileToEdit.city.length > 0) {
      fetchEditPrimaryInfo(profile.id, profileToEdit).then((res) => {
        if (res.status === 204) {
          getCurrentUserWithProfile();
          setSuccessAlert(true);
          setSnackBarMessage('Profile successfully updated!');
          handleConfirmClose();
          handleSnackBarOpen(true);
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to update profile.');
          handleSnackBarOpen(true);
        }
      });
    } else {
      setCityFieldError(true);
      setSuccessAlert(false);
      setSnackBarMessage('City name must not be empty.');
      handleSnackBarOpen(true);
    }
  };

  if (!usStates || !primaryGenres || !primaryInstruments) {
    return (
      <>
        <Button
          variant="contained"
          onClick={handleModalOpen}
        >
          Edit Primary Info
        </Button>
      </>
    );
  }
  return (
    <>
      <div>
        <Button
          variant="contained"
          onClick={handleModalOpen}
        >
          Edit Primary Info
        </Button>
        <div>
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
                    Edit Primary Info
                  </Typography>
                  <IconButton onClick={handleModalClose}>
                    <CloseIcon />
                  </IconButton>
                </div>
                <Divider />
              </div>
              <Stack
                component="form"
                sx={{
                  width: '100%',
                }}
                spacing={2}
                noValidate
                autoComplete="off"
              >
                <FormControl fullWidth>
                  <TextField
                    id="city"
                    label="City"
                    variant="outlined"
                    value={profileToEdit.city}
                    name="city"
                    onChange={handleChange}
                    error={cityFieldError}
                  />
                </FormControl>
                <FormControl fullWidth>
                  <InputLabel id="states-label">State</InputLabel>
                  <Select
                    labelId="states-label"
                    id="states-label"
                    value={profileToEdit.stateId}
                    label="State"
                    name="stateId"
                    onChange={handleChange}
                  >
                    {usStates.map((s, index) => (
                      <MenuItem
                        key={index}
                        value={s.id}
                      >
                        {s.name}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <FormControl fullWidth>
                  <InputLabel id="primaryGenres-label">PrimaryGenre</InputLabel>
                  <Select
                    labelId="primaryGenres-label"
                    id="primaryGenres-label"
                    value={profileToEdit.primaryGenreId}
                    label="PrimaryGenre"
                    name="primaryGenreId"
                    onChange={handleChange}
                  >
                    {primaryGenres.map((pg, index) => (
                      <MenuItem
                        key={index}
                        value={pg.id}
                      >
                        {pg.name}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <FormControl fullWidth>
                  <InputLabel id="primaryInstruments-label">
                    PrimaryInstrument
                  </InputLabel>
                  <Select
                    labelId="primaryInstruments-label"
                    id="primaryInstruments-label"
                    value={profileToEdit.primaryInstrumentId}
                    label="PrimaryInstrument"
                    name="primaryInstrumentId"
                    onChange={handleChange}
                  >
                    {primaryInstruments.map((s, index) => (
                      <MenuItem
                        key={index}
                        value={s.id}
                      >
                        {s.name}
                      </MenuItem>
                    ))}
                  </Select>
                </FormControl>
                <FormControl fullWidth>
                  <TextField
                    id="spotify"
                    label="Spotify (optional)"
                    variant="outlined"
                    value={profileToEdit.spotifyLink}
                    name="spotifyLink"
                    onChange={handleChange}
                  />
                </FormControl>
                <FormControl fullWidth>
                  <TextField
                    id="facebook"
                    label="Facebook (optional)"
                    variant="outlined"
                    value={profileToEdit.facebookLink}
                    name="facebookLink"
                    onChange={handleChange}
                  />
                </FormControl>
                <FormControl fullWidth>
                  <TextField
                    id="instagram"
                    label="Instagram (optional)"
                    variant="outlined"
                    value={profileToEdit.instagramLink}
                    name="instagramLink"
                    onChange={handleChange}
                  />
                </FormControl>
                <FormControl fullWidth>
                  <TextField
                    id="tikTok"
                    label="TikTok (optional)"
                    variant="outlined"
                    value={profileToEdit.tikTokLink}
                    name="tikTokLink"
                    onChange={handleChange}
                  />
                </FormControl>
              </Stack>

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
        >
          <DialogTitle id="alert-dialog-title">
            {'Discard Changes?'}
          </DialogTitle>
          <DialogContent>
            <DialogContentText id="alert-dialog-description">
              Are you sure you want to discard your changes?
            </DialogContentText>
          </DialogContent>
          <DialogActions>
            <Button onClick={() => handleConfirmClose()}>
              Discard Changes
            </Button>
            <Button onClick={() => setConfirmOpen(false)}>Cancel</Button>
          </DialogActions>
        </Dialog>
      </div>
    </>
  );
};
