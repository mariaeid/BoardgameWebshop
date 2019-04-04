import React from "react";

const PlacedOrderRow = props => {

  return (
    <div className="placedOrderRowContent">
      <p className="item">{props.name}</p>
      <p className="item">{props.price}</p>
    </div>
  )
}

export default PlacedOrderRow;
