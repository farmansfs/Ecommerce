import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EshopComponent } from './eshop.component';
import { RouterModule } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProductsComponent } from './products/products.component';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '', component: EshopComponent, children: [
          { path: '', component: ProductsComponent },
          { path: 'details', component: ProductDetailComponent }
        ]
      },
    ])
  ],
  declarations: [EshopComponent, ProductDetailComponent, ProductsComponent]
})
export class EshopModule { }
