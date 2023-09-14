import React,{Component} from 'react';
import Navbar from './Navbar';
import Category from './category';
import '../css/categories.css';
import Footer from './footer';
import { Link } from 'react-router-dom';
import Data from './data';
import axios from 'axios';


class Categories extends Component{
    render(){
        var data=new Data();
        console.log(data.state.categories);
        return(
            <div>
        <div className='categories'>
            <Navbar />
            <div className='catalogue row'>
                <Link to='/products/Oil' ><Category /></Link>
                <Link to='/products/oil' ><Category /></Link>
                <Link to='/products/oil' ><Category /></Link>
                <Link to='/products/oil' ><Category /></Link>
                <Link to='/products/oil' ><Category /></Link>
                <Link to='/products/oil' ><Category /></Link>
            </div>
            <Footer />
        </div>
        
        </div>
        );
    }
}

export default Categories;