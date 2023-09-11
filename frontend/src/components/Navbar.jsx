import { Button } from 'bootstrap';
import React,{Component} from 'react';
import '../css/navbar.css';

class Navbar extends Component{
    render(){
        return(
        <div className='navBar'>
            <span id='navBrand'>Shell-Sell</span>
            <button className='btn btn-primary m-2'>Contact Support</button>
        </div>
        )
    }
}

export default Navbar;