import { HttpClient } from '@angular/common/http';
import { EventModel } from '../model/EventModel';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class EventService {
    public constructor(private http: HttpClient) {}

    public getAll(): Observable<EventModel[]> {
        return this.http.get<EventModel[]>('http://localhost:59387/api/event');
    }

    public getById(id: number):  Observable<EventModel> {
        return this.http.get('http://localhost:59387/api/event/' + id)
    }

    public getByRecordId(recordId: number): Observable<EventModel[]> {
        return this.http.get('http://localhost:59387/api/event/GetByRecordId/' + recordId)
    }

    public add(model: EventModel) {
        this.http.post('http://localhost:59387/api/event/', model);
    }

    public edit(model: EventModel) {
        this.http.put('http://localhost:59387/api/event/' + model.id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/event/' + id);
    }
}