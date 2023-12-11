import { useEffect, useState } from 'react';
import './App.css';
import { tryGetLoggedInUser } from './managers/authManager';
import ApplicationViews from './components/ApplicationViews';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { NavBar } from './components/nav/NavBar.js';
import { SnackBarProvider } from './components/context/SnackBarContext.js';
import { MessagesProvider } from './components/context/MessagesContext.js';
import './KeyFrames.css';
import { useTheme } from '@emotion/react';
import { ThemeProviderContext } from './components/context/ThemeContext.js';

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
      <ThemeProviderContext>
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
      </ThemeProviderContext>
    </>
  );
}

export default App;
