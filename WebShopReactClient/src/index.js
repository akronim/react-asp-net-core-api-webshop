"use strict";

import "./scss/app.scss";

import React, { Component } from "react";
import ReactDOM from "react-dom";
import WebShop from "./js/views/webshop";
import { Provider } from "react-redux";
import store from "./js/redux/configureStore";

class App extends Component {
  render() {
    return (
      <div className="container">
        <WebShop />
      </div>
    );
  }
}

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById("root")
);
