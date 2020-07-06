import React, { Component } from "react";

export default class CustomerModal extends React.Component {
  constructor(props) {
    super(props);
  }

  changeHandler = (e) => {
    const name = e.target.name;
    const value = e.target.value;

    this.props.onUserDetailsInputChanged(name, value);
  };

  render() {
    return (
      <div>
        <h2>Customer Details...</h2>
        <p>
          <input
            type="email"
            value={this.props.customer.email}
            name="email"
            onChange={this.changeHandler}
            className="input"
            placeholder="Email"
            required
          ></input>
        </p>
        <p>
          <input
            type="text"
            value={this.props.customer.address}
            name="address"
            onChange={this.changeHandler}
            className="input"
            placeholder="Address"
            required
          ></input>
        </p>
        <p>
          <input
            type="text"
            value={this.props.customer.creditCard}
            name="creditCard"
            onChange={this.changeHandler}
            className="input"
            placeholder="CreditCard"
            required
          ></input>
        </p>
        <input
          className="btn"
          type="button"
          value="Save"
          onClick={this.props.onUserDetailsSubmit}
        ></input>
      </div>
    );
  }
}
