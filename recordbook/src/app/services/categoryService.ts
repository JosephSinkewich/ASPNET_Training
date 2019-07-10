import { HttpClient } from '@angular/common/http';
import { Category } from '../model/category';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';

@Injectable({
    providedIn: 'root'
})
export class CategoryService extends SimpleService<Category> {
    private urlSuffics = 'category';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllCategories(): Observable<Category[]> {
        return super.getAll(this.urlSuffics);
    }

    public getCategoryById(id: number): Observable<Category> {
        return super.getById(this.urlSuffics, id);
    }

    public updateCategory(model: Category): Observable<any> {
        return super.update(this.urlSuffics, model, model.id);
    }

    public addCategory(model: Category): Observable<Category> {
        return super.add(this.urlSuffics, model);
    }

    public deleteCategory(id: number): Observable<Category> {
        return super.delete(this.urlSuffics, id);
    }

}
