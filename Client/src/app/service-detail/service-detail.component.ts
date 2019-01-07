import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {
  service;


  constructor(private servicesService: ServicesService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getService();
  }
  getService(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.getService(id)
      .subscribe(service => this.service = service);
  }
}
