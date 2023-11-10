import { Route, Routes } from 'react-router-dom';
import { AuthorizedRoute } from './auth/AuthorizedRoute';
import Login from './auth/Login';
import Register from './auth/Register';
import { Home } from './homepage/Home.js';
import { MyProfile } from './profile/singleProfile/myProfile/MyProfile.js';
import { OtherProfile } from './profile/singleProfile/otherProfile/OtherProfile.js';
import { AllProfiles } from './profile/allProfiles/AllProfiles.js';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <div className="appviews">
      <Routes>
        <Route path="/">
          <Route
            index
            element={<Home loggedInUser={loggedInUser} />}
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
              element={<OtherProfile loggedInUser={loggedInUser} />}
            />
          </Route>
          <Route
            path="allprofiles"
            element={<AllProfiles loggedInUser={loggedInUser} />}
          />
          <Route
            path="login"
            element={<Login setLoggedInUser={setLoggedInUser} />}
          />
          <Route
            path="register"
            element={<Register setLoggedInUser={setLoggedInUser} />}
          />
        </Route>
        <Route
          path="*"
          element={<p>Whoops, nothing here...</p>}
        />
      </Routes>
    </div>
  );
}
