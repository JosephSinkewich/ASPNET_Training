import { HttpClient } from '@angular/common/http';
import { Role } from '../model/role';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';

@Injectable({
    providedIn: 'root'
})
export class RoleService extends SimpleService<Role> {
    private urlSuffics = 'role';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllRoles(): Observable<Role[]> {
        return super.getAll(this.urlSuffics);
    }

    public getRoleById(id: number): Observable<Role> {
        return super.getById(this.urlSuffics, id);
    }

    public updateRole(model: Role): Observable<any> {
        return super.update(this.urlSuffics, model, model.Id);
    }

    public addRole(model: Role): Observable<Role> {
        return super.add(this.urlSuffics, model);
    }

    public deleteRole(id: number): Observable<Role> {
        return super.delete(this.urlSuffics, id);
    }

}
