import React, { Component } from 'react';
import Navbar from './Navbar';
import Order from './order';
import '../css/cart.css';

class Cart extends Component {
    render() {
        return (
            <div>
                <Navbar />
                <div className='shop'>

                </div>
                <div className="backdrop">
                    <h1 id='cartHead'>Shopping Cart</h1>
                    <hr />
                    <Order />
                    <Order />
                </div>
            </div>

        );
    }
}

export default Cart;