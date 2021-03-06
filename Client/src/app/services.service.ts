import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Injectable()
export class ServicesService {

  private _servicesUrl = "http://localhost:63819/api/Service/GetAll";
  private _detailUserUrl = "http://localhost:63819/api/User/Get/";
  private _gettingService = "http://localhost:63819/api/Service/Get/";
  private _gettingImage = "http://localhost:63819/api/File/GetImage";
  private _gettingComments = "http://localhost:63819/api/Service/GetComments/";
  private _removeServiceUrl = "http://localhost:63819/api/Service/Remove/"
  private _addingServiceUrl = "http://localhost:63819/api/Service/addService";
  private _addingCommentUrl = "http://localhost:63819/api/Service/AddComment";
  private _addingRattingUrl = "http://localhost:63819/api/Service/Vote";

  constructor(private http: HttpClient) { }

  getServices(page) {
    return this.http.get<any>(this._servicesUrl, {params: { page: page, count: "5" }});
  }

  getComments(id, page) {
    return this.http.get<any>(this._gettingComments, {params: {serviceID: id, page: page, count: "5" }});
  }

  getSpecialservices() {
    return this.http.get<any>(this._detailUserUrl + localStorage.getItem('UserID'), { withCredentials: false })
  }

  getService(id: number) {
    return this.http.get<any>(this._gettingService + id);
  }

  getImage(name){
    return this.http.get<any>(this._gettingImage, { params: { name: name } });
  }

  addService(service) {
    service.UserID=+localStorage.getItem('UserID');
    return this.http.post<any>(this._addingServiceUrl, service, { withCredentials: true });
  }

  addRating(rating){
    return this.http.post<any>(this._addingRattingUrl, rating, {withCredentials: true})
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
