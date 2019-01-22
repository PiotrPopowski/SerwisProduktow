import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from '../services.service';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.css']
})
export class AddServiceComponent implements OnInit {

  serviceData = {};

  constructor(private _router : Router, private services : ServicesService, private _auth: AuthService) { }

  ngOnInit() {
  }

  showError(error: string) {
    document.getElementById("error").innerHTML = error;
  }

  addNewService () {
    console.log(this.serviceData);
    this.services.addService(this.serviceData)
    .subscribe(
      res => {
        this._router.navigate(['/services'])
      },
      err => {this.showError(err.error);
              document.getElementById('serviceDesc').focus();}
    ) 
  }

}
