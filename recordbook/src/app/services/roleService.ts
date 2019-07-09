import { HttpClient } from '@angular/common/http';
import { Role } from '../model/role';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RoleService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<Role[]> {
        return this.http.get('http://localhost:59387/api/role');
    }

    public getById(id: number): Observable<Role> {
        return this.http.get('http://localhost:59387/api/role/' + id);
    }

    public add(model: Role) {
        this.http.post('http://localhost:59387/api/role/', model);
    }

    public edit(model: Role) {
        this.http.put('http://localhost:59387/api/role/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/role/' + id);
    }
}