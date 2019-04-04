import React from "react";

const Product = props => {

  return (
    <div className="productContent">
      <h2>{props.name}</h2>
      <img src={props.image} alt="Boardgame"/>
      <h4>{props.price}</h4>
      <p>{props.description}</p>
    </div>
  )
}

export default Product;
