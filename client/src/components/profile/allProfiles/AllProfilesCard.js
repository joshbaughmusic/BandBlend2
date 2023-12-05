import { Avatar, Grid, IconButton, Paper, Typography } from '@mui/material';
import BookmarkIcon from '@mui/icons-material/Bookmark';import BookmarkBorderIcon from '@mui/icons-material/BookmarkBorder';
import { useNavigate } from 'react-router-dom';
import { fetchSaveProfile, fetchUnsaveProfile } from '../../../managers/profileManager.js';

export const AllProfilesCard = ({ profile, getAllUsersWithProfiles }) => {
  const navigate = useNavigate();

  const handleSaveProfile = () => {
    fetchSaveProfile(profile.profile.id).then(() => getAllUsersWithProfiles());
  };

  const handleUnsaveProfile = () => {
    fetchUnsaveProfile(profile.profile.id).then(() => getAllUsersWithProfiles());
  };

  return (
    <Paper elevation={4}>
      <Grid
        className="allprofiles-card"
        container
      >
        <Grid
          item
          xs={3}
          md={1}
        >
          <div className="allprofile-card-flexstack-img">
            {profile.profile.profilePicture ? (
              <img
                className="allprofiles-card-image"
                src={profile.profile.profilePicture}
                alt=""
                onClick={() => navigate(`/profile/${profile.id}`)}
              />
            ) : (
              <Avatar sx={{height: "80px", width: "80px"}}></Avatar>
            )}
          </div>
        </Grid>
        <Grid
          item
          xs={3}
          md={3}
        >
          <div className="allprofile-card-flexstack">
            <Typography
              variant="h6"
              onClick={() => navigate(`/profile/${profile.id}`)}
            >
              {profile.name}
            </Typography>
            {profile.isBand ? (
              <Typography>Band</Typography>
            ) : (
              <Typography>{profile.profile.primaryInstrument.name}</Typography>
            )}
            <Typography>
              {profile.profile.city}, {profile.profile.state.name}
            </Typography>
          </div>
        </Grid>
        <Grid
          item
          xs={3}
          md={3}
        >
          <div className="allprofile-card-flexstack">
            <Typography variant="h6">Genre</Typography>
            <Typography>{profile.profile.primaryGenre.name}</Typography>
          </div>
        </Grid>
        <Grid
          item
          xs={3}
          md={4}
        >
          <div className="allprofile-card-flexstack">
            <Typography variant="h6">Tags</Typography>
            {profile.profile.profileTags.map((pt, index) => (
              <Typography>{pt.tag.name}</Typography>
            ))}
          </div>
        </Grid>
        <Grid
          item
          md={1}
          sx={{ display: { xs: 'none', sm: 'none', md: 'block' } }}
        >
          <div className="allprofile-card-flexstack-icon">
            {profile.profile.savedProfile ? (
              <IconButton onClick={() => handleUnsaveProfile()}>
                <BookmarkIcon style={{ fontSize: 40 }} />
              </IconButton>
            ) : (
              <IconButton onClick={() => handleSaveProfile()}>
                <BookmarkBorderIcon style={{ fontSize: 40 }} />
              </IconButton>
            )}
          </div>
        </Grid>
      </Grid>
    </Paper>
  );
};
