export const REQUEST_ITEMS = "REQUEST_ITEMS";
export const RECEIVE_ITEMS = "RECEIVE_ITEMS";
export const RECEIVE_ITEMS_ERROR = "RECEIVE_ITEMS_ERROR";

export const REQUEST_FINAL_COST_PROMOS = "REQUEST_FINAL_COST_PROMOS";
export const RECEIVE_FINAL_COST_PROMOS = "RECEIVE_FINAL_COST_PROMOS";
export const RECEIVE_FINAL_COST_PROMOS_ERROR =
  "RECEIVE_FINAL_COST_PROMOS_ERROR";

export const REQUEST_ITEM_QUANTITY_PROMOS = "REQUEST_ITEM_QUANTITY_PROMOS";
export const RECEIVE_ITEM_QUANTITY_PROMOS = "RECEIVE_ITEM_QUANTITY_PROMOS";
export const RECEIVE_ITEM_QUANTITY_PROMOS_ERROR =
  "RECEIVE_ITEM_QUANTITY_PROMOS_ERROR";

export const requestItems = () => ({
  type: REQUEST_ITEMS,
});

export const receiveItems = (json) => ({
  type: RECEIVE_ITEMS,
  items: json,
});

export const receiveItemsError = (error) => ({
  type: RECEIVE_ITEMS_ERROR,
  error,
});

//

export const requestFinalCostPromos = () => ({
  type: REQUEST_FINAL_COST_PROMOS,
});

export const receiveFinalCostPromos = (json) => ({
  type: RECEIVE_FINAL_COST_PROMOS,
  final_cost_promos: json,
});

export const receiveFinalCostPromosErr = (error) => ({
  type: RECEIVE_FINAL_COST_PROMOS_ERROR,
  error,
});

//

export const requestItemQuantityPromos = () => ({
  type: REQUEST_ITEM_QUANTITY_PROMOS,
});

export const receiveItemQuantityPromos = (json) => ({
  type: RECEIVE_ITEM_QUANTITY_PROMOS,
  item_quantity_promos: json,
});

export const receiveItemQuantityPromosErr = (error) => ({
  type: RECEIVE_ITEM_QUANTITY_PROMOS_ERROR,
  error,
});
