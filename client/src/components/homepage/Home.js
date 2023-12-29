import { Container, useMediaQuery } from "@mui/material";
import MainLogoBlack from "../../images/Bandblend_Logos/Logo-top-black.png"
import SubLogoBlack from "../../images/Bandblend_Logos/Logo-bot-black.png"
import MainLogoWhite from "../../images/Bandblend_Logos/Logo-top-white.png"
import SubLogoWhite from "../../images/Bandblend_Logos/Logo-bot-white.png"
import "./Home.css"
import { HomeSearchbar } from "./HomeSearchbar.js";
import { LatestThree } from "./LatestThree.js";
import { useThemeContext } from "../context/ThemeContext.js";
import { useTheme } from "@emotion/react";

export const Home = ({loggedInUser}) => {
  const { darkMode } = useThemeContext();
  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  if (mediaQuerySmall) {
     return (
       <>
         <Container>
           {darkMode ? (
             <>
               <div className="container-home-logos-small">
                 <img
                  //  className="mainLogo"
                   src={MainLogoWhite}
                   alt=""
                   style={{
                     width: '100%',
                   }}
                 />
                 <img
                  //  className="subLogo"
                   src={SubLogoWhite}
                   alt=""
                   style={{
                     width: '90%',
                   }}
                 />
               </div>
             </>
           ) : (
             <>
               <div className="container-home-logos-small">
                 <img
                  //  className="mainLogo"
                   src={MainLogoBlack}
                   alt=""
                   style={{
                     width: '100%',
                   }}
                 />
                 <img
                  //  className="subLogo"
                   src={SubLogoBlack}
                   alt=""
                   style={{
                     width: '90%',
                   }}
                 />
               </div>
             </>
           )}
           <div
             className="latestThreeAndSearch"
             style={{ marginTop: '20px' }}
           >
             <HomeSearchbar />

             <LatestThree loggedInUser={loggedInUser} />
           </div>
         </Container>
       </>
     );
  }
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
