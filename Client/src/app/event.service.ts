import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable()
export class EventService {

  private _eventsUrl = "http://localhost:63819/api/Service/GetAll";
  private _specialEventsUrl = "http://localhost:63819/api/User/Get/";

  constructor(private http: HttpClient) { }

  getEvents() {
    return this.http.get<any>(this._eventsUrl)
  }

  getSpecialEvents() {
    return this.http.get<any>(this._specialEventsUrl + localStorage.getItem('UserID'), { withCredentials: true })
  }
}
