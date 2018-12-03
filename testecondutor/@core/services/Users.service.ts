import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

import { ApiService } from './ApiService';
import { UserModel } from 'src/content/Models/Users.model';

@Injectable()
export class UsersService {

  constructor(private apiService: ApiService) { }

  private getUrlApi() {
    return environment.api_url;
  }
  getUsersList(): Observable<any> {
      const url = `Users/GetUsers`;
    return this.apiService.get(url).pipe(map((res: any) => res.data));
  }
  AddUser(user: UserModel): Observable<any> {
    const url = `Users/AddUser`;
     return this.apiService.post(url, user).pipe(map((res: any) => res.data));

  }
  DeleteUser(id: number): Observable<any> {
    const url = `Users/DeleteUser`;
     return this.apiService.post(url, id).pipe(map((res: any) => res.data));
  }
  EditUser(user: UserModel): Observable<any> {
    const url = 'Users/UpdateUser';
    return this.apiService.post(url, user).pipe(map((res: any) => res.data));
  }
  // tslint:disable-next-line:no-shadowed-variable
}
