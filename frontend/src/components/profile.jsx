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
          <div className="CARD"><span className="Title">Your Orders</span>
            <br />
            <div className="Content">Track or Order again</div></div>
          <div className="Img img1"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card2 col-4">
          <div className="CARD"><span className="Title">Login & Security</span>
            <br />
            <div className="Content">Edit login, name and mobile no.</div></div>
          <div className="Img img2"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card3 col-4">
          <div className="CARD"><span className="Title">Your Addresses</span>
            <br />
            <div className="Content">Edit or Add Addresses</div></div>
          <div className="Img img3"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card4 col-4">
          <div className="CARD"><span className="Title">Payment Options</span>
            <br />
            <div className="Content">View or add payment methods</div></div>
          <div className="Img img4"></div>
          {/* <div className="content"></div> */}
        </div>
        <div className="card card5 col-4">
          <div className="CARD"><span className="Title">Contact Us</span>
            <br />
            <div className="Content">Complaints & Chat with us</div></div>
          <div className="Img img5"></div>
        </div>
        <Link to='/'><Logout /></Link>
        </div>
        <Footer />  
      </div>
    );
  }
}

export default Profile;