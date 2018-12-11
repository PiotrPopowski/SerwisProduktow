import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-add-service',
  templateUrl: './add-service.component.html',
  styleUrls: ['./add-service.component.css']
})
export class AddServiceComponent implements OnInit {

  serviceData = {};

  constructor(private _router : Router, private _auth : AuthService) { }

  ngOnInit() {
  }

  addNewService () {
    console.log(this.serviceData);
    this._auth.addService(this.serviceData)
    .subscribe(
      res => {
        this._router.navigate(['/special'])
      },
      err => console.log(err)
    ) 
  }

}
