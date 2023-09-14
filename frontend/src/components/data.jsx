import React,{
    Component
} from "react";
import axios from 'axios';

class Data{
    response=[];

constructor(){
    this.getCategories();
    //     
}


async getCategories(){
    let response=axios.get('https://21fa-2a09-bac1-3680-58-00-2a5-e6.ngrok-free.app/api/Product/GetCategories',{
        headers:{
            "ngrok-skip-browser-warning":'fsf'
        }
    })
    .then(response => {
            //console.log(response.data);
            this.response=response.data;
        })
    .catch(error => {
        console.log('error',error);
    });
    this.response=await  response.data;
    console.log(this.response);
}
    
        // console.log(response);
        // this.setState(this.state.categories=response.data);
            }


export default Data;