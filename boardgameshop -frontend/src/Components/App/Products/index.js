import React from "react";
import Product from './../Product';
import CartItem from './../CartItem';
import {withRouter} from 'react-router';
import { Link } from 'react-router-dom';

class Products extends React.Component {

  state = {
    products: [],
    fetchedCartId: 0,
    cartItems: [],
    fetchedProductId: 0
  };

  componentDidMount = () => {
    this.getAllProducts();
  };

  getAllProducts = () => {
    return fetch("http://localhost:54005/api/Product")
      .then(response => response.json())
      .then(data => {
        this.setState({ products: data });
      })
      .catch(error => console.error(error));
  };

  addToCart = e => {
    e.preventDefault();
    this.setState({
      fetchedProductId: e.target.value,
      fetchedCartId: e.target.getAttribute('data-value'),
      });
    return fetch("http://localhost:54005/api/Cart", {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        "cartId": e.target.getAttribute('data-value'),
        "productId": e.target.value,
      })
    })
    .then(response => response.text())
    .then(body => this.setState(
      {fetchedCartId: body},
      this.getCart
    ))
  }

  getCart = () => {
    return fetch(`http://localhost:54005/api/Cart/${this.state.fetchedCartId}`)
      .then(response => response.json())
      .then(data => {
        this.setState({ cartItems: data });
      })
      .catch(error => console.error(error));
  };

  render() {
    console.log(this.state.fetchedCartId + " cartId");
    console.log(this.state.fetchedProductId + " productId");
    console.log("All products", this.state.products)
    let link;
    if (this.state.fetchedCartId === 0){
      link = <Link to={{pathname: `/`}}>
        <button className="orderButton">Order</button>
      </Link>
    } else {
      link = <Link to={{pathname: `/CheckoutPage/${this.state.fetchedCartId}`}}>
        <button className="orderButton">Order</button>
      </Link>
    }
    return (
      <div className="productsCartContainer">
        <div className="productsContainer"> {this.state.products.map((product, key) => {
          return ([
            <div className="productContainer" key={product.productId}>
              <Product name={product.name} image={product.image} price={product.price} description={product.description}/>
                <button className="addToCartButton" onClick={this.addToCart} value={product.productId} data-value={this.state.fetchedCartId}>Add to Cart</button>
            </div>
          ])
        }
        )}
        </div>
        <div className="cartContainer">
          <h2>Your Cart:</h2>
          <div className="cartItemsContainer"> {this.state.cartItems.map((cartItem, key) => {
            return ([
              <div className="cartItemContainer" key={key}>
                <CartItem name={`${cartItem.name}:`} price={`${cartItem.price} kr`}/>
              </div>
            ])
          }
          )}
          </div>
          {link}
        </div>
      </div>
    )
  }
}

export default withRouter(Products);
