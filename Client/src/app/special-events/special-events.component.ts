import { Component, OnInit, Input } from '@angular/core';
import { EventService } from '../event.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router'
import { text } from '@angular/core/src/render3/instructions';
import { Service } from '../shared/service.model'
@Component({
  selector: 'app-special-events',
  templateUrl: './special-events.component.html',
  styleUrls: ['./special-events.component.css']
})
export class SpecialEventsComponent implements OnInit {

  event;
  constructor(private _eventService: EventService, private _router: Router) { }

  ngOnInit() {
    this._eventService.getSpecialEvents()
      .subscribe(
        res => this.event = res,
        err => this._router.navigate(['/login'])
      )
  }
}
