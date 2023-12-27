import { Container, Typography } from '@mui/material'
import MainLogoBlack from '../../images/Bandblend_Logos/Logo-top-black.png';
import SubLogoBlack from '../../images/Bandblend_Logos/Logo-bot-black.png';
import MainLogoWhite from '../../images/Bandblend_Logos/Logo-top-white.png';
import SubLogoWhite from '../../images/Bandblend_Logos/Logo-bot-white.png';
import React from 'react'
import { useThemeContext } from '../context/ThemeContext.js';

export const BannedAccountView = () => {
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
          This account has been banned.
        </Typography>
        <Typography
          textAlign="center"
          sx={{ fontWeight: 'bold' }}
        >
          Until the ban is lifted, you will no longer have access to it.
        </Typography>
        <Typography
          textAlign="center"
          sx={{ fontWeight: 'bold' }}
        >
          If you believe this was in error, please reach out to
          joshbaughmusic_bb@gmail.com.
        </Typography>
      </div>
    </Container>
  );
}
