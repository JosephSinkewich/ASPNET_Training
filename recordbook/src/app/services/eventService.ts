import { HttpClient } from '@angular/common/http';
import { EventModel } from '../model/EventModel';

export class EventService {

    public constructor(private http: HttpClient){}

    public getAll(): EventModel[] {
        let result: EventModel[]
        this.http.get('http://localhost:59387/api/event').subscribe((data:EventModel[]) => result = data);

        return result;
    }

    public getById(id: number): EventModel {
        let result: EventModel;
        this.http.get('http://localhost:59387/api/event/' + id).subscribe((data:EventModel) => result = data);

        return result;
    }

    public getByRecordId(recordId: number): EventModel[] {
        let result: EventModel[];
        this.http.get('http://localhost:59387/api/event/GetByRecordId/' + recordId).subscribe((data:EventModel[]) => result = data);

        return result;
    }

    public add(model: EventModel) {
        this.http.post('http://localhost:59387/api/event/', model);
    }

    public edit(model: EventModel) {
        this.http.put('http://localhost:59387/api/event/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/event/' + id);
    }
}