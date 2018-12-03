import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { throwError, Observable } from 'rxjs';
import { catchError, take } from 'rxjs/operators';
import { debug } from 'util';
import { environment } from 'src/environments/environment';


@Injectable()
export class ApiService {

  constructor(
    private http: HttpClient,

  ) { }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http.get(`${environment.api_url}${path}`, { params });
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http.put(
      `${environment.api_url}${path}`,
      JSON.stringify(body),
      { headers: { 'Content-Type': 'application/json' } });
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http.post(
      `${environment.api_url}${path}`,
      JSON.stringify(body),
      { headers: { 'Content-Type': 'application/json' } });
  }

  delete(path): Observable<any> {
    return this.http.delete(
      `${environment.api_url}${path}`, { headers: { 'Content-Type': 'application/json' } });
  }
}
