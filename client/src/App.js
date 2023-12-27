import { useEffect, useState } from 'react';
import './App.css';
import { tryGetLoggedInUser } from './managers/authManager';
import ApplicationViews from './components/ApplicationViews';
import { NavBar } from './components/nav/NavBar.js';
import { SnackBarProvider } from './components/context/SnackBarContext.js';
import { MessagesProvider } from './components/context/MessagesContext.js';
import './KeyFrames.css';
import { useThemeContext } from './components/context/ThemeContext.js';

function App() {
  const [loggedInUser, setLoggedInUser] = useState();
  const { darkMode } =
    useThemeContext();

  useEffect(() => {
    tryGetLoggedInUser().then((user) => {
      setLoggedInUser(user);
    });
  }, []);

  if (loggedInUser === undefined) {
    return null;
  }

  return (
    <div className={darkMode ? 'darkmode' : 'lightmode'}>
      
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
    
    </div>
  );
}

export default App;
