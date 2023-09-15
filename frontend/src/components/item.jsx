import React,{Component} from "react";
import '../css/item.css';
import DecodedImage from "./decoder";

class Item extends Component{
    constructor(props){
        super(props);
    }
    render(){
        console.log(this.props)
        return(
            <div className="item col-6 row">
                <div className="itemImg col-6">
                <DecodedImage base={this.props.item.image}/>
                </div>
                <div className="itemInfo col-5 m-2">
                    <h3>{this.props.item.name}</h3>
                    <br></br>
                     {this.props.item.description}
                </div>
            </div>
        )
    }
}

export default Item;