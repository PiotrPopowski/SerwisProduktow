import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  services = []
  constructor(private _serviceservice: ServicesService) { }

  ngOnInit() {
    this._serviceservice.getservices()
      .subscribe(
        res => this.services = res,
        err => console.log(err)
      )
  }

}
