import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import Swal from 'sweetalert2'

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  public post<T>(url: string, body: any) {
    return this.httpClient.post(url, body).pipe(
      map((data: IResponse<T>) => {
        if (data.statusCode.toString().startsWith("2")) {
          return data.result;
        } else {
          Swal.fire(data.statusCode.toString(), data.message.toString() + '</br>' + data.details, 'error');
          return <T>null;
        }
      })
    )
  }

  public get<T>(url: string, queryparams: any) {
    return this.httpClient.get(url, { params: queryparams }).pipe(
      map((data: IResponse<T>) => {
        if (data.statusCode.toString().startsWith("2")) {
          return data.result;
        } else {
          Swal.fire(data.statusCode.toString(), data.message.toString() + '</br>' + data.details, 'error');
          return <T>null;
        }
      })
    )
  }
}

interface IResponse<T> {
  statusCode: number;
  message: string;
  details: string;
  result: T;
}

export const ServerUrls = {
  GetProducts : "/api/product/getProducts",
  GetProductById : "/api/product/getProductById",
  GetCategories : "/api/product/getCategories",
  GetOrders : "/api/order/getOrders",
  CheckIfProductInStock : "/api/order/checkIfProductInStock",
  CreateOrder : "/api/order/createOrder",
}
