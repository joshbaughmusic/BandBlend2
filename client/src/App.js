import { useEffect, useState } from 'react';
import './App.css';
import { tryGetLoggedInUser } from './managers/authManager';
import ApplicationViews from './components/ApplicationViews';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { NavBar } from './components/nav/NavBar.js';
import { SnackBarProvider } from './components/context/SnackBarContext.js';
import { MessagesProvider } from './components/context/MessagesContext.js';

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
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  if (loggedInUser === undefined) {
    return null;
  }

  return (
    <>
      {/* <ThemeProvider theme={theme}> */}
      <SnackBarProvider>
        {loggedInUser ? (
          <MessagesProvider loggedInUser={loggedInUser}>
            <NavBar
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
            <ApplicationViews
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
          </MessagesProvider>
        ) : (
          <>
            <NavBar
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
            <ApplicationViews
              loggedInUser={loggedInUser}
              setLoggedInUser={setLoggedInUser}
            />
          </>
        )}
      </SnackBarProvider>
      {/* </ThemeProvider> */}
    </>
  );
}

export default App;
