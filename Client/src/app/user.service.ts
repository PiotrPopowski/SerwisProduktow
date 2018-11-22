import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class UserService {

  private _getUserUrl = "http://localhost:63819/api/User/Get/";

  constructor(private http: HttpClient) { }

  getUser(id: number) {
    return this.http.get<any>(this._getUserUrl + id)
  }
}
