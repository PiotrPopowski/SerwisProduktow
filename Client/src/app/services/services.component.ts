import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { Helpers } from '../Helpers';
import { Router } from '@angular/router'
import { AuthService } from '../auth.service';
import { NumberValueAccessor } from '@angular/forms/src/directives';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services = []
  currentPage:number=1

  constructor(private _servicesService: ServicesService, public helpers: Helpers, private _router: Router, private _auth: AuthService) { }

  ngOnInit() {
    this._servicesService.getServices(this.currentPage)
      .subscribe(
        res => this.services = res
          )
  }

  getServices(page)
  {
    this._servicesService.getServices(page).
      subscribe(
        res => {
          if(res.length>0){
          this.services = res;
          this.currentPage = page;
          }
        })
  }

  remove(id: number) {
    this._servicesService.remove(id).subscribe(res => this.ngOnInit())
  }



}
