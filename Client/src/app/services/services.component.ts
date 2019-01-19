import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { Helpers } from '../Helpers';
import { Router } from '@angular/router'
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services = []
  constructor(private _serviceservice: ServicesService, public helpers: Helpers, private _router: Router, private _auth: AuthService) { }

  ngOnInit() {
    this._serviceservice.getservices()
      .subscribe(
        res => this.services = res
      )
  }

  remove(id: number) {
    this._serviceservice.remove(id)
      .subscribe(
        res => this.ngOnInit()
      )

  }



}
