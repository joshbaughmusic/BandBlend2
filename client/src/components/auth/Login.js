import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { login } from '../../managers/authManager';
import {
  Button,
  Container,
  FormControl,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Stack,
  Tooltip,
  Typography,
} from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import { useSnackBar } from '../context/SnackBarContext.js';
import MainLogoBlack from '../../images/Bandblend_Logos/Logo-top-black.png';
import MainLogoWhite from '../../images/Bandblend_Logos/Logo-top-white.png';
import SubLogoBlack from '../../images/Bandblend_Logos/Logo-bot-black.png';
import SubLogoWhite from '../../images/Bandblend_Logos/Logo-bot-white.png';
import './Auth.css';
import { useThemeContext } from '../context/ThemeContext.js';
import DarkModeIcon from '@mui/icons-material/DarkMode';
import LightModeIcon from '@mui/icons-material/LightMode';

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState('josh@bandblend.comx');
  const [password, setPassword] = useState('password');
  const [error, setError] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [showPassword, setShowPassword] = useState(false);
  const { darkMode, handleDarkModeClick } = useThemeContext();

  const handleClickShowPassword = () => setShowPassword((show) => !show);

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };

  const handleSubmit = (e) => {
    setError(false);

    e.preventDefault();
    login(email, password).then((user) => {
      if (!user) {
        setError(true);
        setSuccessAlert(false);
        setSnackBarMessage('Incorrect email or password.');
        handleSnackBarOpen(true);
      } else {
        setLoggedInUser(user);
        navigate('/');
      }
    });
  };

  return (
    <>
      <div className="login-theme-button">
        {darkMode ? (
          <Tooltip
            title="Theme"
            placement="right"
          >
            <IconButton onClick={() => handleDarkModeClick()}>
              <LightModeIcon />
            </IconButton>
          </Tooltip>
        ) : (
          <Tooltip
            title="Theme"
            placement="right"
          >
            <IconButton onClick={() => handleDarkModeClick()}>
              <DarkModeIcon />
            </IconButton>
          </Tooltip>
        )}
      </div>
      <Container className="login-container-outer">
        <div className="container-home-logos">
          {darkMode ? (
            <>
              <img
                src={MainLogoWhite}
                alt=""
                style={{
                  width: '80%',
                }}
              />
              <img
                src={SubLogoWhite}
                alt=""
                style={{
                  width: '70%',
                }}
              />
            </>
          ) : (
            <>
              <img
                src={MainLogoBlack}
                alt=""
                style={{
                  width: '80%',
                }}
              />
              <img
                src={SubLogoBlack}
                alt=""
                style={{
                  width: '70%',
                }}
              />
            </>
          )}
        </div>
        <div className="login-container-inner">
          <Stack gap={2}>
            <Typography variant="h6">Login</Typography>
            <FormControl variant="outlined">
              <InputLabel htmlFor="outlined-email">Email</InputLabel>
              <OutlinedInput
                id="outlined-email"
                label="Email"
                value={email}
                error={error}
                onChange={(e) => {
                  setError(false);
                  setEmail(e.target.value);
                }}
                // sx={{ width: 500 }}
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
                // sx={{ width: 500 }}
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
          </Stack>
          <div className="auth-button-container">
            <Button
              variant="contained"
              onClick={handleSubmit}
              sx={{ mt: 4 }}
            >
              Login
            </Button>
          </div>

          <Typography
            sx={{ mt: 3 }}
            textAlign="center"
          >
            New to the Blend? Register{' '}
            <span className='register-link'
              onClick={() => navigate('../register')}
            >
              HERE
            </span>
          </Typography>
        </div>
      </Container>
    </>
  );
}
