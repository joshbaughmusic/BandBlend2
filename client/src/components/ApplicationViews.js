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
import { FeedSettings } from './settings/subSettings/FeedSettings.js';
import { BlockedAccountsSettings } from './settings/subSettings/BlockedAccountsSettings.js';
import { DeleteAccountSettings } from './settings/subSettings/DeleteAccountSettings.js';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
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
                loggedInUser.roles.includes('Admin') ? (
                  <AuthorizedRoute roles={["Admin"]} loggedInUser={loggedInUser}>
                    <Settings loggedInUser={loggedInUser} />
                  </AuthorizedRoute>
                ) : (
                  <AuthorizedRoute loggedInUser={loggedInUser}>
                    <Settings loggedInUser={loggedInUser} />
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
          element={<p>Whoops, nothing here...</p>}
        />
      </Routes>
    </div>
  );
}
