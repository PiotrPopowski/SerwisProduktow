import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class ServicesService {

  private _servicesUrl = "http://localhost:63819/api/Service/GetAll";
  private _specialservicesUrl = "http://localhost:63819/api/User/Get/";
  private _gettingService = "http://localhost:63819/api/Service/Get/";

  constructor(private http: HttpClient) { }

  getservices() {
    return this.http.get<any>(this._servicesUrl)
  }

  getSpecialservices() {
    return this.http.get<any>(this._specialservicesUrl + localStorage.getItem('UserID'), { withCredentials: false })
  }

  getService(id: number) {
    return this.http.get<any>(this._gettingService + id);
  }
}
