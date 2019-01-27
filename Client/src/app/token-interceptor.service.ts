import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest } from '@angular/common/http'
import { AuthService } from './auth.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
@Injectable()
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private injector: Injector){}
  intercept(req, next) {
    if(req.withCredentials)
    {
      let authService = this.injector.get(AuthService)
      let tokenizedReq = req.clone(
        {
          headers: req.headers.set('Authorization', 'Bearer ' + authService.getToken()),
          withCredentials: false
        }
      )
      return next.handle(tokenizedReq)
    }
    return next.handle(req)
  }

}
