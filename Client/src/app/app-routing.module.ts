import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component'
import { RegisterComponent } from './register/register.component'
import { ServicesComponent } from './services/services.component';
import { AddServiceComponent } from './add-service/add-service.component';
import { UserDetailComponent } from './user-detail/user-detail.component'
const routes: Routes = [
  {
    path: '',
    redirectTo: '/services',
    pathMatch: 'full'
  },
  {
    path: 'services',
    component: ServicesComponent
  },
  {
    path: 'user/:id',
    component: UserDetailComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'add-service',
    component: AddServiceComponent
  },
  {
    path: 'User/',
    component: UserDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
