import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Store } from '@ngrx/store';
import { HttpService, ServerUrls } from 'src/app/shared/services/http.service';
import { CheckIfProductInStock } from 'src/interfaces/CheckIfProductInStock';
import { IProductDto } from 'src/interfaces/IProductDto';
import { addToCart } from 'src/store/actions';
import { State } from 'src/store/reducers';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product: IProductDto;
  amount: number = 1;
  hasAmountError = false;
  constructor(private http: HttpService,
    private activeRoute: ActivatedRoute,
    private store: Store<State>) { }

  ngOnInit() {
   this.activeRoute.queryParams.subscribe(params=>{
     this.http.get<IProductDto>(ServerUrls.GetProductById, {id:params["id"]}).subscribe(result=>{
       this.product = result;
     })
   })
  }

  addToCart(){
    this.hasAmountError = false;
    var check = new CheckIfProductInStock();
    check.amount = this.amount;
    check.productId = this.product.id;
    this.http.get<boolean>(ServerUrls.CheckIfProductInStock,check).subscribe(result=>{
      if(result) {
        this.store.dispatch(addToCart({product:this.product,amount:this.amount}));
        this.store.select((state)=>state.currentOrder).subscribe(order=>{
          console.log(order);
        })
      } else {
        this.hasAmountError = true;
      }
    })
  }

}
