import config from "../helpers/global-variables";
import apiService from "../helpers/api.service";
import * as act_creators from "./actionCreators";

export function fetchItems() {
  let url = `${config.api_base_url}/items`;

  return (dispatch) => {
    dispatch(act_creators.requestItems());

    return apiService
      .get(url, (json) => {
        dispatch(act_creators.receiveItems(json));
      })
      .catch((err) => dispatch(act_creators.receiveItemsError(err)));
  };
}

export function fetchFinalCostPromos() {
  let url = `${config.api_base_url}/final-cost-promotions`;
  return (dispatch) => {
    dispatch(act_creators.requestFinalCostPromos());

    return apiService
      .get(url, (json) => {
        dispatch(act_creators.receiveFinalCostPromos(json));
      })
      .catch((err) => dispatch(act_creators.receiveFinalCostPromosErr(err)));
  };
}

export function fetchItemQuantityPromos() {
  let url = `${config.api_base_url}/item-quantity-promotions`;

  return (dispatch) => {
    dispatch(act_creators.requestItemQuantityPromos());

    return apiService
      .get(url, (json) => {
        dispatch(act_creators.receiveItemQuantityPromos(json));
      })
      .catch((err) => dispatch(act_creators.receiveItemQuantityPromosErr(err)));
  };
}

export function saveOrder(data) {
  let url = `${config.api_base_url}/save-order`;

  return fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json, text/plain",
      "Content-Type": "application/json;charset=UTF-8",
    },
    body: JSON.stringify(data),
  })
    .then((response) => response.json())
    .catch(function (error) {
      console.log("Request failure: ", error);
    });
}

export function calculateTotalPrice(data) {
  let url = `${config.api_base_url}/calculate-price`;

  return fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json, text/plain",
      "Content-Type": "application/json;charset=UTF-8",
    },
    body: JSON.stringify(data),
  })
    .then((response) => response.json())
    .catch(function (error) {
      console.log("Request failure: ", error);
    });
}

export function saveCustomer(data) {
  let url = `${config.api_base_url}/save-customer`;

  return fetch(url, {
    method: "POST",
    headers: {
      Accept: "application/json, text/plain",
      "Content-Type": "application/json;charset=UTF-8",
    },
    body: JSON.stringify(data),
  })
    .then((response) => response.json())
    .catch(function (error) {
      console.log("Request failure: ", error);
    });
}
