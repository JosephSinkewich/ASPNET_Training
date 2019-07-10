import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class SimpleService<T> {

    protected baseUrl = 'http://localhost:59387/api';
    private httpClient: HttpClient;

    constructor(http: HttpClient) {
        this.httpClient = http;
     }

    protected handleError<U>(operation = 'operation', result?: U) {
        return (error: any): Observable<U> => {
            console.error(error);

            return of(result as U);
        };
    }

    protected getAll(urlSuffics: string): Observable<T[]> {
        const url = `${this.baseUrl}/${urlSuffics}`;
        return this.httpClient.get<T[]>(url)
            .pipe(catchError(this.handleError<T[]>(`getAll ${urlSuffics}`, [])));
    }

    protected getById(urlSuffics: string, id: number): Observable<T> {
        const url = `${this.baseUrl}/${urlSuffics}/${id}`;
        return this.httpClient.get<T>(url).pipe(
            catchError(this.handleError<T>(`getById ${urlSuffics} id=${id}`))
        );
    }

    protected update(urlSuffics: string, model: T, id: number): Observable<any> {
        const url = `${this.baseUrl}/${urlSuffics}/${id}`;
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.httpClient.put(url, model, httpOptions).pipe(
            catchError(this.handleError<any>(`update ${urlSuffics}`))
        );
    }

    public add(urlSuffics: string, model: T): Observable<T> {
        const url = `${this.baseUrl}/${urlSuffics}`;
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.httpClient.post<T>(url, model, httpOptions).pipe(
            catchError(this.handleError<T>(`add ${urlSuffics}`))
        );
    }

    public delete(urlSuffics: string, id: number): Observable<T> {
        const url = `${this.baseUrl}/${urlSuffics}/${id}`;
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.httpClient.delete<T>(url, httpOptions).pipe(
            catchError(this.handleError<T>(`delete ${urlSuffics} id=${id}`))
        );
    }
}