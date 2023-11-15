import {
  Avatar,
  Button,
  ButtonGroup,
  Chip,
  Container,
  Divider,
  Grid,
  Paper,
  Typography,
} from '@mui/material';
import { useEffect, useState } from 'react';
import { fetchOtherUserWithProfile, fetchSaveProfile, fetchUnsaveProfile } from '../../../../managers/profileManager.js';
import '../SingleProfile.css';
import SpotifyLogo from '../../../../images/SocialMediaLogos/spotify.png';
import FacebookLogo from '../../../../images/SocialMediaLogos/facebook.png';
import InstagramLogo from '../../../../images/SocialMediaLogos/instagram.png';
import TikTokLogo from '../../../../images/SocialMediaLogos/spotify.png';
import { Link, useNavigate, useParams } from 'react-router-dom';
import BookmarkIcon from '@mui/icons-material/Bookmark';import BookmarkBorderIcon from '@mui/icons-material/BookmarkBorder';
import MailIcon from '@mui/icons-material/Mail';
import PersonAddAlt1Icon from '@mui/icons-material/PersonAddAlt1';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import { OtherPosts } from '../../../posts/otherPosts/OtherPosts.js';
import { OtherAdditionalPhotos } from '../../../additonalPhotos/otherAdditionalPhotos/OtherAdditionalPhotos.js';

export const OtherProfile = () => {
  const [profile, setProfile] = useState();
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

  useEffect(() => {
    getOtherUserWithProfile();
  }, []);

  const handleSaveProfile = () => {
    fetchSaveProfile(profile.id).then(() => getOtherUserWithProfile())
  }

  const handleUnsaveProfile = () => {
    fetchUnsaveProfile(profile.id).then(() => getOtherUserWithProfile())
  }

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
              <ButtonGroup>
                {profile.profile.savedProfile ? (
                  <Button
                    variant="contained"
                    onClick={() => handleUnsaveProfile()}
                  >
                    <BookmarkIcon />
                  </Button>
                ) : (
                  <Button
                    variant="contained"
                    onClick={() => handleSaveProfile()}
                  >
                    <BookmarkBorderIcon />
                  </Button>
                )}
                <Button variant="contained">
                  <MailIcon />
                </Button>
                <Button variant="contained">
                  <PersonAddAlt1Icon />
                </Button>
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
                <OtherAdditionalPhotos profile={profile} />
              </Paper>
              <Paper
                elevation={4}
                className="profile-right-section-item"
              >
                <OtherPosts profile={profile} />
              </Paper>
            </div>
          </Grid>
        </Grid>
      </Container>
    </>
  );
};
