import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {
  service;


  constructor(private servicesService: ServicesService, private route: ActivatedRoute, private _auth : AuthService) { }

  ngOnInit() {
    this.getService();
  }
  getService(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.getService(id)
      .subscribe(service => this.service = service);
  }

  addNewComment(comment: string) {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.addComment(comment, id).subscribe();
  }
}
