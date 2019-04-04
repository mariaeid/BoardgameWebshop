import React from "react";

const OrderConfirmationData = props => {

  return (
    <div className="orderConfirmationDataContainer">
      <p className="item">{props.orderId}</p>
      <p className="item">{props.totalPrice}</p>
    </div>
  )
}

export default OrderConfirmationData;
