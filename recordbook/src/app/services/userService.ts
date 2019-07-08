import { HttpClient } from '@angular/common/http';
import { User } from '../model/user';

export class UserService {

    public constructor(private http: HttpClient){}

    public getAll(): User[] {
        let result: User[]
        this.http.get('http://localhost:59387/api/user').subscribe((data:User[]) => result = data);

        return result;
    }

    public getById(id: number): User {
        let result: User;
        this.http.get('http://localhost:59387/api/user/' + id).subscribe((data:User) => result = data);

        return result;
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