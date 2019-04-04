import React, { Component } from 'react';
import Title from './../App/Title';
import OrderConfirmation from './../App/OrderConfirmation';

class OrderConfirmationPage extends Component {
  render() {
    return (
      <div>
        <Title title="Order Confirmation"/>
        <OrderConfirmation />
      </div>
    );
  }
}

export default OrderConfirmationPage;
