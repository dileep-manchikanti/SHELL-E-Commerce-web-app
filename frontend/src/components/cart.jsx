import React, { Component } from 'react';
import Navbar from './Navbar';
import Order from './order';
import '../css/cart.css';
import Footer from './footer';
import axios from 'axios';

class Cart extends Component {
    state={'response':[]};
    constructor(){
        super();
    }
    componentDidMount(){
        this.getCategories();
    }
    getCategories(){
        axios.get('https://24e6-2a09-bac5-3b49-1a46-00-29e-98.ngrok-free.app/api/Cart/3',{
            headers:{
                "ngrok-skip-browser-warning":'fsf'
            }
        })
        .then(response => {
                this.setState({'response':response.data})
            })
        .catch(error => {
            console.log('error',error);
        });
    }
    render() {
        console.log(this.state.response.cartItems);
        const cart=[{
            "cartItemId": 8,
            "productImage": null,
            "productName": "Shell Turbo S5 DR",
            "productDescription": "HFC: Water-glycol, 209 L, Viscosity grade 46, High-pressure performance up to 4,000 psi, all-season performance. FM Approved, ISO 12922",
            "productPrice": 426462.49,
            "quantity": 5,
            "totalPrice": 646090.67235,
            "totalTax": 213231.245,
            "totalDeliveryPrice": 6396.93735
          },
        //   {
        //     "cartItemId": 8,
        //     "productImage": null,
        //     "productName": "Shell Omala S2 GX",
        //     "productDescription": "Conventional (EP), 209 L, Viscosity grade 68, Approved by Siemens for Flender, helical, bevel and planetary gear units (ISO 100 to 680); Fives Cincinnati; and many other equipment manufacturersIndustry standards: AGMA EP 9005-F16; ISO 12925-1 Type CKD (ISO 68–460); ISO 12925 Type CKC (ISO 680 and 1000); DIN 51517-Part 3 CLP; AIST (Steel) 224 (ISO 68–460); China National Standard GB 5903-2011 CKD (ISO 68–460); China National Standard GB 5903-2011 CKC (ISO 680 and 1000)",
        //     "productPrice": 38065,
        //     "quantity": 5,
        //     "totalPrice": 251867.22,
        //     "totalTax": 213231.245,
        //     "totalDeliveryPrice": 570.975
        //   },
        //   {
        //     "cartItemId": 8,
        //     "productImage": null,
        //     "productName": "Shell Omala S5 Wind",
        //     "productDescription": "Synthetic (polyalphaolefin), 209 L, Viscosity grade 320, Good wear protection and system efficiency. Readily biodegradable1, low toxicity, >80% bio-based. FM Approved, ISO 12922",
        //     "productPrice": 176483.92,
        //     "quantity": 5,
        //     "totalPrice": 392362.4238,
        //     "totalTax": 213231.245,
        //     "totalDeliveryPrice": 2647.2588
        //   }
        ];
        return (
            <div className='shop'>
                <Navbar />
                <div className="backdrop">
                    <h1 id='cartHead'>Shopping Cart</h1>
                    <hr />
                    {cart.map((response)=>{
                        return <Order order={response}/>
                    })}
                    {/* <Order order={this.state.response}/> */}
                    {/* <Order /> */}
                </div>
                <Footer />
            </div>

        );
    }
}

export default Cart;