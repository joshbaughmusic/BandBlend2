import {
  Avatar,
  Button,
  Chip,
  Container,
  Grid,
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
            <div className="profile-left-sidebar">
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
                <Button variant="contained">Edit Primary Info</Button>
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
            </div>
          </Grid>
          <Grid
            item
            xs={12}
            md={9}
          >
            <div className="profile-right-section">
              <div className="profile-right-section-item">
                <Typography variant="h6">About</Typography>
                <Typography>{profile.profile.about}</Typography>
              </div>
              <div className="profile-right-section-item">
                <Typography variant="h6">Additional Photos</Typography>
                Place holder
              </div>
              <div className="profile-right-section-item">
                <Typography variant="h6">Posts</Typography>
                <MyPosts profile={profile} />
              </div>
            </div>
          </Grid>
        </Grid>
      </Container>
    </>
  );
};
