import React,{Component} from 'react';
import Navbar from './Navbar';
import Category from './category';
import '../css/categories.css';
import Footer from './footer';

class Categories extends Component{
    render(){
        return(
            <div>
        <div className='categories'>
            <Navbar />
            <div className='catalogue row'>
                <Category />
                <Category />
                <Category />
                <Category />
                <Category />
                <Category />
            </div>
            <Footer />
        </div>
        
        </div>
        );
    }
}

export default Categories;