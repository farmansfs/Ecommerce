import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { MyOrdersComponent } from './my-orders/my-orders.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { RouterModule } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '', component: OrderComponent, children: [
          { path: 'myorders', component: MyOrdersComponent, canActivate: [AuthorizeGuard] },
          { path: 'checkout', component: CheckoutComponent, canActivate: [AuthorizeGuard] }
        ]
      }
    ])
  ],
  declarations: [OrderComponent, MyOrdersComponent, CheckoutComponent]
})
export class OrderModule { }
