import { useEffect, useState } from 'react';
import './App.css';
import { tryGetLoggedInUser } from './managers/authManager';
import NavBar from './components/nav/NavBar';
import ApplicationViews from './components/ApplicationViews';
import { createTheme, ThemeProvider } from '@mui/material/styles';

// const theme = createTheme({
//   palette: {
//     primary: {
//       main: '#8C4A4A',
//       dark: '#602d2db4',
//       light: '#9d5d5c',
//     },
//     secondary: {
//       main: '#1D2625',
//       dark: '#001220',
//       light: '#4F5957',
//     },
//   },
// });

function App() {
  const [loggedInUser, setLoggedInUser] = useState();

  useEffect(() => {
    // user will be null if not authenticated
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  // wait to get a definite logged-in state before rendering
  if (loggedInUser === undefined) {
    return null;
  }

  return (
    <>
      {/* <ThemeProvider theme={theme}> */}

        <NavBar
          loggedInUser={loggedInUser}
          setLoggedInUser={setLoggedInUser}
          />
        <ApplicationViews
          loggedInUser={loggedInUser}
          setLoggedInUser={setLoggedInUser}
          />
      {/* </ThemeProvider> */}
    </>
  );
}

export default App;
