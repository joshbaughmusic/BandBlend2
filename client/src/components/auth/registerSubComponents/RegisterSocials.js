import { useState } from 'react';
import { Collapse, Divider, FormControl, IconButton, InputLabel, OutlinedInput, Stack, Typography } from '@mui/material';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import { styled } from '@mui/material/styles';

const ExpandMore = styled((props) => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? 'rotate(0deg)' : 'rotate(180deg)',
  marginLeft: 'auto',
  transition: theme.transitions.create('transform', {
    duration: theme.transitions.duration.shortest,
  }),
}));

export const RegisterSocials = ({facebook, instagram, spotify, tikTok, setFacebook, setInstagram, setSpotify, setTikTok}) => {
 
  const [expanded, setExpanded] = useState(false);

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };


  return (
    <>
      <div className="register-section-header">
        <Typography variant="h6">{`Social Links (optional)`}</Typography>
        <ExpandMore
          expand={expanded}
          onClick={handleExpandClick}
          aria-expanded={expanded}
          aria-label="show more"
        >
          <ExpandMoreIcon />
        </ExpandMore>
      </div>
      <Divider />
      <Collapse
        in={expanded}
        timeout="auto"
        unmountOnExit
      >
        <Stack gap={2}>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-facebook">{`Facebook URL`}</InputLabel>
            <OutlinedInput
              id="outlined-facebook"
              label="Facebook URL"
              value={facebook}
              onChange={(e) => {
                // setError(false);
                setFacebook(e.target.value);
              }}
              // sx={{ width: 500 }}
            />
          </FormControl>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-instagram">{`Instagram URL`}</InputLabel>
            <OutlinedInput
              id="outlined-instagram"
              label="Instagram URL"
              value={instagram}
              onChange={(e) => {
                // setError(false);
                setInstagram(e.target.value);
              }}
              // sx={{ width: 500 }}
            />
          </FormControl>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-spotify">{`Spotify URL`}</InputLabel>
            <OutlinedInput
              id="outlined-spotify"
              label="Spotify URL"
              value={spotify}
              onChange={(e) => {
                // setError(false);
                setSpotify(e.target.value);
              }}
              // sx={{ width: 500 }}
            />
          </FormControl>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-tikTok">{`TikTok URL`}</InputLabel>
            <OutlinedInput
              id="outlined-tikTok"
              label="TikTok URL"
              value={tikTok}
              onChange={(e) => {
                // setError(false);
                setTikTok(e.target.value);
              }}
              // sx={{ width: 500 }}
            />
          </FormControl>
        </Stack>
      </Collapse>
    </>
  );
};
