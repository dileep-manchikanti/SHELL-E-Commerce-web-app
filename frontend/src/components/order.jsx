import React, { Component } from 'react';
import '../css/order.css'
import {FaTrash} from 'react-icons/fa';
import DecodedImage from './decoder';

class Order extends Component {
    constructor(props){
        super(props);
    }
    render() {
        console.log(this.props.image);
        return (
            <div className="order row">
                <div className="orderImg">
                    <DecodedImage base={this.props.image} />
                </div>
                <div className="orderInfo col-5 m-2">
                    <span id='productTitle'>{this.props.order.productName}</span>
                    <br></br>
                    <div className="prodDesc">{this.props.order.productDescription}</div>
                    <FaTrash className='trash' />
                    <span id='price'>Price:{this.props.order.productPrice}</span>
                </div>
                
            </div>
        )
    }
}

export default Order;