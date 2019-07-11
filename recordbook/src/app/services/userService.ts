import { HttpClient } from '@angular/common/http';
import { User } from '../model/user';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';

@Injectable({
    providedIn: 'root'
})
export class UserService extends SimpleService<User> {
    private urlSuffics = 'user';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllUsers(): Observable<User[]> {
        return super.getAll(this.urlSuffics);
    }

    public getUserById(id: number): Observable<User> {
        return super.getById(this.urlSuffics, id);
    }

    public updateUser(model: User): Observable<any> {
        return super.update(this.urlSuffics, model, model.Id);
    }

    public addUser(model: User): Observable<User> {
        return super.add(this.urlSuffics, model);
    }

    public deleteUser(id: number): Observable<User> {
        return super.delete(this.urlSuffics, id);
    }

}
