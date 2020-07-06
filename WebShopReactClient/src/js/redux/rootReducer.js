import { combineReducers } from "redux";
import {
  basketItemsReducer,
  basketFinalCostPromosReducer,
  itemsReducer,
  finalCostPromotionsReducer,
  itemQuantityPromotionsReducer,
} from "./webshopReducer";

export default combineReducers({
  basketItemsReducer,
  basketFinalCostPromosReducer,
  itemsReducer,
  finalCostPromotionsReducer,
  itemQuantityPromotionsReducer,
});
