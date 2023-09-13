import { Button } from 'bootstrap';
import React,{Component} from 'react';
import '../css/navbar.css';
import { Link } from 'react-router-dom';
import { FaShoppingCart, FaUser } from "react-icons/fa";

class Navbar extends Component{
    render(){
        return(
        <div className='navBar'>
            <Link to='/categories'><span id='navBrand'>Shell-Sell</span></Link>
            <i className='icons'>
             <Link to='/caategories'><span className='icon'>Home</span></Link>
             <span className='icon'>Orders</span>
            <FaUser className='icon'/>
            <FaShoppingCart className='icon'/>
            </i>
        </div>
        )
    }
}

export default Navbar;