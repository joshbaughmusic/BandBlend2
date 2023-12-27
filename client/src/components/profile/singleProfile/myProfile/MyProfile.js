import {
  Avatar,
  Button,
  Chip,
  Container,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Divider,
  Grid,
  IconButton,
  Paper,
  TextField,
  Tooltip,
  Typography,
} from '@mui/material';
import { useEffect, useState } from 'react';
import {
  fetchCurrentUserWithProfile,
  fetchEditAbout,
  fetchEditProfilePicture,
} from '../../../../managers/profileManager.js';
import '../SingleProfile.css';
import SpotifyLogo from '../../../../images/SocialMediaLogos/spotify.png';
import FacebookLogo from '../../../../images/SocialMediaLogos/facebook.png';
import InstagramLogo from '../../../../images/SocialMediaLogos/instagram.png';
import TikTokLogo from '../../../../images/SocialMediaLogos/tiktok.png';
import { Link } from 'react-router-dom';
import { MyPosts } from '../../../posts/myPosts/MyPosts.js';
import EditIcon from '@mui/icons-material/Edit';
import LocalPoliceIcon from '@mui/icons-material/LocalPolice';
import { MyAdditionalPhotos } from '../../../additonalPhotos/myAdditionalPhotos/MyAdditionalPhotos.js';
import { EditPrimaryInfo } from './EditPrimaryInfo.js';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import { EditTags } from './EditTags.js';
import { EditSubGenres } from './EditSubGenres.js';
import styled from '@emotion/styled';
import axios from 'axios';

const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});

export const MyProfile = ({ loggedInUser }) => {
  const [profile, setProfile] = useState();
  const [updatedAbout, setUpdatedAbout] = useState();
  const [editAboutState, setEditAboutState] = useState(false);
  const [error, setError] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const [picPopUp, setPicPopUp] = useState(null);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();

  const getCurrentUserWithProfile = () => {
    fetchCurrentUserWithProfile().then((res) => {
      setProfile(res);
      setUpdatedAbout(res.profile.about);
    });
  };

  useEffect(() => {
    getCurrentUserWithProfile();
  }, []);

  const handleCloseAboutEdit = () => {
    if (updatedAbout !== profile.profile.about) {
      setConfirmOpen(true);
    } else {
      setEditAboutState(false);
    }
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
    setError(false);
    setEditAboutState(false);
    setUpdatedAbout(profile.profile.about);
  };

  const handleUpload = async (e) => {
    const formData = new FormData();
    formData.append('file', e.target.files[0]);
    formData.append('upload_preset', 'unsigned');
    await axios
      .post('https://api.cloudinary.com/v1_1/dfanwgskl/image/upload', formData)
      .then((response) => {
        fetchEditProfilePicture(response.data['secure_url']).then((res) => {
          e.target.value = '';
          if (res.status === 204) {
            getCurrentUserWithProfile();
            setSuccessAlert(true);
            setSnackBarMessage('Profile photo successfully updated!');
            handleSnackBarOpen(true);
          } else {
            setSuccessAlert(false);
            setSnackBarMessage('Failed to update profile photo.');
            handleSnackBarOpen(true);
          }
        });
      });
  };

  const handleSubmit = () => {
    setError(false);
    if (updatedAbout.length > 0) {
      fetchEditAbout(profile.id, updatedAbout).then((res) => {
        if (res.status === 204) {
          getCurrentUserWithProfile();
          setSuccessAlert(true);
          setSnackBarMessage('About successfully edited!');
          handleConfirmClose();
          handleSnackBarOpen(true);
        } else {
          setSuccessAlert(false);
          setSnackBarMessage('Failed to edit about.');
          handleSnackBarOpen(true);
        }
      });
    } else {
      setError(true);
      setSuccessAlert(false);
      setSnackBarMessage('About must not be empty.');
      handleSnackBarOpen(true);
    }
  };

  if (!profile) {
    return null;
  }

  return (
    <>
      <Container className="profile-container-all">
        <Grid container>
          <Grid
            item
            xs={12}
            md={3}
          >
            <Paper
              className="profile-left-sidebar"
            >
              <div className="myProfilePicture-container">
                <div className="editProfilePic-button">
                  <Tooltip
                    title="Edit Profile Picture"
                    placement="right-start"
                  >
                    <IconButton
                      component="label"
                      variant="contained"
                    >
                      <EditIcon />
                      <VisuallyHiddenInput
                        type="file"
                        accept="image"
                        onChange={handleUpload}
                      />
                    </IconButton>
                  </Tooltip>
                </div>

                {profile.profile.profilePicture ? (
                  <div
                    className="photoItem-primary"
                    onClick={() => setPicPopUp(profile.profile.profilePicture)}
                    style={{ marginBottom: '4px' }}
                  >
                    <img
                      className="profilePic"
                      src={profile.profile.profilePicture}
                      alt={profile.name}
                    />
                  </div>
                ) : (
                  <Avatar sx={{ width: '125px', height: '125px' }}></Avatar>
                )}
              </div>

              {picPopUp ? (
                <div className="popup-media">
                  <span onClick={() => setPicPopUp(null)}>&times;</span>
                  <img
                    className="popup-photoItem"
                    src={picPopUp}
                    alt="An enlarged photo"
                  />
                </div>
              ) : (
                ''
              )}
              {profile.roles.includes('Admin') ? (
                <div
                  className="profileName-adminContainer"
                  style={{ marginBottom: '4px' }}
                >
                  <Typography
                    variant="h5"
                    component="h1"
                    sx={{ textAlign: 'center' }}
                  >
                    {profile.name}
                  </Typography>
                  <Tooltip
                    title="Admin account"
                    placement="top-start"
                  >
                    <LocalPoliceIcon sx={{ width: '20px' }} />
                  </Tooltip>
                </div>
              ) : (
                <div style={{ marginBottom: '4px' }}>
                  <Typography
                    variant="h5"
                    component="h1"
                    sx={{ textAlign: 'center' }}
                  >
                    {profile.name}
                  </Typography>
                </div>
              )}
              {profile.isBand ? (
                <Typography>Band</Typography>
              ) : (
                <Typography>Musician</Typography>
              )}
              <div
                className="socialmedia-icons-container"
                style={{ marginTop: '4px', marginBottom: '4px' }}
              >
                {profile.profile.spotifyLink ? (
                  <Link to={profile.profile.spotifyLink}>
                    <img
                      className="socialmedia-icon"
                      src={SpotifyLogo}
                      alt="spotify"
                    />
                  </Link>
                ) : null}
                {profile.profile.facebookLink ? (
                  <Link to={profile.profile.facebookLink}>
                    <img
                      className="socialmedia-icon"
                      src={FacebookLogo}
                      alt="facebook"
                    />
                  </Link>
                ) : null}
                {profile.profile.instagramLink ? (
                  <Link to={profile.profile.instagramLink}>
                    <img
                      className="socialmedia-icon"
                      src={InstagramLogo}
                      alt="instagram"
                    />
                  </Link>
                ) : null}
                {profile.profile.tikTokLink ? (
                  <Link to={profile.profile.tikTokLink}>
                    <img
                      className="socialmedia-icon"
                      src={TikTokLogo}
                      alt="tikTok"
                    />
                  </Link>
                ) : null}
              </div>
              <Typography>
                {profile.profile.city}, {profile.profile.state.name}
              </Typography>
              {profile.isBand ? null : (
                <div className="chip-section">
                  <Typography textAlign="center">Primary Instrument</Typography>
                  <Chip
                    label={profile.profile.primaryInstrument.name}
                    style={{
                      marginTop: '4px',
                    }}
                  />
                </div>
              )}
              <div className="chip-section">
                <Typography>Primary Genre</Typography>
                <Chip
                  label={profile.profile.primaryGenre.name}
                  style={{
                    marginTop: '4px',
                  }}
                />
              </div>

              <div className="chip-section">
                <div className="tags-subgenres-header">
                  <Typography>Tags</Typography>
                  <EditTags
                    getCurrentUserWithProfile={getCurrentUserWithProfile}
                    profile={profile}
                  />
                </div>
                <div className="chip-multi-container">
                  {profile.profile.profileTags.map((pt, index) => (
                    <Chip
                      key={index}
                      label={pt.tag.name}
                      style={{
                        marginTop: '4px',
                      }}
                    />
                  ))}
                </div>
              </div>
              <div className="chip-section">
                <div className="tags-subgenres-header">
                  <Typography>SubGenres</Typography>
                  <EditSubGenres
                    getCurrentUserWithProfile={getCurrentUserWithProfile}
                    profile={profile}
                  />
                </div>
                <div className="chip-multi-container">
                  {profile.profile.profileSubGenres.map((ps, index) => (
                    <Chip
                      key={index}
                      label={ps.subGenre.name}
                      style={{
                        marginTop: '4px',
                      }}
                    />
                  ))}
                </div>
              </div>
              <EditPrimaryInfo
                profile={profile}
                getCurrentUserWithProfile={getCurrentUserWithProfile}
              />
            </Paper>
          </Grid>
          <Grid
            item
            xs={12}
            md={9}
          >
            <div className="profile-right-section">
              <Paper
                  className="profile-right-section-item"
              >
                <div className="divider-header-container">
                  <div className="profile-section-header">
                    <Typography variant="h6">About</Typography>
                    {editAboutState ? (
                      <IconButton onClick={() => handleCloseAboutEdit()}>
                        <CloseIcon />
                      </IconButton>
                    ) : (
                      <Tooltip
                        title="Edit"
                        placement="left-start"
                      >
                        <IconButton
                          onClick={() => setEditAboutState(!editAboutState)}
                        >
                          <EditIcon />
                        </IconButton>
                      </Tooltip>
                    )}
                  </div>
                  <Divider style={{ marginTop: '4px' }} />
                </div>
                {editAboutState ? (
                  <>
                    <TextField
                      className="about-text-field"
                      label="Edit About"
                      multiline
                      minRows={5}
                      fullWidth
                      autoFocus={true}
                      value={updatedAbout}
                      onChange={(e) => setUpdatedAbout(e.target.value)}
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
                  </>
                ) : profile.profile.about === null ? (
                  <Typography>No about written yet!</Typography>
                ) : (
                  <Typography>{profile.profile.about}</Typography>
                )}
              </Paper>
              <Paper
                  className="profile-right-section-item"
              >
                <MyAdditionalPhotos profile={profile} />
              </Paper>
              <Paper
                  className="profile-right-section-item"
              >
                <MyPosts
                  profile={profile}
                  loggedInUser={loggedInUser}
                />
              </Paper>
            </div>
          </Grid>
        </Grid>
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
