import React, { Component } from "react";
import "../css/profile.css";
import Footer from "./footer";
import Logout from "./logout";
import Navbar from "./Navbar";
import { Link } from "react-router-dom";

class Profile extends Component {
  render() {
    return (
      <div>
        <Navbar />
        <div className="profile">
        <div className="card card1 col-4">
          <div className="CARD"><span className="cardTitle">Your Orders</span>
            <br />
            <div className="content">Track or Order again</div></div>
          <div className="cardImg img1"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card2 col-4">
          <div className="CARD"><span className="cardTitle">Login & Security</span>
            <br />
            <div className="content">Edit login, name and mobile no.</div></div>
          <div className="cardImg img2"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card3 col-4">
          <div className="CARD"><span className="cardTitle">Your Addresses</span>
            <br />
            <div className="content">Edit or Add Addresses</div></div>
          <div className="cardImg img3"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card4 col-4">
          <div className="CARD"><span className="cardTitle">Payment Options</span>
            <br />
            <div className="content">View or add payment methods</div></div>
          <div className="cardImg img4"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card5 col-4">
          <div className="CARD"><span className="cardTitle">Contact Us</span>
            <br />
            <div className="content">Complaints & Chat with us</div></div>
          <div className="cardImg img5"></div>
        </div>
        <Link to='/'><Logout /></Link>
        </div>
        <Footer />  
      </div>
    );
  }
}

export default Profile;