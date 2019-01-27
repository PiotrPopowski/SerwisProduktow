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
  clearPassword(){
    (<HTMLInputElement>document.getElementById("registrationPass")).value="";
    (<HTMLInputElement>document.getElementById("repeatPassword")).value="";
  }
  clearLogin(){
    (<HTMLInputElement>document.getElementById("registrationLogin")).value="";
  }
  clearUserName(){
    (<HTMLInputElement>document.getElementById("registrationUserName")).value="";
  }
  registerUser() {
    if((<HTMLInputElement>document.getElementById('repeatPassword')).value==(<HTMLInputElement>document.getElementById('registrationPass')).value)
    {
      this._auth.registerUser(this.registerUserData)
      .subscribe(
        res => {
          this.loginUser();
        },
        err => {
          switch(err.statusText)
          {
            case "ShortLogin":
            case "LongLogin":
            case "NullLogin":
            case "WrongCharacterLogin":
            case "LoginTaken":
              this.clearLogin();
              this.showError(err.error);
              break;
            case "ShortUserName":
            case "LongUserName":
            case "UserNameTaken":
              this.clearUserName();
              this.showError(err.error);
              break;
            case "ShortPassword":
            case "LongPassword":
            case "NullPassword":
              this.clearPassword();
              this.showError(err.error);
              break;
          }
        }
      )
    }
    else{
      this.showError("Podane hasła są niezgodne");
      this.clearPassword();
    }      
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
