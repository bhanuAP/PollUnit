import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './models/User';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const requestOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

const baseUrl: string = 'http://localhost:52276';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  public login(userCredentials: User): Observable<User> {
    let requestUrl = baseUrl + '/login';
    return this.http.post<User>(requestUrl, userCredentials, requestOptions).pipe(
      map(data => data));
  }

  public createAccount(userCredentials: User) {
    let requestUrl = baseUrl + '/createAccount';
    return this.http.post(requestUrl, userCredentials, requestOptions).pipe(
      map(data => {
        alert(data)
         return data;
        }
      ));
  }
}
