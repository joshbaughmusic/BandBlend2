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
    {
      loggedInUser.roles.includes("Admin") ?

      <Typography variant="h6" textAlign="center">Admin view</Typography>
      :
      ''
    }
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
        

        <LatestThree loggedInUser={loggedInUser} />
      </Container>
    </>
  );
};
