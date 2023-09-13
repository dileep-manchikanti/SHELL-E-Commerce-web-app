import React,{Component} from 'react';
import Navbar from './Navbar';
import Category from './category';
import '../css/categories.css';

class Categories extends Component{
    render(){
        return(
        <div className='categories'>
            <Navbar />
            <div class='catalogue row'>
                <Category />
                <Category />
            </div>
        </div>
        );
    }
}

export default Categories;