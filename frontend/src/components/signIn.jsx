import React,{Component} from "react";
import '../css/signIn.css';
import Navbar from "./Navbar";
import { Link } from "react-router-dom";

class SignIn extends Component{
    render(){
        return(
            <div>
            <Navbar />
            <div className="home row">
                <div id="login" className="col-6">
                    <h2>Login</h2>
                    <div>UserName</div> 
                    <input id='userid'></input>
                    <hr></hr>
                    <div>Password</div> 
                    <input id ='password'></input>
                    <hr></hr>
                    <div>
                        <Link to='/categories'><button>Log In</button></Link>
                    </div>
                    <Link to='/signUp'><a>Dont Have Account?</a></Link>
                </div>
                <div id="info" className="col-6">
                    <h3>Trading Market</h3>
                        <p>
                            A Single Marketplace for shell customers to buy  Shell products and avail Shell provided Services.
                        </p>
                </div>
            </div>
            </div>
        );
    }
}

export default SignIn;