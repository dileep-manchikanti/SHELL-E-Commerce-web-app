import React, { Component } from 'react';
import Navbar from './Navbar';
import Order from './order';
import '../css/product.css';
import Footer from './footer';
import axios from 'axios';
import DecodedImage from './decoder';

class Product extends Component {
    state={'response':[]};
    constructor(){
        super();
    }
    componentDidMount(){
        this.getCategories();
    }
    
    getCategories(){
        axios.get('https://d46d-2a09-bac5-3b4c-1aa0-00-2a7-20.ngrok-free.app/api/Product/details/1',{
            headers:{
                "ngrok-skip-browser-warning":'fsf'
            }
        })
        .then(response => {
                // console.log(response.data);
                // this.response=response.data;
                this.setState({'response':response.data})
            })
        .catch(error => {
            console.log('error',error);
        });
    }

    render() {
        console.log(this.state.response.productImage);
        return (
            <div className='product'>
                <Navbar />
                <div className="tab row">
                    <div className='productImg col-4' >
                        <DecodedImage base={this.state.response.productImage}/>
                    </div>
                    <div className='productInfo col-8'>
                        <h3>{this.state.response.productName}</h3>
                        {
                            this.state.response.productDescription
                        }
                        <button className='btn btn-secondary' onClick={()=>{alert("Product added to Cart Sucesfully!!")}}>Add to Cart</button>
                    </div>
                </div>
                <Footer />
            </div>

        );
    }
}

export default Product;