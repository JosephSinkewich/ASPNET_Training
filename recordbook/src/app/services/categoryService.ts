import { HttpClient } from '@angular/common/http';
import { Category } from '../model/category';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class CategoryService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<Category[]> {
        return this.http.get('http://localhost:59387/api/category');
    }

    public getById(id: number): Observable<Category> {
        return this.http.get('http://localhost:59387/api/category/' + id);
    }

    public add(model: Category) {
        this.http.post('http://localhost:59387/api/category/', model);
    }

    public edit(model: Category) {
        this.http.put('http://localhost:59387/api/category/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/category/' + id);
    }
}