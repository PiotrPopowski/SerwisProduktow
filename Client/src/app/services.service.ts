import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class ServicesService {

  private _servicesUrl = "http://localhost:63819/api/Service/GetAll";
  private _specialservicesUrl = "http://localhost:63819/api/User/Get/";

  constructor(private http: HttpClient) { }

  getservices() {
    return this.http.get<any>(this._servicesUrl)
  }

  getSpecialservices() {
    return this.http.get<any>(this._specialservicesUrl + localStorage.getItem('UserID'), { withCredentials: false })
  }
}
