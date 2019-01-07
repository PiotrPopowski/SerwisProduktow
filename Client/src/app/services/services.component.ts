import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { Helpers } from '../Helpers';
import { Router } from '@angular/router'

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services = []
  constructor(private _serviceservice: ServicesService, public helpers: Helpers, private _router: Router) { }

  ngOnInit() {
    this._serviceservice.getservices()
      .subscribe(
        res => this.services = res,
        err => console.log(err)
      )
  }

  redirectToAdd() {
    this._router.navigate(['/add-service'])

  }



}
