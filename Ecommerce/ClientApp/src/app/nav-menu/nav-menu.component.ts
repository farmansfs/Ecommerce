import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { IOrderLineDto } from 'src/interfaces/IOrderDto';
import { State } from 'src/store/reducers';
import { cartItemCountSelector, currenOrderLines, currentCartTotal } from 'src/store/selectors';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  cartCount$: Observable<number>;
  cartItems$: Observable<IOrderLineDto[]>;
  cartTotal$: Observable<number>;

  constructor(private store: Store<State>) {
  }
  ngOnInit(): void {
    this.cartCount$ = this.store.select(cartItemCountSelector);
    this.cartItems$ = this.store.select(currenOrderLines);
    this.cartTotal$ = this.store.select(currentCartTotal);
  }


  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
