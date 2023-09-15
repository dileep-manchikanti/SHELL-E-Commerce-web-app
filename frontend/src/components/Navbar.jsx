import { Button } from 'bootstrap';
import React,{Component} from 'react';
import '../css/navbar.css';
import { Link } from 'react-router-dom';
import { FaShoppingCart, FaUser } from "react-icons/fa";

class Navbar extends Component{
    render(){
        return(
        <div className='navBar'>
            <Link to='/categories'><span id='navBrand'>Shell-Mart</span></Link>
            <i className='icons'>
             <Link to='/categories'><span className='icon'>Home</span></Link>
             {/* <Link><span className='icon'>Orders</span></Link> */}
            <Link to='/profile'><FaUser className='icon'/></Link>
            <Link to='/cart'><FaShoppingCart className='icon'/></Link>
            </i>
        </div>
        )
    }
}

export default Navbar;