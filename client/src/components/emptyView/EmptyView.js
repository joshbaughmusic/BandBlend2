import { Button, Container, Typography } from '@mui/material';
import MainLogoBlack from '../../images/Bandblend_Logos/Logo-top-black.png';
import SubLogoBlack from '../../images/Bandblend_Logos/Logo-bot-black.png';
import MainLogoWhite from '../../images/Bandblend_Logos/Logo-top-white.png';
import SubLogoWhite from '../../images/Bandblend_Logos/Logo-bot-white.png';
import { useNavigate } from 'react-router-dom';
import { useThemeContext } from '../context/ThemeContext.js';

export const EmptyView = () => {
  const navigate = useNavigate();
  const { darkMode } = useThemeContext();

  return (
    <Container>
      <div>
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
        <Typography
          textAlign="center"
          variant="h4"
          sx={{ m: 3 }}
        >
          Wow, much empty...
        </Typography>
        <div
          style={{
            display: 'flex',
            justifyContent: 'center',
            marginTop: '40px',
          }}
        >
          <Button
            variant="contained"
            onClick={() => navigate('/')}
          >
            Return Home
          </Button>
        </div>
      </div>
    </Container>
  );
};
