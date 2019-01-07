import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerUserData = {}
  constructor(private _auth: AuthService,
              private _router: Router) { }

  ngOnInit() {
  }

  registerUser() {
    this._auth.registerUser(this.registerUserData)
    .subscribe(
      res => {
        this.loginUser();
      },
      err => console.log(err)
    )      
  }

  loginUser () {
    this._auth.loginUser(this.registerUserData)
    .subscribe(
      res => {
        var b = res.Token
        localStorage.setItem('Token', res.Token)
        localStorage.setItem('UserID', res.User.ID)
        this._router.navigate(['/services'])
      },
      err => console.log(err)
    ) 
  }

}
