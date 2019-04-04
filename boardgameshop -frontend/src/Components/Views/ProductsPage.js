import React, { Component } from 'react';
import Products from './../App/Products';
import Title from './../App/Title';

class ProductsPage extends Component {
  render() {
    return (
      <div className="main">
        <Title title="The Ultimate Boardgame Shop"/>
        <Products />
      </div>
    );
  }
}

export default ProductsPage;
