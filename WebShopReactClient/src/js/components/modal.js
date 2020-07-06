import React, { Component } from "react";
import ReactDOM from "react-dom";

export default class Modal extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return this.props.open
      ? ReactDOM.createPortal(
          <div className="modal">
            <button onClick={this.props.close}>X</button>
            {this.props.children}
          </div>,
          document.body
        )
      : null;
  }
}
