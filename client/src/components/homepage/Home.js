import { Container, Input, TextField } from "@mui/material";
import MainLogo from "../../images/Bandblend_Logos/Logo-top-black.png"
import SubLogo from "../../images/Bandblend_Logos/Logo-bot-black.png"
import "./Home.css"

export const Home = () => {
  return (
    <>
      <Container>
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
        <TextField
         
          label="Search placeholder"
          variant="filled"
        />

        <div>Latest 3 placeholder</div>
      </Container>
    </>
  );
};
