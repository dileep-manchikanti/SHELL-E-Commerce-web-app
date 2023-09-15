import React,{Component} from "react";
import '../css/signIn.css';
import Navbar from "./Navbar";
import { Link, Navigate } from "react-router-dom";
import axios from "axios";
class SignIn extends Component{
    handleInputChange = (event) => {
        this.setState({
          value: event.target.value,
        });
      };
    handlePassword = (event) => {
    this.setState({
        password: event.target.value,
    });
    };
     async handleSignIn(){
        const user=document.getElementById('userid');
        const password=document.getElementById('password');
        if(user.value=="kushagra@gmail.com" && password.value=="kushagra123"){
            alert(
                "sucessfull"
            );
        }
        else{
            // alert("credentials mismatched");
            alert(user.innerHTML);
        }

    }
    constructor(){
        super();
        this.state={
            "value":"",
            "password":""
        }
        
    }
    render(){
        return(
            <div className="signin">
            <Navbar />
            <div className="home row">
                <div id="login" className="col-6">
                    <h2>Login</h2>
                    <h4>UserName</h4> 
                    {/* <p id='userid' onClick={()=>{this.handleUser()}}>Enter User Name</p> */}
                    <input id='userid' type="text" value={this.state.value} onChange={this.handleInputChange}/>
                    <hr></hr>
                    <br></br>
                    {/* <br></br> */}
                    <h4>Password</h4>
                    <input id='password' type="text" value={this.state.password} onChange={this.handlePassword}/> 
                    <hr></hr>
                    <div>
                        <Link to='/categories'><button onClick={this.handleSignIn}>Log In</button></Link>
                    </div>
                    <Link to='/signUp'><a>Don't have Account?</a></Link>
                </div>
                <div id="info" className="col-6">
                    <h3>Trading Market</h3>
                    <p>
                        A Single Marketplace for shell customers to buy  Shell products and avail Shell provided Services.
                    </p>
                    <div id="blob"></div>
                    <div id='circles'></div>
                </div>
            </div>
            </div>
        );
    }
}

export default SignIn;