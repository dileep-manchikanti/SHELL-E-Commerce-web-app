import React, { Component } from 'react';
import '../css/order.css'

class Order extends Component {
    render() {
        return (
            <div className="order row">
                <div className="orderImg"></div>
                <div className="orderInfo col-5 m-2">
                    <span id='productTitle'>Product Name</span>
                    <br></br>
                    <div className="prodDesc">Lorem ipsum dolor sit amet consectetur adipisicing elit.</div>
                </div>
                
            </div>
        )
    }
}

export default Order;