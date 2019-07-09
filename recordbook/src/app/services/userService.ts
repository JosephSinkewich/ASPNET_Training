import { HttpClient } from '@angular/common/http';
import { User } from '../model/user';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<User[]> {
        return this.http.get('http://localhost:59387/api/user');
    }

    public getById(id: number): Observable<User> {
        return this.http.get('http://localhost:59387/api/user/' + id);
    }

    public add(model: User) {
        this.http.post('http://localhost:59387/api/user/', model);
    }

    public edit(model: User) {
        this.http.put('http://localhost:59387/api/user/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/user/' + id);
    }
}