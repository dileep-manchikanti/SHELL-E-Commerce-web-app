import React,{Component} from "react";
import '../css/footer.css';
import { FaCopyright,FaHeadphones,FaMailBulk,FaMailchimp,FaMusic,FaVoicemail } from "react-icons/fa";

class Footer extends Component{
    render(){
        return(
        <div className='footer'>
            <FaCopyright className="foot-icon" />All Rights Reserved - 2023
            <span className="foot-icons">
            <FaMailBulk className="foot-icon"/>
            <FaHeadphones className="foot-icon"></FaHeadphones>
            </span>
        </div>
        )
    }
}
export default Footer;