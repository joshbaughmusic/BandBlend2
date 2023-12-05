import { Container, Typography } from '@mui/material'
import MainLogo from '../../images/Bandblend_Logos/Logo-top-black.png';
import SubLogo from '../../images/Bandblend_Logos/Logo-bot-black.png';
import React from 'react'

export const BannedAccountView = () => {
  return (
    <Container>
      <div>
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
          example@email.com.
        </Typography>
      </div>
    </Container>
  );
}
