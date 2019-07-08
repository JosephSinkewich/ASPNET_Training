import { HttpClient } from '@angular/common/http';
import { Role } from '../model/role';

export class RoleService {

    public constructor(private http: HttpClient){}

    public getAll(): Role[] {
        let result: Role[]
        this.http.get('http://localhost:59387/api/role').subscribe((data:Role[]) => result = data);

        return result;
    }

    public getById(id: number): Role {
        let result: Role;
        this.http.get('http://localhost:59387/api/role/' + id).subscribe((data:Role) => result = data);

        return result;
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