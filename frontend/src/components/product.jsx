import React, { Component } from 'react';
import Navbar from './Navbar';
import Order from './order';
import '../css/product.css';
import Footer from './footer';

class Product extends Component {
    render() {
        return (
            <div className='product'>
                <Navbar />
                <div className="tab row">
                    <div className='productImg col-4' ></div>
                    <div className='productInfo col-8'>
                        <h3>Product Title</h3>
                        Lorem ipsum, dolor sit amet consectetur adipisicing elit. Deleniti sed, inventore, hic mollitia tempora dolorem quis qui porro dignissimos sit maxime consequuntur ab nostrum in cumque voluptatem repudiandae quo cupiditate.
                        Lorem, ipsum dolor sit amet consectetur adipisicing elit. Perferendis temporibus quia modi unde eum illum veniam, corrupti explicabo quos quo alias necessitatibus cum non autem ratione, cumque iste assumenda laborum.
                        Lorem ipsum dolor sit, amet consectetur adipisicing elit. Dolorem labore accusamus, maiores nesciunt commodi, officia autem iste veniam dolorum in tempore cumque, et nulla vel numquam doloremque voluptate obcaecati provident?
                    </div>
                </div>
                <Footer />
            </div>

        );
    }
}

export default Product;