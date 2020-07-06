import React from "react";
import { connect } from "react-redux";
import * as actions from "../redux/webshopActions";
import Items from "./items";
import Basket from "./basket";
import FinalCostPromos from "./finalCostPromotions";
import ItemQuantityPromos from "./quantityPromotions";
import If from "../components/if";
import store from "../redux/configureStore";

class WebShop extends React.Component {
  constructor(props) {
    super(props);

    store.subscribe(() => {
      this.setState({
        //
      });
      //this.forceUpdate();
    });
  }

  componentDidMount = () => {
    this.props.dispatch(actions.fetchItems());
    this.props.dispatch(actions.fetchFinalCostPromos());
    this.props.dispatch(actions.fetchItemQuantityPromos());
  };

  render() {
    return (
      <>
        <div className="card">
          <If
            condition={
              this.props.finalCostPromos &&
              this.props.finalCostPromos.length > 0
            }
          >
            <FinalCostPromos
              data={this.props.finalCostPromos}
            ></FinalCostPromos>
          </If>
        </div>

        <div className="card">
          <If
            condition={
              this.props.itemQuantityPromos &&
              this.props.itemQuantityPromos.length > 0
            }
          >
            <ItemQuantityPromos
              data={this.props.itemQuantityPromos}
            ></ItemQuantityPromos>
          </If>
        </div>

        <div className="content">
          <div className="cards">
            <div
              className="card"
              style={{ backgroundColor: "SlateGray", color: "white" }}
            >
              <If
                condition={
                  this.props.basket_items && this.props.basket_items.length > 0
                }
              >
                <Basket
                  basketItems={this.props.basket_items}
                  selectedFinalCostPromos={
                    this.props.selected_final_cost_promos
                  }
                ></Basket>
              </If>
            </div>
            <div className="card">
              <Items data={this.props.items}></Items>
            </div>
          </div>
        </div>
      </>
    );
  }
}

function mapStateToProps(state) {
  return {
    items: state.itemsReducer.items,
    itemsLoading: state.itemsReducer.loading,
    itemsError: state.itemsReducer.error,

    finalCostPromos: state.finalCostPromotionsReducer.final_cost_promos,
    finalCostPromosLoading: state.finalCostPromotionsReducer.loading,
    finalCostPromosError: state.finalCostPromotionsReducer.error,

    itemQuantityPromos:
      state.itemQuantityPromotionsReducer.item_quantity_promos,
    itemQuantityPromosLoading: state.itemQuantityPromotionsReducer.loading,
    itemQuantityPromosError: state.itemQuantityPromotionsReducer.error,

    basket_items: state.basketItemsReducer.selected_items,
    selected_final_cost_promos:
      state.basketFinalCostPromosReducer.selected_final_cost_promos,
  };
}

export default connect(mapStateToProps)(WebShop);
