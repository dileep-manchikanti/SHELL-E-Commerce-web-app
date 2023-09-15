import React,{Component} from "react";
import { Link } from "react-router-dom";
import '../css/signUp.css';

class SignUp extends Component{
    constructor(){
        super();
        this.state={
            "fname":"",
            "lname":"",
            "email":"",
            "phone":"",
            "password":"",
            "cpassword":"",
        }
    }
    handleFname = (event) => {
        this.setState({
          fname :event.target.value,
        });
      };
      handleLname = (event) => {
        this.setState({
          lname: event.target.value,
        });
      };
      handleEmail = (event) => {
        this.setState({
          email: event.target.value,
        });
      };
      handlePhone = (event) => {
        this.setState({
          phone: event.target.value,
        });
      };
      handlePassword = (event) => {
        this.setState({
          password: event.target.value,
        });
      };
      handleCpassword = (event) => {
        this.setState({
          cpassword: event.target.value,
        });
      };
    render(){
        return(
            <div id='signUp' className="row">
                <div className="img col-6">
                    <h3 id="heading">Sign Up</h3>
                    <p id='info'>Shell has been a customer business and today
                         has more than 1 million business and 100 million consumer customers
                          across the globe.</p>
                </div>
                <div className="details col-8">
                    <div className="inputs row">
                    <div className="col-6 detail">
                        <p>First Name</p>
                        <input id='fname' type="text" value={this.state.fname} onChange={this.handleFname}/>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Last Name</p>
                        <input id='lname' type="text" value={this.state.lname} onChange={this.handleLname}/>
                        <hr></hr>
                    </div>
                    <div className="col-12 detail">
                        <p>Email</p>
                        <input id='email' type="text" value={this.state.email} onChange={this.handleEmail}/>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Phone-no:</p>
                        <input id='phone' type="text" value={this.state.phone} onChange={this.handlePhone}/>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Password</p>
                        <input id='Password' type="text" value={this.state.password} onChange={this.handlePassword}/>
                        <hr></hr>
                    </div>
                    <div className="col-6 detail">
                        <p>Confirm Password</p>
                        <input id='cpassword' type="text" value={this.state.cpassword} onChange={this.handleCpassword}/>
                        <hr></hr>
                    </div>
                    </div>
                    <input type='checkbox'></input>  <span>By signing up,I agree to</span> <a id="terms">terms and conditions.</a><br></br>
                    <Link to='/' ><button btn btn-primary onClick={()=>{alert("Account is Created!!")}}>Sign Up</button></Link> or  
                    <Link to='/'><a href="">Login</a></Link>
                </div>
            </div>
        )
    }
}

export default SignUp;