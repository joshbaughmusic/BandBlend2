import { Container, Input, TextField } from "@mui/material";
import MainLogo from "../../images/Bandblend_Logos/Logo-top-black.png"
import SubLogo from "../../images/Bandblend_Logos/Logo-bot-black.png"
import "./Home.css"
import { HomeSearchbar } from "./HomeSearchbar.js";

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

        <HomeSearchbar />
        

        {/* <div>Latest 3 placeholder</div> */}
      </Container>
    </>
  );
};
