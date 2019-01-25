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
  comments=[];
  currentPage:number=1

  constructor(private servicesService: ServicesService, private route: ActivatedRoute, private _auth : AuthService) { }

  ngOnInit() {
    this.getService();
    this.getComments(1);
  }
  getService(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.getService(id)
      .subscribe(service => this.service = service);
  }
  getComments(page): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.getComments(id,page)
      .subscribe(res => 
        {
          if(res.length>0)
          {
            this.comments = res;
            this.currentPage=page;
          }
        });
  }

  addNewComment(comment: string) {
    const id = +this.route.snapshot.paramMap.get('id');
    this.servicesService.addComment(comment, id).subscribe(res=>this.ngOnInit());
  }
}
