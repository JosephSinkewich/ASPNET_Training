import { HttpClient } from '@angular/common/http';
import { Email } from '../model/email';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EmailService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<Email[]> {
        return this.http.get('http://localhost:59387/api/email');
    }

    public getById(id: number): Observable<Email> {
        return this.http.get('http://localhost:59387/api/email/' + id);
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