import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component'
import { RegisterComponent } from './register/register.component'
import { EventsComponent } from './events/events.component';
import { SpecialEventsComponent } from './special-events/special-events.component';
import { AuthGuard } from './auth.guard';
<<<<<<< HEAD
import { AddServiceComponent } from './add-service/add-service.component';
=======
import { UserDetailComponent } from './user-detail/user-detail.component';
>>>>>>> 0f9e3f6f13d790695233c1f9de8c40e2b957ef2d

const routes: Routes = [
  {
    path: '',
    redirectTo: '/events',
    pathMatch: 'full'
  },
  {
    path: 'events',
    component: EventsComponent
  },
  {
    path: 'special',
    component: SpecialEventsComponent
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
<<<<<<< HEAD
    path: 'add-service',
    component: AddServiceComponent
=======
    path: 'User/:id',
    component: UserDetailComponent
>>>>>>> 0f9e3f6f13d790695233c1f9de8c40e2b957ef2d
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
