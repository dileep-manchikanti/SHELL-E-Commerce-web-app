import React,{Component} from "react";
import { Link } from "react-router-dom";
import '../css/signUp.css';

class SignUp extends Component{
    render(){
        return(
            <div id='signUp' className="row">
                <div className="img col-6">
                    <h3>Sign Up</h3>
                    <p id='info'>Shell has been a customer business and today
                         has more than 1 million business and 100 million consumer customers
                          across the globe.</p>
                </div>
                <div className="details col-8">
                    <div className="inputs row">
                    <div className="col-6 detail">
                        <p>First Name</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Last Name</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-12 detail">
                        <p>Email</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Phone-no:</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Date of Birth</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Password</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Confirm Password</p>
                        <p></p>
                        <hr></hr>
                    </div>
                    </div>
                    <input type='checkbox'></input>  <span>By signing up,I agree to</span> <a id="terms">terms and conditions.</a><br></br>
                    <button btn btn-primary>Sign Up</button> or  
                    <Link to='/'><a href="">Login</a></Link>
                </div>
            </div>
        )
    }
}

export default SignUp;