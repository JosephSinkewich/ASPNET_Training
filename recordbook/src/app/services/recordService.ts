import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Record } from '../model/record';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';
import { catchError } from 'rxjs/operators';
import { EventModel } from '../model/EventModel';

@Injectable({
    providedIn: 'root'
})
export class RecordService extends SimpleService<Record> {
    private urlSuffics = 'record';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllRecords(): Observable<Record[]> {
        return super.getAll(this.urlSuffics);
    }

    public getRecordById(id: number): Observable<Record> {
        return super.getById(this.urlSuffics, id);
    }

    public updateRecord(model: Record): Observable<any> {
        return super.update(this.urlSuffics, model, model.id);
    }

    public addRecord(model: Record): Observable<Record> {
        return super.add(this.urlSuffics, model);
    }

    public deleteRecord(id: number): Observable<Record> {
        return super.delete(this.urlSuffics, id);
    }

    public addEvent(recordId: number, eventId: number): Observable<EventModel> {
        const url = `${this.baseUrl}/${this.urlSuffics}/addevent/${recordId},${eventId}`;
        return this.http.post<EventModel>(url, null).pipe(catchError(this.handleError<EventModel>(`addEventToRecord recordId=${recordId}`)));
    }
    
    public removeEvent(recordId: number, eventId: number): Observable<EventModel> {
        const url = `${this.baseUrl}/${this.urlSuffics}/removeevent/${recordId},${eventId}`;
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.http.delete<EventModel>(url, httpOptions)
            .pipe(catchError(this.handleError<EventModel>(`addEventToRecord recordId=${recordId}`)));
    }
}