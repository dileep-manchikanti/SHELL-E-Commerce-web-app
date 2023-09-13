import { Button } from 'bootstrap';
import React,{Component} from 'react';
import '../css/navbar.css';
import { FaShoppingCart, FaUser } from "react-icons/fa";

class Navbar extends Component{
    render(){
        return(
        <div className='navBar'>
            <span id='navBrand'>Shell-Sell</span>
            <i className='icons'>
            {/* <button className='btn btn-primary m-2'>Contact Support</button> */}
             <span className='icon'>Home</span>
             <span className='icon'>Orders</span>
            <FaUser className='icon'/>
            <FaShoppingCart className='icon'/>
            </i>
        </div>
        )
    }
}

export default Navbar;