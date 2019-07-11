import { HttpClient } from '@angular/common/http';
import { Email } from '../model/email';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';

@Injectable({
    providedIn: 'root'
})
export class EmailService extends SimpleService<Email> {
    private urlSuffics = 'email';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllEmails(): Observable<Email[]> {
        return super.getAll(this.urlSuffics);
    }

    public getEmailById(id: number): Observable<Email> {
        return super.getById(this.urlSuffics, id);
    }

    public updateEmail(model: Email): Observable<any> {
        return super.update(this.urlSuffics, model, model.Id);
    }

    public addEmail(model: Email): Observable<Email> {
        return super.add(this.urlSuffics, model);
    }

    public deleteEmail(id: number): Observable<Email> {
        return super.delete(this.urlSuffics, id);
    }

}
