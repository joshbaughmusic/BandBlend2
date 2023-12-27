import { Container } from "@mui/material";
import MainLogoBlack from "../../images/Bandblend_Logos/Logo-top-black.png"
import SubLogoBlack from "../../images/Bandblend_Logos/Logo-bot-black.png"
import MainLogoWhite from "../../images/Bandblend_Logos/Logo-top-white.png"
import SubLogoWhite from "../../images/Bandblend_Logos/Logo-bot-white.png"
import "./Home.css"
import { HomeSearchbar } from "./HomeSearchbar.js";
import { LatestThree } from "./LatestThree.js";
import { useThemeContext } from "../context/ThemeContext.js";

export const Home = ({loggedInUser}) => {
  const { darkMode } = useThemeContext();
  return (
    <>
      <Container>
        <div className="container-home-logos">
          {darkMode ? (
            <>
              <img
                className="mainLogo"
                src={MainLogoWhite}
                alt=""
                style={{
                  width: '80%',
                }}
              />
              <img
                className="subLogo"
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
                className="mainLogo"
                src={MainLogoBlack}
                alt=""
                style={{
                  width: '80%',
                }}
              />
              <img
                className="subLogo"
                src={SubLogoBlack}
                alt=""
                style={{
                  width: '70%',
                }}
              />
            </>
          )}
        </div>
        <div className="latestThreeAndSearch">
          <HomeSearchbar />

          <LatestThree loggedInUser={loggedInUser} />
        </div>
      </Container>
    </>
  );
};
