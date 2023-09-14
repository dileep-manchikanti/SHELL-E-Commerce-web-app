import React,{Component} from "react";
import '../css/signIn.css';
import Navbar from "./Navbar";
import { Link } from "react-router-dom";

class SignIn extends Component{
    handleUser(e){
        console.log(e.key);
        const element=document.getElementById("userid");
        element.innerHTML="|";
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
                    <input id='userid' value="Enter UserName"></input>
                    <hr></hr>
                    <br></br>
                    {/* <br></br> */}
                    <h4>Password</h4> 
                    <p id='password'>Enter Password</p>
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