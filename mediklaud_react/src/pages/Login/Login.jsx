import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { variables } from "../../Variables";
import logo from '../../img/logo.png';

const Login = () => {
  const [userId, setUserId] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const showMessage = (message) => {
    setMessage(message);
    setTimeout(() => {
      setMessage("");
    }, 3000);
  };

  const changeUserId = (c) => {
    setUserId(c);
  };

  const changePassword = (c) => {
    setPassword(c);
  };

  const userNameEnter = (e) => {
    // Check if the pressed key is Enter (key code 13)
    if (e.key === "Enter") {
      // Call your function or perform the desired action here
      loginClick();
    }
  };

  const passwordEnter = (e) => {
    // Check if the pressed key is Enter (key code 13)
    if (e.key === "Enter") {
      // Call your function or perform the desired action here
      loginClick();
    }
  };

  const loginClick = async () => {
    if (userId.trim() === "") {
      let message = "Please Enter User Id";
      showMessage(message);
    } else if (password.trim() === "") {
      let message = "Please Enter Password";
      showMessage(message);
    } else {
      try {
        let response = await fetch(
          variables.API_URL +
            `SignIn/GetUserList?LoginId=${encodeURIComponent(
              userId
            )}&Password=${encodeURIComponent(password)}`,
          { method: "GET" }
        );

        if (!response.ok) {
          throw new Error("Probably no internet");
        }
        debugger;
        const data = await response.json();
        let userCheck = data[7];
        debugger;
        if (userCheck !== "0") {
          navigate("/grn", {
            state: {
              userData: data,
              p_username: data[0],
              p_usertype: data[1],
              p_companyname: data[2],
              p_url: data[3],

              p_pin: data[4],
              p_cid: data[5],
              p_gid: data[6],
              p_paccess: data[7],
            },
            replace: true,
          });
        } else {
          let message = "User not found - Please check your credential";
          showMessage(message);
        }
      } catch (error) {
        let message = "Could not connect to the database!";
        showMessage(message);
      }
    }
  };

  return (
    <div>
      <div className="row text-center" style={{marginTop: '150px'}}>
        <div className="text-center">
          <img src={logo} style={{height: '100px', width: '100px'}} alt="Company Logo" />
        </div>
      </div>
      {loading ? (
        <div className="loading-overlay">
          <div className="spinner"></div>
        </div>
      ) : (
        <div className="container d-flex justify-content-center align-items-center h-100">
          <div className="card" style={{ marginTop: "20px", width: "500px" }}>
            <div className="card-body">
              <h5 className="card-title text-center">Login</h5>
              <br></br>
              <form>
                <div className="form-group">
                  <input
                    type="text"
                    className="form-control"
                    placeholder="Username"
                    aria-label="username"
                    aria-describedby="username"
                    value={userId}
                    onChange={(e) => changeUserId(e.target.value)}
                    onKeyDown={userNameEnter}
                  />
                </div>
                <br></br>
                <div className="form-group">
                  <input
                    type="password"
                    className="form-control"
                    placeholder="Password"
                    aria-label="Password"
                    aria-describedby="password"
                    value={password}
                    onChange={(e) => changePassword(e.target.value)}
                    onKeyDown={userNameEnter}
                  />
                </div>
                <br></br>
                <div className="row">
                  <div className="col-8">
                    <div
                      className="row"
                      style={{ color: "red", paddingLeft: "15px" }}
                    >
                      {message}
                    </div>
                  </div>
                  <div className="col-4 text-end">
                    <button
                      type="button"
                      className="button-24"
                      onClick={loginClick}
                    >
                      LOGIN
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Login;
