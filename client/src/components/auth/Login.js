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
  Typography,
} from '@mui/material';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import { useSnackBar } from '../context/SnackBarContext.js';
import MainLogo from '../../images/Bandblend_Logos/Logo-top-black.png';
import SubLogo from '../../images/Bandblend_Logos/Logo-bot-black.png';
import "./Auth.css"

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState('josh@bandblend.comx');
  const [password, setPassword] = useState('password');
  const [error, setError] = useState(false);
  const { handleSnackBarOpen, setSnackBarMessage, setSuccessAlert } =
    useSnackBar();
  const [showPassword, setShowPassword] = useState(false);

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
        setSuccessAlert(false)
        setSnackBarMessage("Incorrect email or password.")
        handleSnackBarOpen(true)

      } else {
        setLoggedInUser(user);
        navigate('/');
      }
    });
  };

  return (
    <Container className="login-container-outer">
      <div className="container-home-logos">
        <img
          src={MainLogo}
          alt=""
          style={{
            width: '80%',
          }}
        />
        <img
          src={SubLogo}
          alt=""
          style={{
            width: '70%',
          }}
        />
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
          New to the Blend? Register <Link to="/register">here</Link>
        </Typography>
      </div>
    </Container>
  );
}
