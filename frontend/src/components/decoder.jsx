import React, { Component } from 'react';
import '../css/decoder.css';

class DecodedImage extends Component {
  constructor(props) {
    super(props);

    // Initialize the component's state
    this.state = {
      decodedImage: null,
    };
  }

  componentDidMount() {
    // Decode the Base64 image string
    console.log(this.props.base);
    const base64String = this.props.base;
    this.decodeBase64Image(base64String);
  }

  decodeBase64Image(base64String) {
    const img = new Image();
    img.src = `data:image/png;base64,${base64String}`;

    img.onload = () => {
      // Once the image is loaded, set it in the component's state
      this.setState({
        decodedImage: img.src,
      });
    };
  }

  render() {
    const { decodedImage } = this.state;
    return (
      <div>
        {decodedImage && <img src={decodedImage} alt="Decoded Image" />}
      </div>
    );
  }
}

export default DecodedImage;
