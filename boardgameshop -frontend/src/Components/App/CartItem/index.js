import React from "react";

const CartItem = props => {

  return (
    <div className="cartContent">
      <p className="item">{props.name}</p>
      <p className="item">{props.price}</p>
    </div>
  )
}

export default CartItem;
