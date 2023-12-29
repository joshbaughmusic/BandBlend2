import { useEffect, useState } from 'react';
import { register } from '../../managers/authManager';
import { useNavigate } from 'react-router-dom';
import {
  Button,
  Checkbox,
  Container,
  Divider,
  FormControl,
  FormControlLabel,
  FormGroup,
  Grid,
  IconButton,
  InputAdornment,
  InputLabel,
  MenuItem,
  OutlinedInput,
  Select,
  Stack,
  Typography,
} from '@mui/material';
import { useSnackBar } from '../context/SnackBarContext.js';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import CloudUploadIcon from '@mui/icons-material/CloudUpload';
import CloseIcon from '@mui/icons-material/Close';

import { fetchStates } from '../../managers/statesManager.js';
import styled from '@emotion/styled';
import { fetchPrimaryInstruments } from '../../managers/primaryInstrumentsManager.js';
import { fetchPrimaryGenres } from '../../managers/primaryGenresManager.js';
import { RegisterSocials } from './registerSubComponents/RegisterSocials.js';
import { RegisterSubGenres } from './registerSubComponents/RegisterSubGenres.js';
import { RegisterTags } from './registerSubComponents/RegisterTags.js';
import axios from 'axios';

const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [bandName, setBandName] = useState('');
  const [city, setCity] = useState('');
  const [usStateId, setUsStateId] = useState('');
  const [email, setEmail] = useState('');
  const [selectedPrimaryInstrument, setSelectedPrimaryInstrument] =
    useState('');
  const [selectedPrimaryGenre, setSelectedPrimaryGenre] = useState('');
  const [selectedSubGenres, setSelectedSubGenres] = useState('');
  const [selectedSubGenresCount, setSelectedSubGenresCount] = useState(0);
  const [selectedTags, setSelectedTags] = useState('');
  const [selectedTagsCount, setSelectedTagsCount] = useState(0);
  const [facebook, setFacebook] = useState('');
  const [instagram, setInstagram] = useState('');
  const [spotify, setSpotify] = useState('');
  const [tikTok, setTikTok] = useState('');
  const [isBand, setIsBand] = useState(false);
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [passwordMismatch, setPasswordMismatch] = useState();
  const [profilePicture, setProfilePicture] = useState(null);
  const [profilePictureUrl, setProfilePictureUrl] = useState(null);
  const [error, setError] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);
  const [usStates, setUsStates] = useState();
  const [primaryGenres, setPrimaryGenres] = useState();
  const [primaryInstruments, setPrimaryInstruments] = useState();
  const navigate = useNavigate();

  const getData = () => {
    fetchStates().then(setUsStates);
    fetchPrimaryGenres().then(setPrimaryGenres);
    fetchPrimaryInstruments().then(setPrimaryInstruments);
  };

  useEffect(() => {
    getData();
  }, []);

  const handleClickShowPassword = () => setShowPassword((show) => !show);
  const handleClickShowConfirmPassword = () =>
    setShowConfirmPassword((show) => !show);

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };
  const handleMouseDownConfirmPassword = (event) => {
    event.preventDefault();
  };

  const handleGetPhotoUrl = async (e) => {
    const selectedFile = e.target.files[0];

    if (selectedFile) {
      const allowedTypes = ['image/png', 'image/jpeg', 'image/jpg'];

      if (allowedTypes.includes(selectedFile.type)) {
        const formData = new FormData();
        formData.append('file', selectedFile);
        formData.append('upload_preset', 'unsigned');

        try {
          const response = await axios.post(
            'https://api.cloudinary.com/v1_1/dfanwgskl/image/upload',
            formData
          );
          setProfilePictureUrl(response.data['secure_url']);
          setProfilePicture(selectedFile);
        } catch (error) {
          console.error('Error uploading image:', error);
        }
      } else {
        setProfilePicture(null);
        setProfilePictureUrl(null);
        setSuccessAlert(false);
        setSnackBarMessage('Invalid file format.');
        handleSnackBarOpen();
      }
    } else {
      // Handle case when the file is removed
      setProfilePicture(null);
      setProfilePictureUrl(null);
    }
    e.target.value = null;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setError(false);
    let newUser = {};

    if (isBand) {
      if (
        !bandName ||
        !password ||
        !city ||
        !usStateId ||
        !profilePicture ||
        !profilePictureUrl ||
        !selectedPrimaryGenre
      ) {
        setSnackBarMessage('Please fill out all primary info. ');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (password !== confirmPassword) {
        setError(true);
        setSnackBarMessage('Passwords do not match.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (password.length < 8) {
        setError(true);
        setSnackBarMessage('Password must be at least 8 characters.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (selectedSubGenres.length < 3) {
        setSnackBarMessage('Please select 3 subgenres.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (selectedTags.length < 3) {
        setSnackBarMessage('Please select 3 tags.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else {
        newUser = {
          name: bandName,
          email,
          password,
          city,
          stateId: usStateId,
          profilePicUrl: profilePictureUrl,
          primaryGenreId: selectedPrimaryGenre,
          primaryInstrumentId: 17,
          facebook,
          instagram,
          spotify,
          tikTok,
          subGenreIds: selectedSubGenres,
          tagIds: selectedTags,
          isBand: true,
        };
      }
    } else {
      if (
        !firstName ||
        !lastName ||
        !password ||
        !city ||
        !usStateId ||
        !profilePicture ||
        !profilePictureUrl ||
        !selectedPrimaryGenre ||
        !selectedPrimaryInstrument
      ) {
        setSnackBarMessage('Please fill out all primary info. ');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (password !== confirmPassword) {
        setError(true);
        setSnackBarMessage('Passwords do not match.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (password.length < 8) {
        setError(true);
        setSnackBarMessage('Password must be at least 8 characters.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (selectedSubGenres.length < 3) {
        setSnackBarMessage('Please select 3 subgenres.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else if (selectedTags.length < 3) {
        setSnackBarMessage('Please select 3 tags.');
        setSuccessAlert(false);
        handleSnackBarOpen();
      } else {
        newUser = {
          name: `${firstName} ${lastName}`,
          email,
          password,
          city,
          stateId: usStateId,
          profilePicUrl: profilePictureUrl,
          primaryGenreId: selectedPrimaryGenre,
          primaryInstrumentId: selectedPrimaryInstrument,
          facebook,
          instagram,
          spotify,
          tikTok,
          subGenreIds: selectedSubGenres,
          tagIds: selectedTags,
          isBand: false,
        };
      }
    }

    register(newUser)
      .then((res) => {
        setLoggedInUser(res);
        navigate('/');
      })
      .catch((error) => {
        setSuccessAlert(false);
        setSnackBarMessage(error.message);
        handleSnackBarOpen();
        console.error('Registration process failed:', error);
      });
  };


  if (!usStates || !primaryGenres || !primaryInstruments) {
    return null;
  }

  return (
    <Container className="register-container-inner">
      <div className="register-container-outer">
        <Stack gap={2}>
          <Typography variant="h6">Sign Up</Typography>
          <div>
            <div className="register-heading-container">
              <Typography variant="h6">{`Primary Info (required)`}</Typography>
              <FormGroup>
                <FormControlLabel
                  control={<Checkbox defaultChecked />}
                  label="Sign up as a band?"
                  checked={isBand === true}
                  onChange={(e) => {
                    setIsBand(!isBand);
                  }}
                  sx={{ width: 'fit-content' }}
                />
              </FormGroup>
            </div>
            <Divider sx={{ mt: 1, mb: -1 }} />
          </div>
          <div></div>
          {isBand ? (
            <FormControl variant="outlined">
              <InputLabel htmlFor="outlined-bandName">Band Name</InputLabel>
              <OutlinedInput
                id="outlined-bandName"
                label="BandName"
                value={bandName}
                onChange={(e) => {
                  setBandName(e.target.value);
                }}
              />
            </FormControl>
          ) : (
            <>
              <FormControl variant="outlined">
                <InputLabel htmlFor="outlined-firstName">First Name</InputLabel>
                <OutlinedInput
                  id="outlined-firstName"
                  label="FirstName"
                  value={firstName}
                  onChange={(e) => {
                    setFirstName(e.target.value);
                  }}
                />
              </FormControl>
              <FormControl variant="outlined">
                <InputLabel htmlFor="outlined-lastName">Last Name</InputLabel>
                <OutlinedInput
                  id="outlined-lastName"
                  label="LastName"
                  value={lastName}
                  onChange={(e) => {
                    setLastName(e.target.value);
                  }}
                />
              </FormControl>
            </>
          )}

          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-email">Email</InputLabel>
            <OutlinedInput
              id="outlined-email"
              label="Email"
              value={email}
              onChange={(e) => {
                setError(false);
                setEmail(e.target.value);
              }}
            />
          </FormControl>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-adornment-password">
              Password
            </InputLabel>
            <OutlinedInput
              id="outlined-adornment-password"
              type={showPassword ? 'text' : 'password'}
              value={password}
              error={error}
              onChange={(e) => {
                setError(false);
                setPassword(e.target.value);
              }}
              endAdornment={
                <InputAdornment position="end">
                  <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleClickShowPassword}
                    onMouseDown={handleMouseDownPassword}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
              label="Password"
            />
          </FormControl>
          <FormControl variant="outlined">
            <InputLabel htmlFor="outlined-adornment-confirm-password">
              Confirm Password
            </InputLabel>
            <OutlinedInput
              id="outlined-adornment-confirm-password"
              type={showConfirmPassword ? 'text' : 'password'}
              error={error}
              value={confirmPassword}
              onChange={(e) => {
                setConfirmPassword(e.target.value);
                setError(false);
              }}
              endAdornment={
                <InputAdornment position="end">
                  <IconButton
                    aria-label="toggle password visibility"
                    onClick={handleClickShowConfirmPassword}
                    onMouseDown={handleMouseDownConfirmPassword}
                    edge="end"
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
              label="Confirm Password"
            />
          </FormControl>
          <Grid
            container
            spacing={1}
          >
            <Grid
              item
              xs={8}
            >
              <FormControl
                variant="outlined"
                fullWidth
              >
                <InputLabel htmlFor="outlined-city">City</InputLabel>
                <OutlinedInput
                  id="outlined-city"
                  label="City"
                  value={city}
                  onChange={(e) => {
                    setCity(e.target.value);
                  }}
                />
              </FormControl>
            </Grid>
            <Grid
              item
              xs={4}
            >
              <FormControl
                variant="outlined"
                fullWidth
              >
                <InputLabel id="state-select">State</InputLabel>
                <Select
                  labelId="state-select"
                  id="state-select-droppdown"
                  value={usStateId}
                  label="State"
                  onChange={(e) => {
                    setUsStateId(e.target.value);
                  }}
                >
                  {usStates.map((s, index) => (
                    <MenuItem
                      key={index}
                      value={s.id}
                    >
                      {s.name}
                    </MenuItem>
                  ))}
                </Select>
              </FormControl>
            </Grid>
          </Grid>

          <FormControl>
            <Stack
              gap={1}
              direction="row"
            >
              {profilePicture ? (
                <>
                  <OutlinedInput
                    value={profilePicture.name}
                    fullWidth
                    endAdornment={
                      <InputAdornment position="end">
                        <IconButton edge="end">
                          <CloseIcon
                            onClick={() => {
                              setProfilePicture(null);
                              setProfilePictureUrl(null);
                            }}
                          />
                        </IconButton>
                      </InputAdornment>
                    }
                    InputProps={{
                      readOnly: true,
                    }}
                    disabled
                  />
                </>
              ) : (
                <>
                  <InputLabel htmlFor="profilePic-none">
                    Upload Profile Image...
                  </InputLabel>
                  <OutlinedInput
                    id="profilePic-none"
                    fullWidth
                    disabled
                  />
                </>
              )}

              <Button
                component="label"
                variant="contained"
                startIcon={<CloudUploadIcon />}
                sx={{ width: 150 }}
              >
                Upload
                <VisuallyHiddenInput
                  onChange={handleGetPhotoUrl}
                  type="file"
                />
              </Button>
            </Stack>
          </FormControl>
          <FormControl fullWidth>
            <InputLabel id="primaryGenre-select">Primary Genre</InputLabel>
            <Select
              labelId="primaryGenre-select"
              id="primaryGenre-select-droppdown"
              value={selectedPrimaryGenre}
              label="Primary Genre"
              onChange={(e) => {
                setSelectedPrimaryGenre(e.target.value);
              }}
            >
              {primaryGenres.map((pg, index) => (
                <MenuItem
                  key={index}
                  value={pg.id}
                >
                  {pg.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
          {isBand ? (
            ''
          ) : (
            <FormControl fullWidth>
              <InputLabel id="primaryInstrument-select">
                Primary Instrument
              </InputLabel>
              <Select
                labelId="primaryInstrument-select"
                id="primaryInstrument-select-droppdown"
                value={selectedPrimaryInstrument}
                label="Primary Instrument"
                onChange={(e) => {
                  // setError(false);
                  setSelectedPrimaryInstrument(e.target.value);
                }}
              >
                {primaryInstruments.map((pi, index) => (
                  pi.name === "Band" ?
                ""
                :
                 <MenuItem
                    key={index}
                    value={pi.id}
                  >
                    {pi.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
          )}
        </Stack>
        <RegisterSocials
          setFacebook={setFacebook}
          setInstagram={setInstagram}
          setSpotify={setSpotify}
          setTikTok={setTikTok}
          facebook={facebook}
          instagram={instagram}
          spotify={spotify}
          tikTok={tikTok}
        />
        <RegisterSubGenres
          selectedSubGenres={selectedSubGenres}
          setSelectedSubGenres={setSelectedSubGenres}
          selectedSubGenresCount={selectedSubGenresCount}
          setSelectedSubGenresCount={setSelectedSubGenresCount}
        />
        <RegisterTags
          selectedTags={selectedTags}
          setSelectedTags={setSelectedTags}
          selectedTagsCount={selectedTagsCount}
          setSelectedTagsCount={setSelectedTagsCount}
        />
        <div className="auth-button-container">
          <Button
            variant="contained"
            onClick={handleSubmit}
            disabled={passwordMismatch}
            sx={{ mt: 4 }}
          >
            Register
          </Button>
        </div>
        <Typography
          textAlign="center"
          sx={{ mt: 3, mb: '10px' }}
        >
          Already signed up? Log in{' '}
          <span
            className="register-link"
            onClick={() => navigate('../login')}
          >
            HERE
          </span>
        </Typography>
      </div>
    </Container>
  );
}
