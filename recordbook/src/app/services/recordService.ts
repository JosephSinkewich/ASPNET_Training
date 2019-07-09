import { HttpClient } from '@angular/common/http';
import { Record } from '../model/record';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class RecordService {

    public constructor(private http: HttpClient){}

    public getAll(): Observable<Record[]> {
        return this.http.get('http://localhost:59387/api/record');
    }

    public getById(id: number): Observable<Record> {
        return this.http.get('http://localhost:59387/api/record/' + id);
    }

    public add(model: Record) {
        this.http.post('http://localhost:59387/api/record/', model);
    }

    public edit(model: Record) {
        this.http.put('http://localhost:59387/api/record/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/record/' + id);
    }

    public addEvent(recordId: number, eventId: number) {
        this.http.post('http://localhost:59387/api/record/addevent/' + recordId + ',' + eventId, null);
    }

    public removeEvent(recordId: number, eventId: number) {
        this.http.delete('http://localhost:59387/api/record/removeevent/' + recordId + ',' + eventId);
    }
}