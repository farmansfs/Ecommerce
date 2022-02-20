import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { HttpService, ServerUrls } from 'src/app/shared/services/http.service';
import { IOrderDto } from 'src/interfaces/IOrderDto';
import { initialize, removeFromCart } from 'src/store/actions';
import { State } from 'src/store/reducers';
import { currentOrder, selectCurrentOrder } from 'src/store/selectors';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  currentCart: IOrderDto;
  adress: string;
  constructor(private store: Store<State>,
    private http:HttpService,
    private router: Router) { }

  ngOnInit() {
    this.store.select(currentOrder).subscribe(result=>{
      this.currentCart = result;
    });
  }

  order(){
    const newOrder: IOrderDto = {
      adresss: this.adress,
      orderLines: this.currentCart.orderLines,
      creationTime: new Date(),
      state: 0
    };
    this.http.post<number>(ServerUrls.CreateOrder, newOrder).subscribe(result=>{
        this.store.dispatch(initialize({initialState:{
          adresss:'',
          orderLines: [],
          state:0,
          creationTime:new Date()
        }}));
        this.router.navigateByUrl('/order/myorders');
    });
  }

  remove(productId: string) {
    this.store.dispatch(removeFromCart({productId}));
  }
}
