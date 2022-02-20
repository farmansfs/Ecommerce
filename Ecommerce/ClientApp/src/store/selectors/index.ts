import { createSelector } from "@ngrx/store";
import { State } from "../reducers";

export const selectCurrentOrder = (state: State) => state.currentOrder

export const cartItemCountSelector = createSelector(
  selectCurrentOrder,
  (order) => {
    return order? order.orderLines.length : 0;
  }
)

export const currenOrderLines = createSelector(
  selectCurrentOrder,
  (order) => {
    return order.orderLines;
  }
)

export const currentCartTotal = createSelector(
  selectCurrentOrder,
  (order) => {
    return order.orderLines.map(x=>x.amount*x.price).reduce((partialSum, a) => partialSum + a, 0);
  }
)


export const currentOrder = createSelector(
  selectCurrentOrder,
  (order) => {
    return order;
  }
)
