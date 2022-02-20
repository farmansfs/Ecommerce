import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createReducer,
  createSelector,
  MetaReducer,
  on
} from '@ngrx/store';
import { IOrderDto } from 'src/interfaces/IOrderDto';
import { environment } from '../../environments/environment';
import { addToCart, initialize, removeFromCart } from '../actions';

export interface State {
  currentOrder: IOrderDto
}

export const initialAppState:IOrderDto = {
  adresss:'',
  orderLines: [],
  state:0,
  creationTime: new Date()
}

export const _reducers = createReducer(
  initialAppState,
  on(addToCart, (state,action) => ({
    ...state,
    orderLines: [
      ...(state.orderLines || []),
      {
        product:action.product,
        productId:action.product.id,
        amount:action.amount,
        price: action.product.price
      }
    ]
  })),
  on(removeFromCart, (state,action)=>({
    ...state,
    orderLines: state.orderLines.filter(x=>x.productId!==action.productId)
  })),
  on(initialize, (state,action)=>({
    ...action.initialState
  }))
);

export function reducers(state, action){
  return _reducers(state, action);
}


export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
