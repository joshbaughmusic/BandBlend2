import {
  Avatar,
  Grid,
  IconButton,
  Paper,
  Tooltip,
  Typography,
} from '@mui/material';
import BookmarkIcon from '@mui/icons-material/Bookmark';
import BookmarkBorderIcon from '@mui/icons-material/BookmarkBorder';
import { useNavigate } from 'react-router-dom';
import {
  fetchSaveProfile,
  fetchUnsaveProfile,
} from '../../../managers/profileManager.js';

export const AllProfilesCard = ({ profile, getAllUsersWithProfiles }) => {
  const navigate = useNavigate();

  const handleSaveProfile = () => {
    fetchSaveProfile(profile.profile.id).then(() => getAllUsersWithProfiles());
  };

  const handleUnsaveProfile = () => {
    fetchUnsaveProfile(profile.profile.id).then(() =>
      getAllUsersWithProfiles()
    );
  };

  return (
    <Paper elevation={4}>
      <Grid
        className="allprofiles-card"
        container
      >
        <Grid
          item
          xs={2}
          md={2}
          sx={{ mr: { xs: 4, sm: 4, md: 0, lg: 0 } }}
        >
          <div className="allprofile-card-flexstack-img">
            {profile.profile.profilePicture ? (
              <img
                className="allprofiles-card-image"
                src={profile.profile.profilePicture}
                alt=""
                onClick={() => navigate(`/profile/${profile.id}`)}
                style={{
                  cursor: 'pointer',
                }}
              />
            ) : (
              <Avatar sx={{ height: '80px', width: '80px' }}></Avatar>
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
              style={{
                cursor: 'pointer',
                width: 'fit-content',
              }}
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
          md={2}
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
              <Tooltip
                title="Unsave Profile"
                placement="right"
              >
                <IconButton onClick={() => handleUnsaveProfile()}>
                  <BookmarkIcon style={{ fontSize: 40 }} />
                </IconButton>
              </Tooltip>
            ) : (
              <Tooltip
                title="Save Profile"
                placement="right"
              >
                <IconButton onClick={() => handleSaveProfile()}>
                  <BookmarkBorderIcon style={{ fontSize: 40 }} />
                </IconButton>
              </Tooltip>
            )}
          </div>
        </Grid>
      </Grid>
    </Paper>
  );
};
