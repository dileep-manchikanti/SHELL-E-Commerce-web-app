import React,{Component} from "react";
import '../css/item.css';

class Item extends Component{
    render(){
        return(
            <div className="item row">
                <div className="itemImg col-6"></div>
                <div className="itemInfo col-5 m-2">
                    <h3>Product Name</h3>
                    <br></br>
                    Lorem ipsum dolor sit amet consectetur adipisicing elit. 
                </div>
            </div>
        )
    }
}

export default Item;