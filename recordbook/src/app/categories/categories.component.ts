import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/categoryService';
import { Category } from '../model/category';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  private newCategory: Category;
  private categories: Category[];

  constructor(private service: CategoryService) { }

  ngOnInit() {
    this.newCategory = new Category();
    this.service.getAllCategories().subscribe((data: Category[]) => this.categories = data);
  }

  onAdd() {
    this.service.addCategory(this.newCategory).subscribe();
  }

  onDelete(id: number) {
    this.service.deleteCategory(id).subscribe();
  }

}
