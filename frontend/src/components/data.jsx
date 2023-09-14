import React,{
    Component
} from "react";
import axios from 'axios';

class Data extends Component{

    state={'categories':{}};

    constructor(){
        super();
        this.getCategories();
    }

     async getCategories(){
        const response=await axios.get('https://21fa-2a09-bac1-3680-58-00-2a5-e6.ngrok-free.app/api/Product/GetCategories',{
            headers:{
                "ngrok-skip-browser-warning":'fsf'
            }
        })
        .then(response => {
            console.log(response.data);
        })
        .catch(error => {
            console.log('error',error);
        });
        console.log(response)
        // this.setState(this.state.categories=response.data);
            }
    render(){        
        return(
            <div></div>
        );
    }
}

export default Data;