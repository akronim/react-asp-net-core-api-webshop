import React, { Component } from "react";
import { connect } from "react-redux";
import If from "../components/if";

class FinalCostPromos extends Component {
  constructor(props) {
    super(props);
  }

  onChkAddToBasketChange = (item, e) => {
    let len = this.props.selected_final_cost_promos.length;

    let b = this.props.selected_final_cost_promos.filter((x) => {
      return x.finalCostPromotionID == item.finalCostPromotionID;
    });

    let non_cumulatives = [];
    if (len > 0) {
      non_cumulatives = this.props.selected_final_cost_promos.filter((x) => {
        return x.cumulative == false;
      });
    }

    if (b[0]) {
      this.props.dispatch({ type: "REMOVE_FCP_FROM_BASKET", item: item });
    } else if (
      (len == 0 && !b[0]) ||
      (len > 0 &&
        !b[0] &&
        non_cumulatives.length == 0 &&
        item.cumulative == true)
    ) {
      this.props.dispatch({ type: "ADD_FCP_TO_BASKET", item: item });
    } else {
      e.preventDefault();
      return false;
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
                return (
                  <td key={index} data-label={column.text}>
                    <input
                      id={row["finalCostPromotionID"]}
                      type="checkbox"
                      value={row["finalCostPromotionID"]}
                      name={row["finalCostPromotionID"]}
                      onClick={(e) => this.onChkAddToBasketChange(row, e)}
                    ></input>
                    {row[column.name]}
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
          finalCostPromotionID: key.finalCostPromotionID,
          description: key.description,
          absoluteValue: key.absoluteValue,
          percentageValue: key.percentageValue,
          cumulative: key.cumulative,
        });
      });
    }

    let columns = [
      {
        name: "finalCostPromotionID",
        text: "ID",
      },
      {
        name: "description",
        text: "DESCRIPTION",
      },
      {
        name: "absoluteValue",
        text: "ABS VALUE",
      },
      {
        name: "percentageValue",
        text: "PERCENTAGE",
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
          <caption>Final Cost Promotions</caption>
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
    selected_final_cost_promos:
      state.basketFinalCostPromosReducer.selected_final_cost_promos,
  };
}

export default connect(mapStateToProps)(FinalCostPromos);
