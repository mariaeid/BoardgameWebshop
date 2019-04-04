import React, { Component } from "react";
import PropTypes from "prop-types";
import Button from "../Button";

class Form extends Component {
  state = {
    name: "",
    email: "",
    customer: []
  };

  handleChange = e => {
    const value =
      e.target.type === "checkbox" ? e.target.checked : e.target.value;

    this.setState({
      [e.target.name]: value
    });
  };

  handleSubmit = e => {
    e.preventDefault();

    this.setState({
      customer: [
        ...this.state.customer,
        {
          name: this.state.name,
          email: this.state.email,
        }
      ],
      name: "",
      email: "",
      lovesFruit: false
    });
  };

  render() {
    return (
      <div>
        <form className="formContainer" onSubmit={this.handleSubmit}>
          <label htmlFor="name"> Name: </label>
          <input onChange={this.handleChange} id="name" type="text" name="name" value={this.state.name} />
          <label htmlFor="email">Email</label>
          <input onChange={this.handleChange} id="email" type="text" name="email" value={this.state.email} />
          <button className="button" type="submit">Place Order</button>
        </form>
      </div>
    );
  }
}

Form.propTypes = {};

export default Form;
