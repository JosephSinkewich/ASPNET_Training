import { HttpClient } from '@angular/common/http';
import { Picture } from '../model/picture';

export class PictureService {

    public constructor(private http: HttpClient){}

    public getAll(): Picture[] {
        let result: Picture[]
        this.http.get('http://localhost:59387/api/picture').subscribe((data:Picture[]) => result = data);

        return result;
    }

    public getById(id: number): Picture {
        let result: Picture;
        this.http.get('http://localhost:59387/api/picture/' + id).subscribe((data:Picture) => result = data);

        return result;
    }

    public add(model: Picture) {
        this.http.post('http://localhost:59387/api/picture/', model);
    }

    public edit(model: Picture) {
        this.http.put('http://localhost:59387/api/picture/' + model.Id, model);
    }

    public delete(id: number) {
        this.http.delete('http://localhost:59387/api/picture/' + id);
    }
}