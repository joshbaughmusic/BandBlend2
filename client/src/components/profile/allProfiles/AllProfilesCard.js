import { Avatar, Grid, IconButton, Typography } from '@mui/material';
import TurnedInIcon from '@mui/icons-material/TurnedIn';
import TurnedInNotIcon from '@mui/icons-material/TurnedInNot';
import { useNavigate } from 'react-router-dom';

export const AllProfilesCard = ({ profile }) => {
  const navigate = useNavigate();
  return (
    <>
      <Grid
        className="allprofiles-card"
        container
      >
        <Grid
          item
          xs={1}
        >
          <div className="allprofile-card-flexstack-img">
            <img
              className="allprofiles-card-image"
              src={profile.profile.profilePicture}
              alt=""
              onClick={() => navigate(`/profile/${profile.id}`)}
            />
          </div>
        </Grid>
        <Grid
          item
          xs={3}
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
        >
          <div className="allprofile-card-flexstack">
            <Typography variant="h6">Primary Genre</Typography>
            <Typography>{profile.profile.primaryGenre.name}</Typography>
          </div>
        </Grid>
        <Grid
          item
          xs={4}
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
          xs={1}
        >
          <div className="allprofile-card-flexstack-icon">
            <IconButton>
              <TurnedInIcon style={{ fontSize: 40 }} />
            </IconButton>
          </div>
        </Grid>
      </Grid>
    </>
  );
};
