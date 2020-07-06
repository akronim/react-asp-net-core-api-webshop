import React from "react";

export default class If extends React.Component {
  render() {
    let { condition, children } = this.props;
    if (!condition) {
      return null;
    }
    return children;
  }
}
