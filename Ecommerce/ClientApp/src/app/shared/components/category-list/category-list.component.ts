import { Component, OnInit } from '@angular/core';
import { ICategoryDto } from 'src/interfaces/ICategoryDto';
import { HttpService, ServerUrls } from '../../services/http.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {

  categories: ICategoryDto[] = [];
  constructor(private http: HttpService) { }

  ngOnInit() {
    this.http.get<ICategoryDto[]>(ServerUrls.GetCategories,{}).subscribe(result=>{
      this.categories = result;
    });
  }

}
