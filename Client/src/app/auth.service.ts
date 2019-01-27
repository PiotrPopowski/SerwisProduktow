import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router'

@Injectable()
export class AuthService {

  private _registerUrl = "http://localhost:63819/api/User/Register";
  private _loginUrl = "http://localhost:63819/api/Login";

  constructor(private http: HttpClient,
              private _router: Router) { }

  registerUser(user) {
    return this.http.post<any>(this._registerUrl, user)
  }

  loginUser(user) {
    return this.http.post<any>(this._loginUrl, user)
  }

  logoutUser() {
    localStorage.removeItem('Token')
    localStorage.removeItem('UserID')
    this._router.navigate(['/services'])
  }

  getToken() {
    return localStorage.getItem('Token')
  }

  loggedIn() {
    return !!localStorage.getItem('Token')    
  }
}
