import { IProductDto } from "./IProductDto";

export interface IOrderDto {
    state: OrderState;
    creationTime: Date;
    adresss: string;
    orderLines: IOrderLineDto[];
}

export interface IOrderLineDto {
    productId: string;
    product: IProductDto;
    amount: number;
    price: number;
}

export enum OrderState {
  Initial = 0,
  Accepted = 1,
  Prepearing = 2,
  OnDelivery = 3,
  Delivered = 4,
  Rejected = 5
}
