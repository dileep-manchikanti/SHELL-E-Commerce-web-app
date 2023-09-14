import React,{Component} from 'react';
import Navbar from './Navbar';
import '../css/products.css'
import Item from './item';
// import {withRouter} from 'react-router';
import {useParams} from "react-router-dom"

function Products(){   
    let {id} = useParams();
    return(
        <div className='products'>
            <Navbar />
            <div className='category'>
                <h1>{id}</h1>
                <hr id='underline'></hr>
                <Item />
                <Item />
                <Item />
            </div>
        </div>
        );
    }

export default Products;