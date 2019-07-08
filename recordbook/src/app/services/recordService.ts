import { HttpClient } from '@angular/common/http';
import { Record } from '../model/record';

export class RecordService {

    public constructor(private http: HttpClient){}

    public getAll(): Record[] {
        let result: Record[]
        this.http.get('http://localhost:59387/api/record').subscribe((data:Record[]) => result = data);

        return result;
    }

    public getById(id: number): Record {
        let result: Record;
        this.http.get('http://localhost:59387/api/record/' + id).subscribe((data:Record) => result = data);

        return result;
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