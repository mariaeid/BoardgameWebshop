import React, { Component } from 'react';
import Title from './../App/Title';
import PlacedOrderRows from './../App/PlacedOrderRows';

class CartPage extends Component {
  render() {
    return (
      <div>
        <Title title="Checkout"/>
        <PlacedOrderRows />
      </div>
    );
  }
}

export default CartPage;
