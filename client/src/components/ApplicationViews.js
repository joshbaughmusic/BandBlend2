import { Navigate, Route, Routes } from 'react-router-dom';
import { AuthorizedRoute } from './auth/AuthorizedRoute';
import Login from './auth/Login';
import Register from './auth/Register';
import { Home } from './homepage/Home.js';
import { MyProfile } from './profile/singleProfile/myProfile/MyProfile.js';
import { OtherProfile } from './profile/singleProfile/otherProfile/OtherProfile.js';
import { AllProfiles } from './profile/allProfiles/AllProfiles.js';
import { MyFeed } from './feed/MyFeed.js';
import { Settings } from './settings/Settings.js';
import { BannedAccountView } from './bannedAccountView/BannedAccountView.js';
import { EmptyView } from './emptyView/EmptyView.js';
import { AdminSettings } from './adminViews/AdminSettings/AdminSettings.js';
import { useTheme } from '@emotion/react';
import { useMediaQuery } from '@mui/material';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  
  const theme = useTheme();
  const mediaQuerySmall = useMediaQuery(theme.breakpoints.down('sm'));

  if (loggedInUser?.accountBanned) {
    return (
      <Routes>
        <Route
          path="/"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <BannedAccountView loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="*"
          element={<EmptyView loggedInUser={loggedInUser} />}
        />
      </Routes>
    );
  }

  if (mediaQuerySmall) {
    return (
      <div>
        <Routes>
          <Route path="/">
            <Route
              index
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <Home loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
            <Route path="profile">
              <Route
                path="me"
                element={
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <MyProfile loggedInUser={loggedInUser} />
                  </AuthorizedRoute>
                }
              />
              <Route
                path=":id"
                element={
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <OtherProfile loggedInUser={loggedInUser} />
                  </AuthorizedRoute>
                }
              />
            </Route>
            <Route
              path="allprofiles"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <AllProfiles loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
            <Route
              path="feed"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <MyFeed loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
            <Route path="settings">
              <Route
                index
                element={
                  loggedInUser?.roles.includes('Admin') ? (
                    <AuthorizedRoute
                      roles={['Admin']}
                      loggedInUser={loggedInUser}
                    >
                      <AdminSettings loggedInUser={loggedInUser} />
                    </AuthorizedRoute>
                  ) : (
                    <AuthorizedRoute loggedInUser={loggedInUser}>
                      <Settings
                        setLoggedInUser={setLoggedInUser}
                        loggedInUser={loggedInUser}
                      />
                    </AuthorizedRoute>
                  )
                }
              />
            </Route>
          </Route>

          {/* handle already logged in user tyring to go to login or register */}
          {loggedInUser ? (
            <>
              <Route
                path="login"
                element={<Navigate to="/" />}
              />
              <Route
                path="register"
                element={<Navigate to="/" />}
              />
            </>
          ) : (
            <>
              <Route
                path="login"
                element={<Login setLoggedInUser={setLoggedInUser} />}
              />
              <Route
                path="register"
                element={<Register setLoggedInUser={setLoggedInUser} />}
              />
            </>
          )}
          <Route
            path="*"
            element={<EmptyView loggedInUser={loggedInUser} />}
          />
        </Routes>
      </div>
    );
  }

  return (
    <div className={loggedInUser ? 'appviews' : ''}>
      <Routes>
        <Route path="/">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Home loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route path="profile">
            <Route
              path="me"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <MyProfile loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
            <Route
              path=":id"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <OtherProfile loggedInUser={loggedInUser} />
                </AuthorizedRoute>
              }
            />
          </Route>
          <Route
            path="allprofiles"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <AllProfiles loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route
            path="feed"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <MyFeed loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
          <Route path="settings">
            <Route
              index
              element={
                loggedInUser?.roles.includes('Admin') ? (
                  <AuthorizedRoute
                    roles={['Admin']}
                    loggedInUser={loggedInUser}
                  >
                    <AdminSettings loggedInUser={loggedInUser} />
                  </AuthorizedRoute>
                ) : (
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <Settings
                      setLoggedInUser={setLoggedInUser}
                      loggedInUser={loggedInUser}
                    />
                  </AuthorizedRoute>
                )
              }
            />
          </Route>
        </Route>

        {/* handle already logged in user tyring to go to login or register */}
        {loggedInUser ? (
          <>
            <Route
              path="login"
              element={<Navigate to="/" />}
            />
            <Route
              path="register"
              element={<Navigate to="/" />}
            />
          </>
        ) : (
          <>
            <Route
              path="login"
              element={<Login setLoggedInUser={setLoggedInUser} />}
            />
            <Route
              path="register"
              element={<Register setLoggedInUser={setLoggedInUser} />}
            />
          </>
        )}
        <Route
          path="*"
          element={<EmptyView loggedInUser={loggedInUser} />}
        />
      </Routes>
    </div>
  );
}
