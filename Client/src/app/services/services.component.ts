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
  constructor(private _servicesService: ServicesService, public helpers: Helpers, private _router: Router, private _auth: AuthService) { }

  ngOnInit() {
    this._servicesService.getServices()
      .subscribe(
        res => this.services = res
          )
  }

  remove(id: number) {
    this._servicesService.remove(id).subscribe(res => this.ngOnInit())
  }



}
