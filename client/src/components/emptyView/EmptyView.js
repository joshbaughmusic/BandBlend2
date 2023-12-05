import { Container, Typography } from "@mui/material"
import MainLogo from '../../images/Bandblend_Logos/Logo-top-black.png';
import SubLogo from '../../images/Bandblend_Logos/Logo-bot-black.png';

export const EmptyView = () => {
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
          Wow, much empty...
        </Typography>
      </div>
    </Container>
  );
}

