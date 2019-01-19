import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class UserService {

  private _getUserUrl = "http://localhost:63819/api/User/Get/";
  private _removeUserUrl ="http://localhost:63819/api/User/Remove/";
  constructor(private http: HttpClient) { }

  getUser(id: number) {
    return this.http.get<any>(this._getUserUrl + id)
  }

  removeUser(id: number){
    return this.http.delete(this._removeUserUrl + id);
  }
}
