import React,{Component} from "react";
import '../css/category.css'
import DecodedImage from "./decoder";

class Category extends Component{
    constructor(props){
        super(props);
    }
    async changeStyle(id){
        const element=await document.getElementById(id);
        element.style.backgroundImage="url('../components/R.jpg')";
    }
    render(){
        const category=this.props.category;
        // this.changeStyle("img");
        // image.style.backgroundImage="url('../components/R.jpg')";
        return(
            <div className="card col-6" key={category.id}>
                <DecodedImage className='cardImg' base={category.image} />
                <div className="cardTitle">{category.name}</div>
                <div className="content">{category.description}</div>
            </div>
        );
    }
}

export default Category;