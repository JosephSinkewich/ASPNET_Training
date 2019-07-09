import { HttpClient } from '@angular/common/http';
import { Picture } from '../model/picture';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class PictureService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<Picture[]> {
        return this.http.get('http://localhost:59387/api/picture');
    }

    public getById(id: number): Observable<Picture> {
        return this.http.get('http://localhost:59387/api/picture/' + id);
    }

    public add(model: Picture) {
        this.http.post('http://localhost:59387/api/picture/', model);
    }

    public edit(model: Picture) {
        this.http.put('http://localhost:59387/api/picture/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/picture/' + id);
    }
}