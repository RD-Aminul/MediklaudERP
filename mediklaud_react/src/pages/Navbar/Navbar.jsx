import React, { useState, useEffect, useRef } from "react";
import { useLocation } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import logo from '../../img/logo.png';

function Navbar() {
  const navigate = useNavigate();
  //logged user data start
  const location = useLocation();
  const userData = location.state && location.state.userData;
  const username = location.state && location.state.userData[0];
  const usertype = location.state && location.state.userData[1];
  const companyname = location.state && location.state.userData[2];
  const url = location.state && location.state.userData[3];
  const pin = location.state && location.state.userData[4];
  const cid = location.state && location.state.userData[5];
  const gid = location.state && location.state.userData[6];
  const access = location.state && location.state.userData[7];
  console.log(userData);
  //logged user data end


  const handleNavClick = (path) => {

    navigate(path, {
        state: {
          userData: userData,
          p_username: userData[0],
          p_usertype: userData[1],
          p_companyname: userData[2],
          p_url: userData[3],

          p_pin: userData[4],
          p_cid: userData[5],
          p_gid: userData[6],
          p_paccess: userData[7],
        },
        replace: true,
      });
  };


  return (
    <div className="maindivpos" style={{ margin: "10px" }}>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid" style={{ paddingLeft: "0px" }}>
          <div className="collapse navbar-collapse" id="navbarTogglerDemo03">
            <img src={logo} style={{height: '50px', width: '60px', paddingLeft: '10px'}} alt="Company Logo" /> 
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <a
                  className="nav-link"
                  onClick={() => handleNavClick("/grn")}
                >
                  GRN
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  onClick={() => handleNavClick("/phrPOS")}
                >
                  POS
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  onClick={() => handleNavClick("/PurchaseRequisition")}
                >
                   Requisition
                </a>
              </li>
              <li className="nav-item">
                <a
                  className="nav-link"
                  onClick={() => handleNavClick("/PurchaseOrder")}
                >
                   Purchase Order
                </a>
              </li>
            </ul>
            <form className="d-flex" style={{ marginRight: "0px" }}>
              <label style={{fontWeight: 'bold', paddingTop: '3px'}}>{companyname}&nbsp;&nbsp;&nbsp;&nbsp;|</label>
              &nbsp;&nbsp;&nbsp;&nbsp;
              <label style={{ paddingTop: '3px'}}>{username}</label>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <a href="./">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  width="30"
                  height="30"
                  fill="red"
                  class="bi bi-box-arrow-right"
                  viewBox="0 0 16 16"
                >
                  <path
                    fill-rule="evenodd"
                    d="M10 12.5a.5.5 0 0 1-.5.5h-8a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h8a.5.5 0 0 1 .5.5v2a.5.5 0 0 0 1 0v-2A1.5 1.5 0 0 0 9.5 2h-8A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h8a1.5 1.5 0 0 0 1.5-1.5v-2a.5.5 0 0 0-1 0v2z"
                  />
                  <path
                    fill-rule="evenodd"
                    d="M15.854 8.354a.5.5 0 0 0 0-.708l-3-3a.5.5 0 0 0-.708.708L14.293 7.5H5.5a.5.5 0 0 0 0 1h8.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3z"
                  />
                </svg>
              </a>
            </form>
          </div>
        </div>
      </nav>
    </div>
  );
}

export default Navbar;

