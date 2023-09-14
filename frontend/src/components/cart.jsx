import React, { Component } from 'react';
import Navbar from './Navbar';
import Order from './order';
import '../css/cart.css';
import Footer from './footer';

class Cart extends Component {
    render() {
        return (
            <div className='shop'>
                <Navbar />
                {/* <div className='shop'>

                </div> */}
                <div className="backdrop">
                    <h1 id='cartHead'>Shopping Cart</h1>
                    <hr />
                    <Order />
                    <Order />
                </div>
                <Footer />
            </div>

        );
    }
}

export default Cart;