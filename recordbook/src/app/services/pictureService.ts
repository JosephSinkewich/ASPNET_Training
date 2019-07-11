import { HttpClient } from '@angular/common/http';
import { Picture } from '../model/picture';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SimpleService } from './simpleService';

@Injectable({
    providedIn: 'root'
})
export class PictureService extends SimpleService<Picture> {
    private urlSuffics = 'picture';

    constructor(private http: HttpClient) {
        super(http);
    }

    public getAllPictures(): Observable<Picture[]> {
        return super.getAll(this.urlSuffics);
    }

    public getPictureById(id: number): Observable<Picture> {
        return super.getById(this.urlSuffics, id);
    }

    public updatePicture(model: Picture): Observable<any> {
        return super.update(this.urlSuffics, model, model.Id);
    }

    public addPicture(model: Picture): Observable<Picture> {
        return super.add(this.urlSuffics, model);
    }

    public deletePicture(id: number): Observable<Picture> {
        return super.delete(this.urlSuffics, id);
    }

}
