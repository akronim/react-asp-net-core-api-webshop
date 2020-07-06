import { connect } from "react-redux";
import React, { Component, useState } from "react";

class Items extends Component {
  constructor(props) {
    super(props);

    this.state = {
      itemsQuantity: [],
    };
  }

  onChkAddToBasketChange = (item, e) => {
    let a = this.state.itemsQuantity.filter((x) => {
      return x.itemID == item.itemID;
    });

    let b = this.props.basket_items.filter((x) => {
      return x.itemID == item.itemID;
    });

    if (!b[0] && a[0] && a[0].quantity > 0) {
      item.quantity = a[0].quantity;
      this.props.dispatch({ type: "ADD_TO_BASKET", item: item });
    } else if (b[0] && a[0]) {
      this.props.dispatch({ type: "REMOVE_FROM_BASKET", item: item });
    } else {
      return;
    }
  };

  onInputItemQuantityChange = (e, row) => {
    let aa = "itemQuantityOK" + row["itemID"];

    let array = [...this.state.itemsQuantity];
    if (array.length > 0) {
      let arr = array.filter((x) => {
        return x.itemID == row.itemID;
      });

      if (arr.length > 0) {
        for (let i = 0; i < arr.length; i++) {
          let index = array.indexOf(arr[i]);

          if (index !== -1) {
            array.splice(index, 1);
            this.setState({ itemsQuantity: array });
          }
        }
      }
    }

    if (e.target.value > 0) {
      array.push({ itemID: row.itemID, quantity: e.target.value });
      this.setState({ itemsQuantity: array });

      let b = this.props.basket_items.filter((x) => {
        return x.itemID == row.itemID;
      });

      if (b[0]) {
        this.props.dispatch({ type: "REMOVE_FROM_BASKET", item: b[0] });
        b[0].quantity = e.target.value;
        this.props.dispatch({ type: "ADD_TO_BASKET", item: b[0] });
      }

      this.setState({ [aa]: false });
    } else {
      this.setState({ [aa]: true });
    }
  };

  renderTableHeader = (columns) => {
    return columns.map((key, index) => {
      return <th key={index}>{key.text}</th>;
    });
  };

  renderTableData = (items, columns) => {
    return items.map((row, index) => {
      return (
        <tr key={index}>
          {columns.map((column, index) => {
            {
              if (column.type == "checkbox") {
                let disabled =
                  this.state[`itemQuantityOK${row["itemID"]}`] === undefined;
                if (disabled) {
                  disabled = true;
                } else {
                  disabled = this.state[`itemQuantityOK${row["itemID"]}`];
                }

                return (
                  <td key={index} data-label={column.text}>
                    <input
                      id={row["itemID"]}
                      type="checkbox"
                      value={row["itemID"]}
                      name={row["itemID"]}
                      onChange={(e) => this.onChkAddToBasketChange(row, e)}
                      disabled={disabled}
                    ></input>
                    {row[column.name]}
                  </td>
                );
              } else if (column.type == "textbox") {
                return (
                  <td key={index} data-label={column.text}>
                    <input
                      type="number"
                      id={row["itemID"]}
                      onBlur={(e) => this.onInputItemQuantityChange(e, row)}
                      className="input"
                    ></input>
                  </td>
                );
              }
              return (
                <td key={index} data-label={column.text}>
                  {row[column.name]}
                </td>
              );
            }
          })}
        </tr>
      );
    });
  };

  render() {
    let data = [];

    if (this.props.data && this.props.data.length > 0) {
      this.props.data.map(function (key, index) {
        data.push({
          itemID: key.itemID,
          name: key.name,
          price: key.price,
        });
      });
    }

    let columns = [
      {
        name: "itemID",
        text: "ID",
        sortable: true,
      },
      {
        name: "name",
        text: "ITEM",
      },
      {
        name: "price",
        text: "PRICE",
      },
      {
        name: "qunatity",
        text: "QUANTITY",
        type: "textbox",
      },
      {
        name: "add_to_basket",
        text: "ADD TO BASKET",
        type: "checkbox",
      },
    ];

    return (
      <div>
        <table>
          <thead>
            <tr>{this.renderTableHeader(columns)}</tr>
          </thead>
          <tbody>{this.renderTableData(data, columns)}</tbody>
        </table>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    basket_items: state.basketItemsReducer.selected_items,
  };
}

export default connect(mapStateToProps)(Items);
