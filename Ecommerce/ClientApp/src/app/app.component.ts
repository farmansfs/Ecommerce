import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { IOrderDto } from 'src/interfaces/IOrderDto';
import { initialize } from 'src/store/actions';
import { State } from 'src/store/reducers';
import { currentOrder } from 'src/store/selectors';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  title = 'app';

  /**
   *
   */
  constructor(private store: Store<State>) {


  }

  ngOnInit(): void {
    if(sessionStorage.getItem('checkoutCart')){
      let data = JSON.parse(sessionStorage.getItem('checkoutCart')) as IOrderDto;
      this.store.dispatch(initialize({initialState:data}));
    }
    this.store.select(currentOrder).subscribe(order=>{
      sessionStorage.setItem('checkoutCart', JSON.stringify(order));
    });
  }
}
