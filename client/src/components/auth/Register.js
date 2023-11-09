import { useState } from 'react';
import { register } from '../../managers/authManager';
import { Link, useNavigate } from 'react-router-dom';

export default function Register({ setLoggedInUser }) {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [bandName, setBandName] = useState('');
  const [email, setEmail] = useState('');
  const [isBand, setIsBand] = useState(false);
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');

  const [passwordMismatch, setPasswordMismatch] = useState();

  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setPasswordMismatch(true);
    } else {
      let newUser = {}
      if (isBand) {
         newUser = {
          name: `${firstName} ${lastName}`,
          email,
          password,
        };

      } else {
         newUser = {
          name: bandName,
          email,
          password,
        };
      }
      register(newUser).then((user) => {
        setLoggedInUser(user);
        navigate('/');
      });
    }
  };

  return (
    <div
      className="container"
      style={{ maxWidth: '500px' }}
    >
      <h3>Sign Up</h3>
      <div>
        <label>Are you a band?</label>
        <input
          type="checkbox"
          checked={isBand === true}
          onChange={(e) => {
            setIsBand(!isBand);
          }}
        />
      </div>
      {isBand ? (
        <div>
          <label>Band Name</label>
          <input
            type="text"
            value={bandName}
            onChange={(e) => {
              setBandName(e.target.value);
            }}
          />
        </div>
      ) : (
        <>
          <div>
            <label>First Name</label>
            <input
              type="text"
              value={firstName}
              onChange={(e) => {
                setFirstName(e.target.value);
              }}
            />
          </div>
          <div>
            <label>Last Name</label>
            <input
              type="text"
              value={lastName}
              onChange={(e) => {
                setLastName(e.target.value);
              }}
            />
          </div>
        </>
      )}
      <div>
        <label>Email</label>
        <input
          type="email"
          value={email}
          onChange={(e) => {
            setEmail(e.target.value);
          }}
        />
      </div>

      <div>
        <label>Password</label>
        <input
          invalid={passwordMismatch}
          type="password"
          value={password}
          onChange={(e) => {
            setPasswordMismatch(false);
            setPassword(e.target.value);
          }}
        />
      </div>
      <div>
        <label> Confirm Password</label>
        <input
          invalid={passwordMismatch}
          type="password"
          value={confirmPassword}
          onChange={(e) => {
            setPasswordMismatch(false);
            setConfirmPassword(e.target.value);
          }}
        />
        <p>Passwords do not match!</p>
      </div>
      <button
        color="primary"
        onClick={handleSubmit}
        disabled={passwordMismatch}
      >
        Register
      </button>
      <p>
        Already signed up? Log in <Link to="/login">here</Link>
      </p>
    </div>
  );
}
