import * as action_type from "./actionCreators";

const basket_items_state = {
  selected_items: [],
};

export const basketItemsReducer = (state = basket_items_state, action) => {
  switch (action.type) {
    case "GET_BASKET_ITEMS":
      return {
        selected_items: state.selected_items,
      };
    case "ADD_TO_BASKET":
      state.selected_items.push(action.item);
      return { selected_items: state.selected_items };
    case "REMOVE_FROM_BASKET":
      let itemToRemove = state.selected_items.filter((x) => {
        return x.itemID == action.item.itemID;
      });
      state.selected_items.splice(
        state.selected_items.indexOf(itemToRemove[0]),
        1
      );
      return { selected_items: state.selected_items };
    default:
      return {
        selected_items: state.selected_items,
      };
  }
};

const basket_final_cost_promos_state = {
  selected_final_cost_promos: [],
};

export const basketFinalCostPromosReducer = (
  state = basket_final_cost_promos_state,
  action
) => {
  switch (action.type) {
    case "GET_FINAL_COST_PROMOTIONS":
      return {
        selected_final_cost_promos: state.selected_final_cost_promos,
      };
    case "ADD_FCP_TO_BASKET":
      state.selected_final_cost_promos.push(action.item);
      return { selected_final_cost_promos: state.selected_final_cost_promos };
    case "REMOVE_FCP_FROM_BASKET":
      let itemToRemove = state.selected_final_cost_promos.filter((x) => {
        return x.itemID == action.item.itemID;
      });
      state.selected_final_cost_promos.splice(
        state.selected_final_cost_promos.indexOf(itemToRemove[0]),
        1
      );
      return { selected_final_cost_promos: state.selected_final_cost_promos };
    default:
      return {
        selected_final_cost_promos: state.selected_final_cost_promos,
      };
  }
};

let items_state = {
  items: {},
  loading: false,
  error: null,
};

export const itemsReducer = (state = items_state, action) => {
  switch (action.type) {
    case action_type.REQUEST_ITEMS:
      return { ...state, loading: true, error: null };
    case action_type.RECEIVE_ITEMS:
      return { ...state, loading: false, items: action.items };
    case action_type.RECEIVE_ITEMS_ERROR:
      return {
        ...state,
        loading: false,
        error: action.error,
        items: {},
      };
    default:
      return state;
  }
};

let final_cost_promos_state = {
  final_cost_promos: {},
  loading: false,
  error: null,
};

export const finalCostPromotionsReducer = (
  state = final_cost_promos_state,
  action
) => {
  switch (action.type) {
    case action_type.REQUEST_FINAL_COST_PROMOS:
      return { ...state, loading: true, error: null };
    case action_type.RECEIVE_FINAL_COST_PROMOS:
      return {
        ...state,
        loading: false,
        final_cost_promos: action.final_cost_promos,
      };
    case action_type.RECEIVE_FINAL_COST_PROMOS_ERROR:
      return {
        ...state,
        loading: false,
        error: action.error,
        final_cost_promos: {},
      };
    default:
      return state;
  }
};

let item_quantity_promos_state = {
  item_quantity_promos: {},
  loading: false,
  error: null,
};

export const itemQuantityPromotionsReducer = (
  state = item_quantity_promos_state,
  action
) => {
  switch (action.type) {
    case action_type.REQUEST_ITEM_QUANTITY_PROMOS:
      return { ...state, loading: true, error: null };
    case action_type.RECEIVE_ITEM_QUANTITY_PROMOS:
      return {
        ...state,
        loading: false,
        item_quantity_promos: action.item_quantity_promos,
      };
    case action_type.RECEIVE_ITEM_QUANTITY_PROMOS_ERROR:
      return {
        ...state,
        loading: false,
        error: action.error,
        item_quantity_promos: {},
      };
    default:
      return state;
  }
};
