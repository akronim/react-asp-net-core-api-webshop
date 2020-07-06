import React from "react";
import { connect } from "react-redux";
import If from "../components/if";
import * as actions from "../redux/webshopActions";
import Modal from "../components/modal";
import CustomerModal from "./customer";

class Basket extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      showModal: false,
      customer: {
        customerID: 0,
        email: "",
        address: "",
        creditCard: "",
      },
      totalPrice: null,
      checkedOut: false,
      orderSaved: false,
    };
  }
  render() {
    return (
      <>
        <div style={{ height: "100%" }}>
          {this.props.basketItems.map((basketItem, index) => {
            return (
              <div key={index} style={{ display: "flex", margin: "1rem" }}>
                <div>{basketItem.name}</div>
                <div style={{ paddingLeft: "1rem" }}>{basketItem.quantity}</div>
              </div>
            );
          })}
          <hr></hr>
          {this.props.selectedFinalCostPromos.map((fcPromo, index) => {
            return (
              <div key={index} style={{ display: "flex", marginLeft: "1rem" }}>
                <div>{fcPromo.description}</div>
              </div>
            );
          })}
          <If condition={this.state.totalPrice}>
            <hr></hr>
            <div style={{ float: "left", marginLeft: "1rem" }}>
              Total Price: {this.state.totalPrice} &euro;
            </div>
          </If>
          <If condition={!this.state.checkedOut}>
            <button className="btn" onClick={this.checkOutBasket} type="button">
              Check Out
            </button>
          </If>
          <If condition={this.state.checkedOut && !this.state.orderSaved}>
            <button className="btn" onClick={this.saveOrder} type="button">
              Save Order
            </button>
          </If>
          <If condition={this.state.checkedOut && this.state.orderSaved}>
            <p style={{ textAlign: "center", marginTop: "3rem" }}>
              Thank You for Your Order!
            </p>
          </If>
          <Modal open={this.state.showModal} close={this.checkOutBasket}>
            <CustomerModal
              customer={this.state.customer}
              onUserDetailsInputChanged={this.onUserDetailsInputChanged}
              onUserDetailsSubmit={this.onUserDetailsSubmit}
            ></CustomerModal>
          </Modal>
        </div>
      </>
    );
  }

  onUserDetailsInputChanged = (name, value) => {
    this.setState({
      customer: {
        ...this.state.customer,
        [name]: value,
      },
    });
  };

  getOrderDetails = () => {
    let basketDTO = {
      CustomerID: this.state.customer.customerID,
      SelectedItems: [],
      SelectedFinalCostPromotions: [],
    };

    this.props.basketItems.map((basketItem, index) => {
      basketDTO.SelectedItems.push({
        ItemID: basketItem.itemID,
        ItemQuantity: basketItem.quantity,
      });
    });

    this.props.selectedFinalCostPromos.map((promo, index) => {
      basketDTO.SelectedFinalCostPromotions.push({
        FinalCostPromotionID: promo.finalCostPromotionID,
        PercentageValue: promo.percentageValue,
        AbsoluteValue: promo.absoluteValue,
        Cumulative: promo.cumulative,
      });
    });

    console.log({ basketDTO });

    return basketDTO;
  };

  onUserDetailsSubmit = () => {
    actions.saveCustomer(this.state.customer).then((customerID) => {
      console.log(customerID);
      this.setState({
        customer: {
          ...this.state.customer,
          customerID: customerID,
        },
      });
      this.checkOutBasket();
      actions.calculateTotalPrice(this.getOrderDetails()).then((totalPrice) => {
        this.setState({ totalPrice: totalPrice, checkedOut: true });
      });
    });
  };

  checkOutBasket = () => {
    this.setState({
      showModal: !this.state.showModal,
    });
  };

  saveOrder = () => {
    actions.saveOrder(this.getOrderDetails()).then((res) => {
      if (res == 1) {
        this.setState({ orderSaved: true });
      }
    });
  };
}

export default Basket;
