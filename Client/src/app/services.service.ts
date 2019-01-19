import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class ServicesService {

  private _servicesUrl = "http://localhost:63819/api/Service/GetAll";
  private _detailUserUrl = "http://localhost:63819/api/User/Get/";
  private _gettingService = "http://localhost:63819/api/Service/Get/";
  private _removeServiceUrl = "http://localhost:63819/api/Service/Remove/"
  constructor(private http: HttpClient) { }

  getservices() {
    return this.http.get<any>(this._servicesUrl)
  }

  getSpecialservices() {
    return this.http.get<any>(this._detailUserUrl + localStorage.getItem('UserID'), { withCredentials: false })
  }

  getService(id: number) {
    return this.http.get<any>(this._gettingService + id);
  }

  remove(id: number){
    return this.http.delete(this._removeServiceUrl + id, { withCredentials: true });
  }
}
