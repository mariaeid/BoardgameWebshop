import React from "react";
import PlacedOrderRow from './../PlacedOrderRow';
import Form from './../Form';
import {withRouter} from 'react-router';
import { Link } from 'react-router-dom';
import { Redirect } from 'react-router'

class PlacedOrderRows extends React.Component {

  state = {
    placedOrderRows: [],
    cartId: this.props.match.params.cartId,
    fetchedOrderId: 0,
    placedOrderDatas: [],
    name: "",
    email: "",
    address: "",
    zipCode: "",
    city: "",
    redirect: false
  };

  componentDidMount = () => {
    this.addPlacedOrderRows();
    console.log('cartId', this.props.match.params.cartId);
    console.log('State cartId', this.state.cartId);
    };

  addPlacedOrderRows = () => {
    return fetch(`http://localhost:54005/api/PlacedOrderRows/${this.props.match.params.cartId}`, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
    })
    .then(response => response.text())
    .then(body => this.setState(
      {fetchedOrderId: body},
      this.getPlacedOrderRows,
    ))
  }

  handleChange = e => {
    const target = e.target;
    const name = target.name;
    const value =  target.value;

    this.setState({
      [name]: value
    });
  };

  addPlaceOrder = e => {
    e.preventDefault();
    console.log("PlaceOrder funktion");
    this.setState({
      redirect: true,
    })
    return fetch(`http://localhost:54005/api/PlacedOrder/${this.state.fetchedOrderId}`, {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        "name": this.state.name,
        "email": this.state.email,
        "address": this.state.address,
        "zipCode": this.state.zipCode,
        "city": this.state.city,
      })
    })
  }

  getPlacedOrderRows = () => {
      return fetch(`http://localhost:54005/api/PlacedOrderRows/${this.state.fetchedOrderId}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ placedOrderRows: data });
      })
      .catch(error => console.error(error));
  }

  render() {
    console.log("OrderId: ", this.state.fetchedOrderId);
    return (
      <div className="checkoutContainer">
        <div  className="cartListContainer">
          <h3>Products: </h3>
          <div> {this.state.placedOrderRows.map((placedOrderRow, key) => {
            return ([
              <div className="placedOrderRowContainer" key={key}>
                <PlacedOrderRow name={`${placedOrderRow.name}:`} price={`${placedOrderRow.price} kr`}/>
              </div>
            ])
          }
          )}
          </div>
        </div>
        <div>
          <h3>Customer information: </h3>

          <form className="formContainer" onSubmit={this.addPlaceOrder}>
            <label htmlFor="name">Name</label>
            <input onChange={this.handleChange} id="name" name="name" type="text" value={this.state.name} />

            <label htmlFor="email">Email</label>
            <input onChange={this.handleChange} id="email" name="email" type="email" value={this.state.email}/>

            <label htmlFor="address">Address</label>
            <input onChange={this.handleChange} id="address" name="address" type="text" value={this.state.address} />

            <label htmlFor="zipCode">ZipCode</label>
            <input onChange={this.handleChange} id="zipCode" name="zipCode" type="text" value={this.state.zipCode} />

            <label htmlFor="city">City</label>
            <input onChange={this.handleChange} id="city" name="city" type="text" value={this.state.city} />
          <button type="submit">Place Order</button>

          </form>
          {this.state.redirect && (
            <Redirect to={{
              pathname: '/OrderConfirmationPage',
              state: {fetchedOrderId: this.state.fetchedOrderId}
            }} />
            )}
        </div>
      </div>
    )
  }

}

export default withRouter(PlacedOrderRows);
