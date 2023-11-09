import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { login } from "../../managers/authManager";

export default function Login({ setLoggedInUser }) {
  const navigate = useNavigate();
  const [email, setEmail] = useState('josh@bandblend.comx');
  const [password, setPassword] = useState("password");
  const [failedLogin, setFailedLogin] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    login(email, password).then((user) => {
      if (!user) {
        setFailedLogin(true);
        console.log("bad")
      } else {
        setLoggedInUser(user);
        navigate("/");
        console.log('good');
      }
    });
  };

  return (
    <div>
      <h3>Login</h3>
      <div>
        <label>Email</label>
        <input
          type="text"
          value={email}
          onChange={(e) => {
            setFailedLogin(false);
            setEmail(e.target.value);
          }}
        />
      </div>
      <div>
        <label>Password</label>
        <input
          type="password"
          value={password}
          onChange={(e) => {
            setFailedLogin(false);
            setPassword(e.target.value);
          }}
        />
        {/* <p>Login failed.</p> */}
      </div>

      <button onClick={handleSubmit}>
        Login
      </button>
      <p>
        Not signed up? Register <Link to="/register">here</Link>
      </p>
    </div>
  );
}
