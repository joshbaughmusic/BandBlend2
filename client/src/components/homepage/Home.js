import { Container, Typography } from "@mui/material";
import MainLogo from "../../images/Bandblend_Logos/Logo-top-black.png"
import SubLogo from "../../images/Bandblend_Logos/Logo-bot-black.png"
import "./Home.css"
import { HomeSearchbar } from "./HomeSearchbar.js";
import { LatestThree } from "./LatestThree.js";

export const Home = ({loggedInUser}) => {
  return (
    <>
      <Container>
        <div className="container-home-logos">
          <img
            className="mainLogo"
            src={MainLogo}
            alt=""
            style={{
              width: '80%',
            }}
          />
          <img
            className="subLogo"
            src={SubLogo}
            alt=""
            style={{
              width: '70%',
            }}
          />
        </div>
        <div className="latestThreeAndSearch">
          <HomeSearchbar />

          <LatestThree loggedInUser={loggedInUser} />
        </div>
      </Container>
    </>
  );
};
