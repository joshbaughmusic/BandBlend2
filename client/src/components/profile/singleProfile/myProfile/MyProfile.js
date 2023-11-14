import {
  Avatar,
  Button,
  Chip,
  Container,
  Divider,
  Grid,
  IconButton,
  Paper,
  Typography,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { fetchCurrentUserWithProfile } from '../../../../managers/profileManager.js';
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

export const MyProfile = () => {
  const [profile, setProfile] = useState();

  const getCurrentUserWithProfile = () => {
    fetchCurrentUserWithProfile().then(setProfile);
  };

  useEffect(() => {
    getCurrentUserWithProfile();
  }, []);

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
                <EditPrimaryInfo
                  profile={profile}
                  getCurrentUserWithProfile={getCurrentUserWithProfile}
                />
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
                <Button variant="contained">Edit Tags</Button>
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
                <Button variant="contained">Edit SubGenres</Button>
              </div>
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
                    <IconButton>
                      <EditIcon />
                    </IconButton>
                  </div>
                  <Divider />
                </div>
                <Typography>{profile.profile.about}</Typography>
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <div className="divider-header-container">
                  <Typography variant="h6">Additional Photos</Typography>
                  <Divider />
                </div>
                <MyAdditionalPhotos />
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
    </>
  );
};
