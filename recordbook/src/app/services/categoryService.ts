import { HttpClient } from '@angular/common/http';
import { Category } from '../model/category';

export class CategoryService {

    public constructor(private http: HttpClient){}

    public getAll(): Category[] {
        let result: Category[]
        this.http.get('http://localhost:59387/api/category').subscribe((data:Category[]) => result = data);

        return result;
    }

    public getById(id: number): Category {
        let result: Category;
        this.http.get('http://localhost:59387/api/category/' + id).subscribe((data:Category) => result = data);

        return result;
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