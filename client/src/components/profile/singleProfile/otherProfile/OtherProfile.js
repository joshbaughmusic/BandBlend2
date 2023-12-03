import {
  Avatar,
  Button,
  ButtonGroup,
  Chip,
  Container,
  Divider,
  Grid,
  Paper,
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
import MailIcon from '@mui/icons-material/Mail';
import PersonAddAlt1Icon from '@mui/icons-material/PersonAddAlt1';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import { OtherPosts } from '../../../posts/otherPosts/OtherPosts.js';
import { OtherAdditionalPhotos } from '../../../additonalPhotos/otherAdditionalPhotos/OtherAdditionalPhotos.js';
import {
  fetchCreateUserFeedUser,
  fetchDeleteUserFeedUser,
  fetchUserFeedUsers,
} from '../../../../managers/feedManager.js';

export const OtherProfile = ({ loggedInUser }) => {
  const [profile, setProfile] = useState();
  const [userFeedUsers, setUserFeedUsers] = useState([]);
  const [picPopUp, setPicPopUp] = useState(null);
  const { id } = useParams();
  const navigate = useNavigate();

  const getOtherUserWithProfile = () => {
    fetchOtherUserWithProfile(id).then((res) => {
      if (res.status === 400) {
        navigate('/profile/me');
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
    fetchUnsaveProfile(profile.profile.id).then(() => getOtherUserWithProfile());
  };

  const handleFollowUser = () => {
    fetchCreateUserFeedUser(profile.id).then(() => getUserFeedUsers());
  };

  const handleUnfollowUser = () => {
    fetchDeleteUserFeedUser(profile.id).then(() => getUserFeedUsers());
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
              <div
                className="photoItem-primary"
                onClick={() => setPicPopUp(profile.profile.profilePicture)}
              >
                <img
                  className="profilePic"
                  src={profile.profile.profilePicture}
                  alt={profile.name}
                />
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
              <Typography
                variant="h5"
                component="h1"
                sx={{ textAlign: 'center' }}
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
                <Typography>Tags</Typography>
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
                <Typography>SubGenres</Typography>
                <div className="chip-multi-container">
                  {profile.profile.profileSubGenres.map((ps, index) => (
                    <Chip
                      key={index}
                      label={ps.subGenre.name}
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
                  <Button variant="contained">
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
                  <Divider />
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
                <OtherAdditionalPhotos profile={profile} />
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
    </>
  );
};
