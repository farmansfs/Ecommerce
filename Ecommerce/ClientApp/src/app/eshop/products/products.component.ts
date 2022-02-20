import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpService, ServerUrls } from 'src/app/shared/services/http.service';
import { GetProductsInput } from 'src/interfaces/GetProductsInput';
import { IPagedResultDto } from 'src/interfaces/IPagedResultDto';
import { IProductDto } from 'src/interfaces/IProductDto';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  totalCount = 0;
  products: IProductDto[] = [];
  constructor(private http: HttpService,
    private activeRoute: ActivatedRoute) { }

  ngOnInit() {
   this.activeRoute.queryParams.subscribe(params=>{
     this.getProducts(params['categoryId']);
   })
  }

  getProducts(categoryId?:string, search?:string){
    var input = new GetProductsInput();
     input.skipCount = 0;
     input.maxResult = 10;
     if(categoryId){
      input.categoryId = categoryId;
     }

     if(search){
      input.search = search;
     }
    this.http.get<IPagedResultDto<IProductDto>>(ServerUrls.GetProducts, input).subscribe(result=>{
      this.totalCount = result.totalCount;
      this.products = result.items;
    });
  }
}
