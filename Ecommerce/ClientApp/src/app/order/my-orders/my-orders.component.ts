import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService, ServerUrls } from 'src/app/shared/services/http.service';
import { IOrderDto } from 'src/interfaces/IOrderDto';

@Component({
  selector: 'app-my-orders',
  templateUrl: './my-orders.component.html',
  styleUrls: ['./my-orders.component.scss']
})
export class MyOrdersComponent implements OnInit {

  orders: IOrderDto[];
  constructor(private http: HttpService) { }

  ngOnInit() {
   this.http.get<IOrderDto[]>(ServerUrls.GetOrders, {}).subscribe(result=>{
     this.orders = result;
   })
  }

}
