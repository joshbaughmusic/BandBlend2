import {
  Avatar,
  Box,
  Button,
  ButtonGroup,
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
  List,
  ListItem,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Paper,
  Popper,
  Tooltip,
  Typography,
} from '@mui/material';
import { useEffect, useState } from 'react';
import {
  fetchOtherUserWithProfile,
  fetchSaveProfile,
  fetchUnsaveProfile,
} from '../../../../managers/profileManager.js';
import '../SingleProfile.css';
import SpotifyLogo from '../../../../images/SocialMediaLogos/spotify.png';
import FacebookLogo from '../../../../images/SocialMediaLogos/facebook.png';
import InstagramLogo from '../../../../images/SocialMediaLogos/instagram.png';
import TikTokLogo from '../../../../images/SocialMediaLogos/tiktok.png';
import { Link, useNavigate, useParams } from 'react-router-dom';
import BookmarkIcon from '@mui/icons-material/Bookmark';
import BookmarkBorderIcon from '@mui/icons-material/BookmarkBorder';
import BlockIcon from '@mui/icons-material/Block';
import MailIcon from '@mui/icons-material/Mail';
import PersonAddAlt1Icon from '@mui/icons-material/PersonAddAlt1';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import DeleteIcon from '@mui/icons-material/Delete';
import { OtherPosts } from '../../../posts/otherPosts/OtherPosts.js';
import { OtherAdditionalPhotos } from '../../../additonalPhotos/otherAdditionalPhotos/OtherAdditionalPhotos.js';
import {
  fetchCreateUserFeedUser,
  fetchDeleteUserFeedUser,
  fetchUserFeedUsers,
} from '../../../../managers/feedManager.js';
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline';
import LocalPoliceIcon from '@mui/icons-material/LocalPolice';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import { fetchCreateNewBlockedAccount } from '../../../../managers/blockedAccountsManager.js';
import { useSnackBar } from '../../../context/SnackBarContext.js';
import {
  fetchAdminBanAccount,
  fetchAdminDeleteProfilePhoto,
  fetchAdminDeleteUserProfile,
  fetchPromoteToAdmin,
} from '../../../../managers/adminFunctionsManager.js';
import { useMessages } from '../../../context/MessagesContext.js';

export const OtherProfile = ({ loggedInUser }) => {
  const [profile, setProfile] = useState();
  const [userFeedUsers, setUserFeedUsers] = useState([]);
  const [picPopUp, setPicPopUp] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate();
  const [anchorEl, setAnchorEl] = useState(null);
  const [confirmOpen, setConfirmOpen] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const {
    setOpenMessages,
    setActiveConversationId,
    setNewMessageView,
    setSelectedRecipient,
    getMyConversations,
    conversations,
  } = useMessages();
  const [actionPicked, setActionPicked] = useState('');

  const getOtherUserWithProfile = () => {
    fetchOtherUserWithProfile(id).then((res) => {
      if (res.status === 400) {
        navigate('/profile/me');
      } else if (res.status === 401) {
        navigate('/');
      } else {
        setProfile(res);
      }
    });
  };

  const getUserFeedUsers = () => {
    fetchUserFeedUsers().then(setUserFeedUsers);
  };

  useEffect(() => {
    getOtherUserWithProfile();
    getUserFeedUsers();
  }, []);

  const handleSaveProfile = () => {
    fetchSaveProfile(profile.profile.id).then(() => getOtherUserWithProfile());
  };

  const handleUnsaveProfile = () => {
    fetchUnsaveProfile(profile.profile.id).then(() =>
      getOtherUserWithProfile()
    );
  };

  const handleProfilePictureDelete = () => {
    fetchAdminDeleteProfilePhoto(profile.profile.id).then((res) => {
      if (res.status === 204) {
        getOtherUserWithProfile();
        handleConfirmClose();
        setSuccessAlert(true);
        setSnackBarMessage('Successfully deleted photo.');
        handleSnackBarOpen();
      } else {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete photo.');
        handleSnackBarOpen();
      }
    });
  };

  const handleMessageClick = () => {
    setOpenMessages(true);
    const foundConversation = conversations.find(
      (c) => c.userProfileId === profile.id
    );

    if (foundConversation) {
      setActiveConversationId(foundConversation.id);
      setNewMessageView(false);
    } else {
      setSelectedRecipient(profile);
      setNewMessageView(true);
    }
  };

  const handleFollowUser = () => {
    fetchCreateUserFeedUser(profile.id).then(() => getUserFeedUsers());
  };

  const handleUnfollowUser = () => {
    fetchDeleteUserFeedUser(profile.id).then(() => getUserFeedUsers());
  };

  const handlePopperClick = (event) => {
    setAnchorEl(anchorEl ? null : event.currentTarget);
  };

  const handleConfirmClose = () => {
    setConfirmOpen(false);
  };

  const handleBlock = () => {
    fetchCreateNewBlockedAccount(profile.id).then((res) => {
      if (res.status !== 201) {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to block user.');
        handleSnackBarOpen();
      } else {
        getMyConversations();
        setNewMessageView(true);
        setSuccessAlert(true);
        setSnackBarMessage(
          'User successfully blocked (you can undo this in settings).'
        );
        handleSnackBarOpen();
        navigate('/settings');
      }
    });
  };

  const handlePromote = () => {
    fetchPromoteToAdmin(profile.identityUserId).then((res) => {
      if (res.status !== 204) {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to promote user.');
        handleSnackBarOpen();
      } else {
        handleConfirmClose();
        getOtherUserWithProfile();
        setSuccessAlert(true);
        setSnackBarMessage('User successfully promoted to admin.');
        handleSnackBarOpen();
      }
    });
  };

  const handleBan = () => {
    fetchAdminBanAccount(profile.id).then((res) => {
      if (res.status !== 204) {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to ban user account.');
        handleSnackBarOpen();
      } else {
        handleConfirmClose();
        getMyConversations();
        setSuccessAlert(true);
        setSnackBarMessage('User account successfully banned.');
        handleSnackBarOpen();
        navigate('/');
      }
    });
  };

  const handleDeleteUserProfile = () => {
    fetchAdminDeleteUserProfile(profile.identityUserId).then((res) => {
      if (res.status !== 204) {
        setSuccessAlert(false);
        setSnackBarMessage('Failed to delete user account.');
        handleSnackBarOpen();
      } else {
        handleConfirmClose();
        getMyConversations();
        setSuccessAlert(true);
        setSnackBarMessage('User account successfully deleted.');
        handleSnackBarOpen();
        navigate('/');
      }
    });
  };

  const open = Boolean(anchorEl);
  const popperId = open ? 'simple-popper' : undefined;

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
              elevation={4}
              className="profile-left-sidebar"
            >
              {profile.roles.includes('Admin') ? (
                ''
              ) : (
                <div className="profile-moreOptions">
                  <Tooltip
                    title="Advanced"
                    placement="right"
                  >
                    <IconButton
                      aria-describedby={popperId}
                      onClick={handlePopperClick}
                    >
                      <MoreVertIcon />
                    </IconButton>
                  </Tooltip>
                  <Popper
                    id={popperId}
                    open={open}
                    anchorEl={anchorEl}
                  >
                    <Box sx={{ border: 1, bgcolor: 'background.paper' }}>
                      <List disablePadding>
                        {loggedInUser.roles.includes('Admin') ? (
                          <>
                            <ListItem disablePadding>
                              <ListItemButton
                                onClick={() => {
                                  setActionPicked('ban');
                                  setConfirmOpen(true);
                                }}
                              >
                                <ListItemIcon>
                                  <RemoveCircleOutlineIcon />
                                </ListItemIcon>
                                <ListItemText primary="Ban" />
                              </ListItemButton>
                            </ListItem>
                            {profile.roles.includes('Admin') ? (
                              ''
                            ) : (
                              <ListItem disablePadding>
                                <ListItemButton
                                  onClick={() => {
                                    setActionPicked('promote');
                                    setConfirmOpen(true);
                                  }}
                                >
                                  <ListItemIcon>
                                    <LocalPoliceIcon />
                                  </ListItemIcon>
                                  <ListItemText primary="Promote" />
                                </ListItemButton>
                              </ListItem>
                            )}
                            <ListItem disablePadding>
                              <ListItemButton
                                onClick={() => {
                                  setActionPicked('delete');
                                  setConfirmOpen(true);
                                }}
                              >
                                <ListItemIcon>
                                  <DeleteIcon />
                                </ListItemIcon>
                                <ListItemText primary="Delete" />
                              </ListItemButton>
                            </ListItem>
                          </>
                        ) : (
                          <ListItem disablePadding>
                            <ListItemButton
                              onClick={() => {
                                setActionPicked('block');
                                setConfirmOpen(true);
                              }}
                            >
                              <ListItemIcon>
                                <BlockIcon />
                              </ListItemIcon>
                              <ListItemText primary="Block" />
                            </ListItemButton>
                          </ListItem>
                        )}
                      </List>
                    </Box>
                  </Popper>
                </div>
              )}
              <div className="myProfilePicture-container">
                {profile.profile.profilePicture &&
                loggedInUser.roles.includes('Admin') ? (
                  <div className="editProfilePic-button">
                    <Tooltip
                      title="Delete Profile Picture"
                      placement="right-start"
                    >
                      <IconButton
                        component="label"
                        variant="contained"
                        onClick={() => {
                          setActionPicked('deleteProfilePic');
                          setConfirmOpen(true);
                        }}
                      >
                        <DeleteIcon />
                      </IconButton>
                    </Tooltip>
                  </div>
                ) : (
                  ''
                )}

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
                <Typography>Tags</Typography>
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
                <Typography>SubGenres</Typography>
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
              <ButtonGroup className="otherProfile-buttonGroup">
                {profile.profile.savedProfile ? (
                  <Tooltip
                    title="Unsave Profile"
                    placement="bottom"
                  >
                    <Button
                      variant="contained"
                      onClick={() => handleUnsaveProfile()}
                    >
                      <BookmarkIcon />
                    </Button>
                  </Tooltip>
                ) : (
                  <Tooltip
                    title="Save Profile"
                    placement="bottom"
                  >
                    <Button
                      variant="contained"
                      onClick={() => handleSaveProfile()}
                    >
                      <BookmarkBorderIcon />
                    </Button>
                  </Tooltip>
                )}
                <Tooltip
                  title="Message"
                  placement="bottom"
                >
                  <Button
                    variant="contained"
                    onClick={() => handleMessageClick()}
                  >
                    <MailIcon />
                  </Button>
                </Tooltip>

                {userFeedUsers.some(
                  (sub) => sub.userSubbedToId == profile.id
                ) ? (
                  <Tooltip
                    title="Unfollow"
                    placement="bottom"
                  >
                    <Button
                      variant="contained"
                      onClick={() => handleUnfollowUser()}
                    >
                      <PersonRemoveIcon />
                    </Button>
                  </Tooltip>
                ) : (
                  <Tooltip
                    title="Follow"
                    placement="bottom"
                  >
                    <Button
                      variant="contained"
                      onClick={() => handleFollowUser()}
                    >
                      <PersonAddAlt1Icon />
                    </Button>
                  </Tooltip>
                )}
              </ButtonGroup>
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
                  <Typography variant="h6">About</Typography>
                  <Divider style={{ marginTop: '4px' }} />
                </div>
                {profile.profile.about === null ? (
                  <Typography>No about written yet!</Typography>
                ) : (
                  <Typography>{profile.profile.about}</Typography>
                )}
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <OtherAdditionalPhotos
                  loggedInUser={loggedInUser}
                  profile={profile}
                />
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <OtherPosts
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
        {actionPicked === 'block' ? (
          <>
            <DialogTitle id="alert-dialog-title">{'Block User?'}</DialogTitle>
            <DialogContent>
              <DialogContentText id="alert-dialog-description">
                {`Are you sure you want block ${profile.name}? You will no longer be able to view each other's content or contact one another (his can be undone in the settings section).`}
              </DialogContentText>
            </DialogContent>
            <DialogActions>
              <Button
                color="error"
                variant="contained"
                onClick={() => handleBlock()}
              >
                Block
              </Button>
              <Button
                variant="contained"
                onClick={() => setConfirmOpen(false)}
              >
                Cancel
              </Button>
            </DialogActions>
          </>
        ) : actionPicked === 'ban' ? (
          <>
            <DialogTitle id="alert-dialog-title">{'Ban User?'}</DialogTitle>
            <DialogContent>
              <DialogContentText id="alert-dialog-description">
                {`Are you sure you want ban ${profile.name}? They will no longer be able to access their account until the ban is lifted (this can be done in the settings section).`}
              </DialogContentText>
            </DialogContent>
            <DialogActions>
              <Button
                color="error"
                variant="contained"
                onClick={() => handleBan()}
              >
                Ban
              </Button>
              <Button
                variant="contained"
                onClick={() => setConfirmOpen(false)}
              >
                Cancel
              </Button>
            </DialogActions>
          </>
        ) : actionPicked === 'delete' ? (
          <>
            <DialogTitle id="alert-dialog-title">
              {'Delete User Account?'}
            </DialogTitle>
            <DialogContent>
              <DialogContentText id="alert-dialog-description">
                {`Are you sure you want delete ${profile.name}'s account? Their account and all of their content and activity will be permanently deleted. This cannot be undone.`}
              </DialogContentText>
            </DialogContent>
            <DialogActions>
              <Button
                color="error"
                variant="contained"
                onClick={() => handleDeleteUserProfile()}
              >
                Delete
              </Button>
              <Button
                variant="contained"
                onClick={() => setConfirmOpen(false)}
              >
                Cancel
              </Button>
            </DialogActions>
          </>
        ) : actionPicked === 'deleteProfilePic' ? (
          <>
            <DialogTitle id="alert-dialog-title">
              {'Delete Profile Photo?'}
            </DialogTitle>
            <DialogContent>
              <DialogContentText id="alert-dialog-description">
                {`Are you sure you want delete ${profile.name}'s profile photo? This cannot be undone.`}
              </DialogContentText>
            </DialogContent>
            <DialogActions>
              <Button
                color="error"
                variant="contained"
                onClick={() => handleProfilePictureDelete()}
              >
                Delete
              </Button>
              <Button
                variant="contained"
                onClick={() => setConfirmOpen(false)}
              >
                Cancel
              </Button>
            </DialogActions>
          </>
        ) : (
          <>
            <DialogTitle id="alert-dialog-title">
              {'Promote User to Admin?'}
            </DialogTitle>
            <DialogContent>
              <DialogContentText id="alert-dialog-description">
                {`Are you sure you want promote ${profile.name} to an admin? They will be given full admin rights across the website (this can be changed in the settings section).`}
              </DialogContentText>
            </DialogContent>
            <DialogActions>
              <Button
                color="error"
                variant="contained"
                onClick={() => handlePromote()}
              >
                Promote
              </Button>
              <Button
                variant="contained"
                onClick={() => setConfirmOpen(false)}
              >
                Cancel
              </Button>
            </DialogActions>
          </>
        )}
      </Dialog>
    </>
  );
};
