import React from "react";
import PropTypes from "prop-types";
import OrderConfirmationData from './../OrderConfirmationData';
import {withRouter} from 'react-router';
import { Link } from 'react-router-dom';
import { Redirect } from 'react-router'

class OrderConfirmation extends React.Component {

  state = {
    orderConfirmationData: [],
    fetchedOrderId: this.props.location.state.fetchedOrderId
  }

  componentDidMount = () => {
    this.getPlacedOrder();
    };

  getPlacedOrder = () => {
    console.log("MEDSKICKAT OrderId: ", this.state.fetchedOrderId)
    return fetch(`http://localhost:54005/api/PlacedOrder/${this.state.fetchedOrderId}`)
    .then(response => response.json())
    .then(data => {
      this.setState({ orderConfirmationData: data });
    })
    .catch(error => console.error(error));
  }


  render() {
    console.log(this.state.orderConfirmationData)
    return(
      <div>
        <OrderConfirmationData orderId={`Your order number: ${this.state.orderConfirmationData.orderId}`} totalPrice={`Total price for the order: ${this.state.orderConfirmationData.totalPrice} kr`}/>
      </div>
    )
  }
}

export default withRouter(OrderConfirmation);
