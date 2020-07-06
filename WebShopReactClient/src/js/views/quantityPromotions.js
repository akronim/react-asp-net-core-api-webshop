import React, { Component } from "react";
import { connect } from "react-redux";
import If from "../components/if";

class ItemQuantityPromos extends Component {
  constructor(props) {
    super(props);
  }

  onChkAddToBasketChange = (item, e) => {};

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
            return (
              <td key={index} data-label={column.text}>
                {row[column.name]}
              </td>
            );
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
          itemQuantityPromotionID: key.itemQuantityPromotionID,
          name: key.name,
          promoQuantity: key.promoQuantity,
          promoPrice: key.promoPrice,
        });
      });
    }

    let columns = [
      {
        name: "itemQuantityPromotionID",
        text: "ID",
      },
      {
        name: "name",
        text: "ITEM",
      },
      {
        name: "promoQuantity",
        text: "PROMO QUANTITIY",
      },
      {
        name: "promoPrice",
        text: "PROMO PRICE",
      },
    ];

    return (
      <div>
        <table>
          <caption>Item Quantity Promotions</caption>
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

export default connect(mapStateToProps)(ItemQuantityPromos);
