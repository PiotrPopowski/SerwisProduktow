import { AuthGuard } from './auth.guard';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ServicesComponent } from './services/services.component';
import { AuthService } from './auth.service';
import { ServicesService } from './services.service';
import { TokenInterceptorService } from './token-interceptor.service';
import { AddServiceComponent } from './add-service/add-service.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserService } from './user.service';
import { Helpers } from './Helpers';
import { ServiceDetailComponent } from './service-detail/service-detail.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ServicesComponent,
    AddServiceComponent,
    UserDetailComponent,
    ServiceDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [AuthService, AuthGuard, ServicesService, UserService, Helpers,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
