import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Record } from '../model/record';
import { RecordViewModel } from '../model/recordViewModel';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';
import { catchError } from 'rxjs/operators';
import { EventModel } from '../model/EventModel';
import { CategoryService } from './categoryService';
import { Category } from '../model/category';
import { EventService } from './eventService';

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
        return super.update(this.urlSuffics, model, model.Id);
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

    public getAllRecordViewModels(): RecordViewModel[] {
        let records: Record[];
        let result: RecordViewModel[];
        super.getAll(this.urlSuffics).subscribe((data: Record[]) => records = data);

        let categoryService = new CategoryService(this.http);
        let eventService = new EventService(this.http);

        records.forEach(function (record) {
            let recordViewModel = new RecordViewModel();
            recordViewModel.Id = record.Id;
            recordViewModel.Name = record.Name;
            recordViewModel.CreateDate = record.CreateDate;
            recordViewModel.Description = record.Description;

            categoryService.getCategoryById(record.CategoryId)
                .subscribe((data: Category) => recordViewModel.Category = data.Name);

            let events: EventModel[];
            eventService.getEventByRecordId(record.Id)
                .subscribe((data: EventModel[]) => recordViewModel.Events = data);

            result.push(recordViewModel);
        });

        return result;
    }
}
