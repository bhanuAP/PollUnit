import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './models/User';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const requestOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

const baseUrl: string = 'http://localhost:52276/';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  public loginAccount(userCredentials: User, callback) {
    let requestUrl = baseUrl + '/login';
    return this.http.post<User>(requestUrl, userCredentials, requestOptions)
    .subscribe();
  }

  public createAccount(userCredentials: User, callback) {
    let requestUrl = baseUrl + '/createAccount';
    this.http.post(requestUrl, userCredentials, requestOptions)
    .subscribe(() => {},
      (response: HttpErrorResponse) => {
        let resMessage = JSON.parse(response.error.value);
        resMessage.statusCode = response.status;
        callback(resMessage);
    });
  }
}
