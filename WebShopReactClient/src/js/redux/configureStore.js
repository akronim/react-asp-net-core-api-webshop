import { createStore, applyMiddleware } from "redux";
import thunk from "redux-thunk";
import rootReducer from "../redux/rootReducer";

function configureStore() {
  return createStore(rootReducer, applyMiddleware(thunk));
}

const store = configureStore();

export default store;
