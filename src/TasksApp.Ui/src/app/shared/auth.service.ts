import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }
  
  login(user: User) {
    let api = 'http://localhost:8008/api/security/token';

    return this.http
      .post<string>(api, user)
      .subscribe((response: string) => {
        localStorage.setItem('access_token', response);
      });
  }

  getToken() {
    return localStorage.getItem('access_token');
  }
}
