import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { EventModel } from '../model/EventModel';
import { SimpleService } from './simpleService';
@Injectable({
  providedIn: 'root'
})
export class EventService extends SimpleService<EventModel> {
  private urlSuffics = 'event';
  constructor(private http: HttpClient) {
    super(http);
  }
  public getAllEvents(): Observable<EventModel[]> {
    return super.getAll(this.urlSuffics);
  }
  public getEventById(id: number): Observable<EventModel> {
    return super.getById(this.urlSuffics, id);
  }
  public getEventByRecordId(recordId: number): Observable<EventModel[]> {
    const url = `${this.baseUrl}/${this.urlSuffics}/GetByRecordId/${recordId}`;
    return this.http.get<EventModel[]>(url).pipe(catchError(this.handleError<EventModel[]>(`getEventByRecordId id=${recordId}`)));
  }
  public updateEvent(model: EventModel): Observable<any> {
    return super.update(this.urlSuffics, model, model.id);
  }
  public addEvent(model: EventModel): Observable<EventModel> {
    return super.add(this.urlSuffics, model);
  }
  public deleteEvent(id: number): Observable<EventModel> {
    return super.delete(this.urlSuffics, id);
  }
}
