import React,{Component} from "react";
import Card from 'react-bootstrap/Card';
import '../css/category.css'

class Category extends Component{
    render(){
        return(
            <div className="card col-6">
                <div className="cardImg"></div>
                <div className="cardTitle">Power Engine Oil</div>
                <div className="content">Choosing the right fire-resistant fluid can be a complex decision and involves balancing product performance,
                 cost and regulatory requirements. Ongoing changes in industry standards can also influence the selection process. Drive system efficiency in your hydraulic equipment with excellent component protection – all while reducing the risk of fluid ignition to improve the safety and productivity of your facilities.</div>
            </div>
        );
    }
}

export default Category;