import { HttpClient } from '@angular/common/http';
import { Email } from '../model/email';

export class EmailService {

    public constructor(private http: HttpClient){}

    public getAll(): Email[] {
        let result: Email[]
        this.http.get('http://localhost:59387/api/email').subscribe((data:Email[]) => result = data);

        return result;
    }

    public getById(id: number): Email {
        let result: Email;
        this.http.get('http://localhost:59387/api/email/' + id).subscribe((data:Email) => result = data);

        return result;
    }

    public add(model: Email) {
        this.http.post('http://localhost:59387/api/email/', model);
    }

    public edit(model: Email) {
        this.http.put('http://localhost:59387/api/email/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/email/' + id);
    }
}