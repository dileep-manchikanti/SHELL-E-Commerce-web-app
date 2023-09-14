import React,{Component} from 'react';
import Navbar from './Navbar';
import Category from './category';
import '../css/categories.css';
import Footer from './footer';
import { Link } from 'react-router-dom';
import Data from './data';
import axios from 'axios';


class Categories extends Component{
    state={'response':[]};
    constructor(){
        super();
        
        //this.getCategories();
        // console.log('constructor');
    }
    componentDidMount(){
        this.getCategories();
    }

   
    getCategories(){
        axios.get('https://21fa-2a09-bac1-3680-58-00-2a5-e6.ngrok-free.app/api/Product/GetCategories',{
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
    render(){
        // console.log(this.state.response[0])
        return(
            <div>
        <div className='categories'>
            <Navbar />
            <div className='catalogue row'>
                {this.state.response.map((response)=>{
                   return <Link to='/products/oil' ><Category category={response} /></Link>
                })}
            </div>
            <Footer />
        </div>
        
        </div>
        );
    }
}

export default Categories;