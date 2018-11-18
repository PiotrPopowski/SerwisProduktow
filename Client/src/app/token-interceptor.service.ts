import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest } from '@angular/common/http'
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
@Injectable()
export class TokenInterceptorService implements HttpInterceptor {

  private _registerUrl = "http://localhost:63819/api/User/Register";
  private _loginUrl = "http://localhost:63819/api/Login";
  private _eventsUrl = "http://localhost:63819/api/Service/GetAll";

  constructor(private injector: Injector){}
  intercept(req, next) {
    if(req.url==this._registerUrl || req.url==this._loginUrl || req.url==this._eventsUrl) { return next.handle(req) }
    let authService = this.injector.get(AuthService)
    let tokenizedReq = req.clone(
      {
        headers: req.headers.set('Authorization', 'Bearer ' + authService.getToken())
      }
    )
    return next.handle(tokenizedReq)
  }

}
