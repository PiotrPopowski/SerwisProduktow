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

  showError(error: string) {
    document.getElementById("error").innerHTML = error;
  }

  registerUser() {
    this._auth.registerUser(this.registerUserData)
    .subscribe(
      res => {
        this.loginUser();
      },
      err => {this.showError(err.error);
          document.getElementById('registrationLogin').focus();
        document.getElementById('registrationUserName').focus();
      document.getElementById('registrationPass').focus();}
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
      err => {this.showError(err.error);
        document.getElementById('userLogin').focus();
        document.getElementById('userPass').focus();}
    ) 
  }

}
