import React,{Component} from "react";
import Card from 'react-bootstrap/Card';
import '../css/category.css'

class Category extends Component{
    render(){
        return(
            <div className="card col-6">
                <div className="cardImg"></div>
                <div className="cardTitle">Power Engine Oil</div>
            </div>
        );
    }
}

export default Category;