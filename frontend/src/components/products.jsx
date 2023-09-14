import React, { useState, useEffect } from 'react';
import Navbar from './Navbar';
import '../css/products.css'
import Item from './item';
// import {withRouter} from 'react-router';
import {useParams} from "react-router-dom"


function Products(){   
    const [data, setData] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    let {id} = useParams();
    useEffect(() => {
        // Function to make the API request
        async function fetchData() {
            const response = await fetch('https://21fa-2a09-bac1-3680-58-00-2a5-e6.ngrok-free.app/api/Product/GetCategories')
            .then(response => {
                const jsonData = response.data;
            setData(jsonData);
            setLoading(false);
            })
        .catch(error => {
            console.log('error',error);
        });
            
            

        }
    
        // Call the API function when the component mounts
        fetchData();
      }, []);
      console.log(data);
    return(
        <div className='products'>
            <Navbar />
            <div className='category'>
                <h1>{id}</h1>
                <hr id='underline'></hr>
                <Item />
                <Item />
                <Item />
            </div>
        </div>
        );
    }

export default Products;