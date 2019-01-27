import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginUserData = {}

  constructor(private _auth: AuthService,
              private _router: Router) { }

  ngOnInit() {
  }

  showError(err: string) {
    document.getElementById("error").innerHTML = err;
  }

  loginUser () {
    this._auth.loginUser(this.loginUserData)
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
