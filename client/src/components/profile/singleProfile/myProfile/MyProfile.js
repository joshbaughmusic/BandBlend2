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
} from '../../../../managers/profileManager.js';
import '../SingleProfile.css';
import SpotifyLogo from '../../../../images/SocialMediaLogos/spotify.png';
import FacebookLogo from '../../../../images/SocialMediaLogos/facebook.png';
import InstagramLogo from '../../../../images/SocialMediaLogos/instagram.png';
import TikTokLogo from '../../../../images/SocialMediaLogos/spotify.png';
import { Link } from 'react-router-dom';
import { MyPosts } from '../../../posts/myPosts/MyPosts.js';
import EditIcon from '@mui/icons-material/Edit';
import { MyAdditionalPhotos } from '../../../additonalPhotos/myAdditionalPhotos/MyAdditionalPhotos.js';
import { EditPrimaryInfo } from './EditPrimaryInfo.js';
import CloseIcon from '@mui/icons-material/Close';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import { EditTags } from './EditTags.js';
import { EditSubGenres } from './EditSubGenres.js';

export const MyProfile = () => {
  const [profile, setProfile] = useState();
  const [updatedAbout, setUpdatedAbout] = useState();
  const [editAboutState, setEditAboutState] = useState(false);
  const [error, setError] = useState(false);
  const [confirmOpen, setConfirmOpen] = useState(false);
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

  const handleSubmit = () => {
    setError(false);
    if (updatedAbout.length > 0) {
      fetchEditAbout(profile.profile.id, updatedAbout).then((res) => {
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
      <Container>
        <Grid container>
          <Grid
            item
            xs={12}
            md={3}
          >
            <Paper
              elevation={4}
              className="profile-left-sidebar"
            >
              <Avatar
                className="single-profile-pic"
                src={profile.profile.profilePicture}
                alt={profile.name}
                sx={{ width: '125px', height: '125px' }}
              />
              <Typography
                variant="h5"
                component="h1"
              >
                {profile.name}
              </Typography>
              {profile.isBand ? (
                <Typography>Band</Typography>
              ) : (
                <Typography>Musician</Typography>
              )}
              <div className="socialmedia-icons-container">
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
                  <Typography>Primary Instrument</Typography>
                  <Chip label={profile.profile.primaryInstrument.name} />
                </div>
              )}
              <div className="chip-section">
                <Typography>Primary Genre</Typography>
                <Chip label={profile.profile.primaryGenre.name} />
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
                    />
                  ))}
                </div>
                <Button variant="contained">Edit SubGenres</Button>
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
                elevation={4}
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
                        placement="right-start"
                      >
                        <IconButton
                          onClick={() => setEditAboutState(!editAboutState)}
                        >
                          <EditIcon />
                        </IconButton>
                      </Tooltip>
                    )}
                  </div>
                  <Divider />
                </div>
                {editAboutState ? (
                  <>
                    <TextField
                      className="about-text-field"
                      label="Edit About"
                      multiline
                      minRows={5}
                      fullWidth
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
                ) : (
                  <Typography>{profile.profile.about}</Typography>
                )}
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <div className="divider-header-container">
                  <Typography variant="h6">Additional Photos</Typography>
                  <Divider />
                </div>
                <MyAdditionalPhotos profile={profile} />
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <MyPosts profile={profile} />
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
