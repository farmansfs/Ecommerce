import { createAction, props } from '@ngrx/store';
import { IOrderDto } from 'src/interfaces/IOrderDto';
import { IProductDto } from 'src/interfaces/IProductDto';

export const addToCart = createAction(
  '[eshopModule] add to cart Action',
  props<{ product: IProductDto; amount: number }>()
);

export const removeFromCart = createAction(
  '[eshopModule] remove from cart Action',
  props<{productId: string}>()
)

export const initialize = createAction(
  '[eshopModule] initialize',
  props<{initialState: IOrderDto}>()
)
