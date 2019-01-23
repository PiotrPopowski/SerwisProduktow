import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class ServicesService {

  private _servicesUrl = "http://localhost:63819/api/Service/GetAll";
  private _detailUserUrl = "http://localhost:63819/api/User/Get/";
  private _gettingService = "http://localhost:63819/api/Service/Get/";
  private _removeServiceUrl = "http://localhost:63819/api/Service/Remove/"
  private _addingServiceUrl = "http://localhost:63819/api/Service/addService";
  private _addingCommentUrl = "http://localhost:63819/api/Service/AddComment";

  constructor(private http: HttpClient) { }

  getServices() {
    return this.http.get<any>(this._servicesUrl);
  }

  getSpecialservices() {
    return this.http.get<any>(this._detailUserUrl + localStorage.getItem('UserID'), { withCredentials: false })
  }

  getService(id: number) {
    return this.http.get<any>(this._gettingService + id);
  }

  addService(service) {
    service.UserID=+localStorage.getItem('UserID');
    return this.http.post<any>(this._addingServiceUrl, service, { withCredentials: true });
  }

  addComment(content, serviceID){
    var userID=+localStorage.getItem('UserID');
    var comment={userID, content, serviceID};
    return this.http.post<any>(this._addingCommentUrl,comment, { withCredentials: true });
  }

  remove(id:number){
    return this.http.delete<any>(this._removeServiceUrl + id, { withCredentials: true });
  }
}
