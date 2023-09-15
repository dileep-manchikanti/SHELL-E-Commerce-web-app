import React, { Component } from 'react';
import Navbar from './Navbar';
import '../css/products.css'
import Item from './item';
// import {withRouter} from 'react-router';
import axios from 'axios';
import { Link } from 'react-router-dom';


class Products extends Component{   
    state={'response':[]};
    constructor(){
        super();
    }
    componentDidMount(){
        this.getCategories();
    }
    getCategories(){
        axios.get('https://d46d-2a09-bac5-3b4c-1aa0-00-2a7-20.ngrok-free.app/api/Product/Fire Resistant Hydraulic Fluids',{
            headers:{
                "ngrok-skip-browser-warning":'fsf'
            }
        })
        .then(response => {
                console.log(response.data);
                // this.response=response.data;
                this.setState({'response':response.data})
            })
        .catch(error => {
            console.log('error',error);
        });
    }

    render(){
    return(
        <div className='products'>
            <Navbar />
            <div className='category'>
                <h1>Fire Resistant Hydraulic Fluids</h1>
                <hr id='underline'></hr>
                <div className='row'>
                {this.state.response.map((response)=>{
                   return <Link to='/product'><Item item={response} /></Link>
                })}
                </div>
            </div>
        </div>
        );
    }
}

export default Products;